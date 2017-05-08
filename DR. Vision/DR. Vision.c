#ifndef F_CPU
#define F_CPU 8000000UL // 8 MHz clock speed
#endif

//#define FOSC 8000000//1843200// Clock Speed
//#define BAUD 56000//9600
//#define MYUBRR FOSC/16/BAUD-1
#define MYUBRR 0x00C //38400

#define D4 eS_PORTD4
#define D5 eS_PORTD5
#define D6 eS_PORTD6
#define D7 eS_PORTD7
#define RS eS_PORTC5
#define EN eS_PORTC7

#include <avr/io.h>
#include <avr/iom16.h>
#include <util/delay.h>
//#include <string.h>
//#include <stdio.h>
//#include <avr/pgmspace.h>
//#include <stdlib.h>
//#include <avr/wdt.h>
#include <avr/interrupt.h>
#include <stdbool.h>
#include "lcd.h"
//#include <stdint.h>
//#include <inttypes.h>
//#include <avr/sleep.h> 


void USART_Init( unsigned int ubrr);
void USART_Transmit( unsigned char data );
unsigned char USART_Receive( void );
void Init_position();

int temp = 0;
unsigned char Ret = 0;
volatile uint8_t overflow = 0;
unsigned char Limit_Right = 0;
unsigned char Limit_Left = 0;
unsigned char STOP_command = 0;
const unsigned char Scan_Complete[] = {0xAC, 0x44, 0x88};
bool flag_resumeLeft = false;
bool flag_resumeRight = false;

ISR(USART_RXC_vect)
{
	cli();
	Ret = Check_MSG();
	_delay_ms(30);
	if (Ret == 0x11)
	{
		//Lcd4_Clear();
		//Lcd4_Set_Cursor(1,0);
		//Lcd4_Write_String("RIGHT");
		//_delay_ms(2000);
		STOP_command = 1;
		Ret = 0;
	}
	//char ReceivedByte;
	//ReceivedByte = UDR;
	//UDR = ReceivedByte;
	sei();
}
ISR(TIMER1_OVF_vect)
{
	overflow++;
	cli();
	if (overflow >= 5) // NOTE: '>=' used instead of '=='
	{
		if (!(bit_is_clear(PINA, PA2)))//Right
		{
			//Lcd4_Clear();
			//Lcd4_Set_Cursor(1,0);
			//Lcd4_Write_String("RIGHT");
			Limit_Right = 1;
			overflow = 0;
			sei();
			return;
		}
		else if (!(bit_is_clear(PINA, PA1)))//Left
		{
			//Lcd4_Clear();
			//Lcd4_Set_Cursor(1,0);
			//Lcd4_Write_String("LEFT");
			Limit_Left = 1;
			overflow = 0;
			sei();
			return;
		}
		overflow = 0;
	}
	sei();
}
void SetPWMOutput_Left()
{
	OCR0=240;//duty;//0-255
	DDRB = 0xFF;
	//PORTB = (0<<PB0);//= 0b00000000;
	PORTB = ((0<<PB0) | (1<<PB1));
}
void SetPWMOutput_Lefttotal()
{
	OCR0=255;//duty;//0-255
	DDRB = 0xFF;
	//PORTB = (0<<PB0);//= 0b00000000;
	PORTB = ((0<<PB0) | (1<<PB1));
}
void SetPWMOutput_Right()
{
	OCR0 = 240;//100//duty;//0-255
	DDRB = 0xFF;
	//PORTB |= (1<<PB0);//= 0b00000000;
	PORTB = ((0<<PB1) | (1<<PB0));
}
void SetPWMOutput_Righttotal()
{
	OCR0 = 255;//100//duty;//0-255
	DDRB = 0xFF;
	//PORTB |= (1<<PB0);//= 0b00000000;
	PORTB = ((0<<PB1) | (1<<PB0));
}

