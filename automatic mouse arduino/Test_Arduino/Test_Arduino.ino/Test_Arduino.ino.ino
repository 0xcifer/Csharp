int x,y,z;
#include <Servo.h>
Servo myservo1;//V
Servo myservo2;//H
void setup() 
{
Serial.begin(9600);
myservo1.attach(9);//V
myservo2.attach(10);//H
pinMode(A0,OUTPUT);
digitalWrite(A0,HIGH);
myservo1.write(90);
myservo2.write(90);
}

void loop() 
{
  if(Serial.available()>0)
  {
  z=Serial.parseInt();
  Serial.println(z);
  }
}
