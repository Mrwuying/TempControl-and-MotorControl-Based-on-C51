#include<reg51.h>
#include<intrins.h>
#include<stdio.h>
#include<stdlib.h>
#include<string.h>

#define U8INT unsigned char 
#define U16INT unsigned int 
#define U32INT unsigned long int
#define LCD_Port P0
 

sbit RS=P2^0;
sbit RW=P2^1;
sbit EN=P2^2;
sbit LED1_Hot_Waring=P2^4;
sbit LED2_Cold_Waring=P2^5;
sbit LED3_Power=P2^6;
sbit LED4_Light=P2^7;

void delay_ms(U16INT x)
{
  U8INT i=0;
  while(x--)
  {
  for(i=0;i<120;i++);
  }
}

void Busy_Wait()
{
	U8INT LCD_Status=0x00;
	do
	{
   		LCD_Port=0xFF;
		EN=0;RS=0;RW=1;
		EN=1;_nop_();
		LCD_Status=LCD_Port;
		EN=0;_nop_();	   
	}while(LCD_Status&0x80);
}
void LCD_Write_CMD(U8INT cmd)
{		
	Busy_Wait();
    EN=0;RS=0;RW=0;
    LCD_Port=cmd;
	EN=1;_nop_();	
	EN=0;_nop_();
	Busy_Wait();
}
void LCD_Write_Data(U8INT dat)
{		
	Busy_Wait();
    EN=0;RS=1;RW=0;
    LCD_Port=dat;
	EN=1;_nop_();	
	EN=0;_nop_();
	Busy_Wait();
}
void LCD_Init()
{
	LCD_Write_CMD(0x38); 
	LCD_Write_CMD(0x0C); 
	LCD_Write_CMD(0x06);
	LCD_Write_CMD(0x01);
	LED1_Hot_Waring=0;  
	LED2_Cold_Waring=0;
	LED3_Power=1;
	LED4_Light=0;
}
void Display_String(U8INT row,U8INT col,U8INT *str)
{
	U8INT UD_ADD[]={0x80,0xC0};
	U8INT i=0x00;
	LCD_Write_CMD(UD_ADD[row]|col);
	for(i=0;i<16&&str[i];i++)
	{
 		LCD_Write_Data(str[i]);
	}  
	for(;i<16;i++)
	{
 		LCD_Write_Data(' ');
	}
}












