/* 
*  
*  Aansluitingen HCSR04 - Arduino
*  Vcc - 5V
*  Trig - 2
*  Echo - 3
*  Gnd - GND
*/ 

#include "HCSR04.h"
HCSR04 ultrasonic(2, 3); //Trig, Echo

int cm;

void setup()
{
  Serial.begin(115200);
  Serial.println("start");
}

void loop()
{
  cm = ultrasonic.Ranging(CM); //CM of INCH
  if(cm >= 0)
    Serial.println(cm);
  delay(100);
}