int main(void)
{
	Init();
	InitTimer1();
	USART_Init ( MYUBRR );
	Lcd4_Init();
	
	Init_position();
	
	_delay_ms(50);
	Lcd4_Clear();
	
	while(1)
	{
		Lcd4_Set_Cursor(1,0);
		Lcd4_Write_String("DR. Vision");
		Lcd4_Set_Cursor(2,0);
		Lcd4_Write_String("READY");
		if (Ret == 0x11)
		{
			Lcd4_Clear();
			Lcd4_Set_Cursor(1,0);
			Lcd4_Write_String("STOP");
			OCR0 = 0;
			//PORTB = (0<<PB0);
			PORTB = ((0<<PB0) | (0<<PB1));
			Ret = 0;
		}
		if (Ret == 0x22)
		{
			Lcd4_Clear();
			Lcd4_Set_Cursor(1,0);
			Lcd4_Write_String("Scanning...");
			if ((Limit_Right == 1) | (flag_resumeLeft == true))
			{
				while (Limit_Left == 0 && STOP_command == 0)
				{
					SetPWMOutput_Left();
				}
				OCR0 = 0;
				if (STOP_command == 0)
				{
					SetPWMOutput_Right();
				}
				_delay_ms(300);
				OCR0 = 0;        //stop
				//PORTB = (0<<PB0);//stop
				PORTB = ((0<<PB0) | (0<<PB1));
				Limit_Right = 0;
				if (STOP_command == 1)
				{
					STOP_command = 0;
					Ret = 22;
					flag_resumeLeft = true;
					continue;	
				}
				
				Lcd4_Clear();
				Lcd4_Set_Cursor(1,0);
				Lcd4_Write_String("Scan complete");
				_delay_ms(2000);
				for (int i = 0; i < 3; i++)
				{
					USART_Transmit(Scan_Complete[i]);
					_delay_ms(30);
				}
				Lcd4_Clear();
				Ret = 0;
				flag_resumeLeft = false;
				continue;
			}
			else if ((Limit_Left == 1) | (flag_resumeRight == true))
			{
				while (Limit_Right == 0 && STOP_command == 0)
				{
					SetPWMOutput_Right();
				}
				OCR0 = 0;
				if (STOP_command == 0)
				{
					SetPWMOutput_Left();
				}
				_delay_ms(300);
				OCR0 = 0;        //stop
				//PORTB = (0<<PB0);//stop
				PORTB = ((0<<PB0) | (0<<PB1));
				Limit_Left = 0;
				if (STOP_command == 1)
				{
					STOP_command = 0;
					Ret = 22;
					flag_resumeRight = true;
					continue;
				}
				Lcd4_Clear();
				Lcd4_Set_Cursor(1,0);
				Lcd4_Write_String("Scan complete");
				_delay_ms(2000);
				for (int i = 0; i < 3; i++)
				{
					USART_Transmit(Scan_Complete[i]);
					_delay_ms(30);
				}
				Lcd4_Clear();
				Ret = 0;
				flag_resumeRight = false;
				continue;
			}
			//Ret = 0;
		}
		if (Ret == 0x88)//left
		{
			SetPWMOutput_Left();
			_delay_ms(270);
			OCR0 = 0;        //stop
			//PORTB = (0<<PB0);//stop
			PORTB = ((0<<PB0) | (0<<PB1));
			Ret = 0;
		}
		if (Ret == 0x99)//right
		{
			SetPWMOutput_Right();
			_delay_ms(270);
			OCR0 = 0;        //stop
			//PORTB = (0<<PB0);//stop
			PORTB = ((0<<PB0) | (0<<PB1));
			Ret = 0;
		}
		if (Ret == 0xFF)
		{
			Lcd4_Clear();
			Lcd4_Set_Cursor(1,0);
			Lcd4_Write_String("ERROR");
			Ret = 0;
		}
		if (Ret == 0x66)  // total left
		{
			Lcd4_Clear();
			Lcd4_Set_Cursor(1,0);
			Lcd4_Write_String("Left");
			while (Limit_Right == 0 && STOP_command == 0)
			{
				OCR0 = 255;
				SetPWMOutput_Righttotal();
			}
			OCR0 = 0;
			if (STOP_command == 0)
			{
				SetPWMOutput_Left();
			}
			_delay_ms(250);
			OCR0 = 0;        //stop
			//PORTB = (0<<PB0);//stop
			PORTB = ((0<<PB0) | (0<<PB1));
			Limit_Left = 0;
			if (STOP_command == 1)
			{
				STOP_command = 0;
				Ret = 0;
				continue;
			}
			Lcd4_Clear();
			Lcd4_Set_Cursor(1,0);
			Lcd4_Write_String("Left position");
			_delay_ms(1000);
			for (int i = 0; i < 3; i++)
			{
				USART_Transmit(Scan_Complete[i]);
				_delay_ms(30);
			}
			Lcd4_Clear();
			Ret = 0;
			continue;
			
		}
		if (Ret == 0x44) // total right
		{
			Lcd4_Clear();
			Lcd4_Set_Cursor(1,0);
			Lcd4_Write_String("Right");
			while (Limit_Left == 0 && STOP_command == 0)
			{
				OCR0 = 255;
				SetPWMOutput_Lefttotal();
			}
			OCR0 = 0;
			if (STOP_command == 0)
			{
				SetPWMOutput_Right();
			}
			_delay_ms(300);
			OCR0 = 0;        //stop
			//PORTB = (0<<PB0);//stop
			PORTB = ((0<<PB0) | (0<<PB1));
			Limit_Right = 0;
			if (STOP_command == 1)
			{
				STOP_command = 0;
				Ret = 0;
				continue;
			}
			
			Lcd4_Clear();
			Lcd4_Set_Cursor(1,0);
			Lcd4_Write_String("Right position");
			_delay_ms(1000);
			for (int i = 0; i < 3; i++)
			{
				USART_Transmit(Scan_Complete[i]);
				_delay_ms(30);
			}
			Lcd4_Clear();
			Ret = 0;
			continue;
		}
		
		//USART_Transmit(0xBB);
		//itoa(temp, MyWeight, 10);
	}
}

