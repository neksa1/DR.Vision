
#include <avr/io.h>
#include <avr/iom16.h>
#include <avr/interrupt.h>
#include <util/delay.h>

#define STOP 0x11
#define START 0x22
#define ERROR 0xFF
#define LEFT 0x88
#define RIGHT 0x99
#define TOTALLEFT 0x44
#define TOTALRIGHT 0x66
// AB 11 99 START

const unsigned char Receive_OK[] = {0xAC, 0x22, 0x88};
const unsigned char Receive_FAIL[] = {0xAC, 0x33, 0x88};
unsigned char Receive[3];

unsigned char Check_MSG()
{
	for (int i = 0; i < 3; i++)
	{
		Receive[i] = USART_Receive();
	}
	if (Receive[0] == 0xAB && Receive[1] == 0x11 && Receive[2] == 0x99)
	{
		for (int i = 0; i < 3; i++)
		{
			USART_Transmit(Receive_OK[i]);
			_delay_ms(30);
		}
		return START;
	}
	else if (Receive[0] == 0xAB && Receive[1] == 0x00 && Receive[2] == 0x99)
	{
		for (int i = 0; i < 3; i++)
		{
			USART_Transmit(Receive_FAIL[i]);
			_delay_ms(30);
		}
		return STOP;
	}
	else if (Receive[0] == 0x88 && Receive[1] == 0x88 && Receive[2] == 0x88)
	{
		Receive[0] = 0;
		Receive[1] = 0;
		Receive[2] = 0;
		return LEFT;
	}
	else if (Receive[0] == 0x99 && Receive[1] == 0x99 && Receive[2] == 0x99)
	{
		return RIGHT;
	}
	else if (Receive[0] == 0x44 && Receive[1] == 0x44 && Receive[2] == 0x44)
	{
		return TOTALLEFT;
	}
	else if (Receive[0] == 0x66 && Receive[1] == 0x66 && Receive[2] == 0x66)
	{
		return TOTALRIGHT;
	}
	else return ERROR;
	
}