#include<reg51.h>
#include<intrins.h>
#include<stdio.h>
#include<stdlib.h>
#include<string.h>

#define U8INT unsigned char 
#define U16INT unsigned int 
#define U32INT unsigned long int

sbit LED1_Hot_Waring=P2^4;
sbit LED2_Cold_Waring=P2^5;
sbit LED3_Power=P2^6;
sbit LED4_Light=P2^7;

sbit WIND_IN1=P1^3;
sbit WIND_IN2=P1^4;
sbit LIGHT_IN3=P1^5;
sbit LIGHT_IN4=P1^6;

void Wind_Open();
void Wind_Close();
void Light_Open();
void Light_Close();

void Wind_Open()
{
	WIND_IN1=1;
	WIND_IN2=0;
}	
void Wind_Close()
{
	WIND_IN1=1;
	WIND_IN2=1;
}
void Light_Open()
{
	 LED4_Light=1;
	 LIGHT_IN3=1;
	 LIGHT_IN4=0;
}
void Light_Close()
{
	 LED4_Light=0;
	 LIGHT_IN3=1;
	 LIGHT_IN4=1;
}




