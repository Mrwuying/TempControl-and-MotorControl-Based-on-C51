#include<reg51.h>
#include<intrins.h>
#include<stdio.h>
#include<stdlib.h>
#include<string.h>

#define U8INT unsigned char 
#define U16INT unsigned int 
#define U32INT unsigned long int
#define Max_cmd_length 20

sbit MA=P1^0;
sbit MB=P1^1;
sbit PWM=P1^2;
sbit RS=P2^0;
sbit RW=P2^1;
sbit EN=P2^2;

sbit LED1_Hot_Waring=P2^4;
sbit LED2_Cold_Waring=P2^5;
sbit LED3_Power=P2^6;
sbit LED4_Light=P2^7;
sbit SoundPin=P3^7;


extern void LCD_Init();
extern void Display_String(U8INT row,U8INT col,U8INT *str);
extern void delay_ms(U16INT x);
extern U8INT Get_Temp16bits();
extern U8INT Temp_Bytes[];

U8INT Display_TempString[17];
volatile U8INT Received_Char_Buff[Max_cmd_length+1];
volatile U8INT Buff_Index=0;
volatile U8INT Received_Receipt=0;

extern void Wind_Open();
extern void Wind_Close();
extern void Light_Open();
extern void Light_Close();
volatile float temp=0.00f;//TempF用于存temp完全计算后的结果，因为中途计算结果或者初始化结果输出会引起抖动
volatile float TempF=0.00f;
int flag=1;//1:下位机控制权 0：上位机控制权

void Transmit_String(char *str)//把tempf传到SBUF
{
	U8INT i=0;
	while(str[i])
	{
		SBUF=str[i];
		while(TI==0);
		TI=0;
		i++;
	}
}
void Received_DataSPort(void) interrupt 4//串口中断
{ 
   static U8INT i=0;//由于中断会多次调用，加static一次之后就不会赋值了
   if(RI==0)return ;//有串口中断传进来，RI会置1
   RI=0;
   
   if(SBUF=='$') 
   {
	 i=0;
	 return;
   }
   if(SBUF==0x0D)//从上位机到下位机最后传输总是回车加换行
   {
     return;
   }
   if(SBUF==0x0A)
   {
     Received_Receipt=1;
   }
   else
   {
	 Received_Char_Buff[i]=SBUF;
	 Received_Char_Buff[++i]='\0';
   }
   
  
}
void Serial_Port_Init()
{
  SCON=0x50;//0101 0000，方式1,8位计时器可变波特率，ren=1允许接受数据
  TMOD=0x20;//8位的计时重载
  PCON=0x80;//smod置1，波特率加倍
  TH1=0xFA;//根据波特率来设置的，TH高位，TL低位8位计时器
  TL1=0xFA;
  EA=1;//开中断使能
  ES=1;//开启串口中断
  TR1=1;//开定时器TR1
}
/*===================功能函数，tempf的计算,显示和传到SBUF=================================*/
void Tempf_TransToSBUF(float TempF)
{
	delay_ms(10);	
	sprintf(Display_TempString,"%5.1f",TempF);//\xDF\x43
	strcat(Display_TempString,"\r\n");
	Transmit_String(Display_TempString);
	strcat(Display_TempString,"\xDF\x43");
	Display_String(1,4,Display_TempString);
	delay_ms(10);
}


/*===================功能函数，tempf的计算和传到SBUF=================================*/

/*===================电机正，反，停转=================================*/
void Right_Spin(float TempF)
{
	MA=1;//高电位正转
	MB=0;		 
	PWM=1;//加速
	delay_ms(TempF-36);
	PWM=0;//降速

}

void Left_Spin(float TempF)
{
	MA=0;//低电位反转
	MB=1;		 
	PWM=1;//加速
	delay_ms(10-TempF);
	PWM=0;//降速
	delay_ms(TempF-0);

}

void Stop_Spin()
{
	MA=0;
	MB=0;
}

/*===================电机正，反，停转=================================*/
 
/*===================上位机事件，响铃，重置，升温，降温=================================*/
void Ring_Open()//响铃
{
	U8INT i=0;
	SoundPin=0;
	for(i=0;i<100;i++)
	{
		SoundPin=!SoundPin;delay_ms(1);
	}
	delay_ms(300);
}

void Temp_Up(float TempF)
{
	flag=0;
	Tempf_TransToSBUF(TempF);
	
}
void Temp_Down(float TempF)
{
	flag=0;
	Tempf_TransToSBUF(TempF);
	
}
/*===================上位机事件，响铃，重置，升温，降温=================================*/

/*===================根据温度控制LED和警报===================*/
void TempControl(float TempF)
{
		delay_ms(10);
		if(TempF>100) 
		{
			TempF=100;
		}
	 	if(TempF>=10&&TempF<=36)//10~36 不动
		{
			LED1_Hot_Waring=0;
			LED2_Cold_Waring=0;
			Stop_Spin();
		}
		else if(TempF>36&&TempF<=60)//36~60 正转，两灯灭
		{
			LED1_Hot_Waring=0;
			LED2_Cold_Waring=0;
			Right_Spin(TempF);
		}
		else if(TempF>=0&&TempF<=10)//0~10 反转，亮冷灯
		{
			LED1_Hot_Waring=0;
			LED2_Cold_Waring=1;
			Left_Spin(TempF);
		}
		else if(TempF>=60&&TempF<=100)//温度在60以上响铃报警，亮热灯
		{
			 LED1_Hot_Waring=1;
   			 LED2_Cold_Waring=0;
			 Ring_Open();
		}
		
		delay_ms(10);
}
/*===================根据温度控制LED和警报===================*/
void main()
{   
     
   Serial_Port_Init();
   LCD_Init();
   
   Display_String(0,0,"TempControlSystem");
   Display_String(1,0,"  Waiting.....");
   Get_Temp16bits();
   delay_ms(1000);
   Display_String(1,0,"              ");
   while(1)
   {
     if(Get_Temp16bits()&&flag==1)
	 {
	    temp=(int)((Temp_Bytes[1]<<8)|Temp_Bytes[0])*0.0625;
		TempF=temp;
		Tempf_TransToSBUF(TempF);//tempf的计算和传到SBUF
		TempControl(TempF);//根据温度给出反应
	 }
	 if(Received_Receipt==1)
	 {
		Received_Receipt=0;
		
		if(strcmp(Received_Char_Buff,"RING_OPEN")==0)
		{
		  	 Ring_Open();//响铃
		}
		else if(strcmp(Received_Char_Buff,"TEMP_UP")==0)
		{
		  	 Temp_Up(++TempF);//+1℃
			 TempControl(TempF);//根据温度给出反应
		}
	    else if(strcmp(Received_Char_Buff,"TEMP_DOWN")==0)
		{
		  	 Temp_Down(--TempF);//-1℃
			 TempControl(TempF);//根据温度给出反应
		}
		else if(strcmp(Received_Char_Buff,"WIND_OPEN")==0)
		{
		  	 Wind_Open();
		}
		else if(strcmp(Received_Char_Buff,"WIND_CLOSE")==0)
		{
		  	 Wind_Close();
		}
		else if(strcmp(Received_Char_Buff,"LIGHT_OPEN")==0)
		{
		  	 Light_Open();
		}
		else if(strcmp(Received_Char_Buff,"LIGHT_CLOSE")==0)
		{
		  	 Light_Close();
		}
		if(flag==0)
		{
			if(strcmp(Received_Char_Buff,"RESET")==0)
			{	
			 	Ring_Open();		 
			 	flag=1;
			}
		}
				  
	  }
	  TempControl(TempF);//上位机接替控制权后也能警报
   }
}