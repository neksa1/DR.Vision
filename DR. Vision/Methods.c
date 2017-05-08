#include <avr/io.h>
#include <avr/iom16.h>
#include <util/delay.h>
#include <avr/interrupt.h>

void Scan ()
{
	//Lcd4_Clear();
	//Lcd4_Set_Cursor(1,0);
	//Lcd4_Write_String("Scanning...");
	//if (Limit_Right == 1)
	//{
		//while (Limit_Left == 0)
		//{
			//SetPWMOutput_Left();
		//}
		//OCR0 = 0;
		////Limit_Left = 0;
		//SetPWMOutput_Right();
		//_delay_ms(1000);
		//OCR0 = 0;
		//Limit_Right = 0;
		//
		//Lcd4_Clear();
		//Lcd4_Set_Cursor(1,0);
		//Lcd4_Write_String("Scan complete");
		//_delay_ms(3000);
		//Lcd4_Clear();
		//return;
	//}
	//else if (Limit_Left == 1)
	//{
		//while (Limit_Right == 0)
		//{
			//SetPWMOutput_Right();
		//}
		//OCR0 = 0;
		//SetPWMOutput_Left();
		//_delay_ms(1000);
		//OCR0 = 0;
		//Limit_Left = 0;
		//Lcd4_Clear();
		//Lcd4_Set_Cursor(1,0);
		//Lcd4_Write_String("Scan complete");
		//_delay_ms(3000);
		//Lcd4_Clear();
		//return;
}