void Init()
{
	DDRD = 0xFF;//display
	DDRC = 0xFF;
	
	DDRA = 0xFF;//limits
	PORTA =0x00;
	
	TCCR0|=(1<<WGM00)|(1<<WGM01)|(1<<COM01)|(1<<CS00);//pwm
	//DDRB|=(1<<PB3);
	DDRB = 0xFF;
	PORTB = 0x00;
	//PORTB = (0<<PB0);//= 0b00000000;
	
	//CLK        DT
	//DDRB = (1<<PB0) | (0<<PB4);// Cell Right
	//PORTB =(1<<PB0) | (0<<PB4);
}
void InitTimer1()
{
	TCCR1B |= (1 << CS10);// set up timer with prescaler = 8
	TCNT1 = 0;            // initialize counter
	TIMSK |= (1 << TOIE1);// enable overflow interrupt
	//overflow = 0;         // initialize overflow counter variable
}

void USART_Init( unsigned int ubrr)
{
	UBRRH = (unsigned char)(ubrr>>8);       // Set baud rate
	UBRRL = (unsigned char)ubrr;            // Set baud rate
	UCSRB=(1<<RXEN)|(1<<TXEN)|(1<<RXCIE);
	UCSRC = (1 << URSEL) | (1 << UCSZ0) | (1 << UCSZ1); // Use 8-bit character sizes
	
	//set_sleep_mode(SLEEP_MODE_IDLE);
	sei();
}

void USART_Transmit( unsigned char data )
{
	while ( !( UCSRA & (1<<UDRE)) );        // Wait for empty transmit buffer
	UDR = data;                             // Put data into buffer, sends the data
}

unsigned char USART_Receive( void )
{
	while ( !(UCSRA & (1<<RXC)) );          // Wait for data to be received
	return UDR;                             // Get and return received data from buffer
}

void Init_position()
{
	Lcd4_Clear();
	Lcd4_Set_Cursor(1,0);
	Lcd4_Write_String("Init Position");
	
	while (Limit_Right == 0)
	{
		Lcd4_Clear();
		Lcd4_Set_Cursor(1,0);
		Lcd4_Write_String("Moving left");
		SetPWMOutput_Right();
	}
	OCR0 = 0;
	//Limit_Right = 0;
	Lcd4_Clear();
	Lcd4_Set_Cursor(1,0);
	Lcd4_Write_String("Moving right");
	SetPWMOutput_Left();
	_delay_ms(340);
	OCR0 = 0;
}