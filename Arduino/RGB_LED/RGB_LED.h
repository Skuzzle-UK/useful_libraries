/*
Created by and copyright of Nicholas Edward Bailey 22 / 10 / 2021
RGB_LED
Arduino C++ Library for working with RGB LEDs

Allows setting up of pins and simple colour changes.

Example:

#include RGB_LED.h

RGB_LED rgb_led(1, 2, 3); // Creates a new LED which assigns pin 1 to red, 2 to green, 3 to blue
rgb_led.Raspberry(); // Turns the LED to a raspberry colour.

*/

#pragma once
#include <Arduino.h>

class RGB_LED
{
public:
	unsigned char red = 255;
	unsigned char green = 255;
	unsigned char blue = 255;
	
	// Constructors
	RGB_LED();
	RGB_LED(unsigned char, unsigned char, unsigned char);
	RGB_LED(const RGB_LED&);
	~RGB_LED();

	// Set to pre programmed colour
	void Red(unsigned char);
	void Green(unsigned char);
	void Blue(unsigned char);
	void Red();
	void Green();
	void Blue();
	void Raspberry();
	void Cyan();
	void Magenta();
	void Yellow();
	void White();
	void Purple();
	void OFF();

	// Set custom colour
	void RGBColour(unsigned char, unsigned char, unsigned char);

private:
	unsigned char _red_pin;
	unsigned char _green_pin;
	unsigned char _blue_pin;
	void ChangeColour(); // Changes the PWM outputs the the physical LED
};

