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

#include "RGB_LED.h"

// Standard Constructor
RGB_LED::RGB_LED() {}

// Constructor with pin assignment
RGB_LED::RGB_LED(unsigned char red_pin, unsigned char green_pin, unsigned char blue_pin) {
	_red_pin = red_pin;
	_green_pin = green_pin;
	_blue_pin = blue_pin;
	pinMode(_red_pin, OUTPUT);
	pinMode(_green_pin, OUTPUT);
	pinMode(_blue_pin, OUTPUT);
	ChangeColour();
}

// Copy constructor
RGB_LED::RGB_LED(const RGB_LED& rgb_led) {
	_red_pin = rgb_led._red_pin;
	_green_pin = rgb_led._green_pin;
	_blue_pin = rgb_led._blue_pin;
	pinMode(_red_pin, OUTPUT);
	pinMode(_green_pin, OUTPUT);
	pinMode(_blue_pin, OUTPUT);
	RGBColour(rgb_led.red, rgb_led.green, rgb_led.blue);
	ChangeColour();
}

// Destructor
RGB_LED::~RGB_LED() {
	pinMode(_red_pin, HIGH);
	pinMode(_green_pin, HIGH);
	pinMode(_blue_pin, HIGH);
}

// Changes intensity of colour
void RGB_LED::Red(unsigned char val) {
	red = val;
	ChangeColour();
}
void RGB_LED::Green(unsigned char val) {
	green = val;
	ChangeColour();
}
void RGB_LED::Blue(unsigned char val) {
	blue = val;
	ChangeColour();
}
//


// Set to pre programmed colour
void RGB_LED::Red() {
	red = 255;
	green = 0;
	blue = 0;
	ChangeColour();
}
void RGB_LED::Green() {
	red = 0;
	green = 255;
	blue = 0;
	ChangeColour();
}
void RGB_LED::Blue() {
	red = 0;
	green = 0;
	blue = 255;
	ChangeColour();
}
void RGB_LED::Raspberry() {
	red = 255;
	green = 255;
	blue = 125;
	ChangeColour();
}
void RGB_LED::Cyan() {
	red = 0;
	green = 255;
	blue = 255;
	ChangeColour();
}
void RGB_LED::Magenta() {
	red = 255;
	green = 0;
	blue = 255;
	ChangeColour();
}
void RGB_LED::Yellow() {
	red = 255;
	green = 255;
	blue = 0;
	ChangeColour();
}
void RGB_LED::White() {
	red = 255;
	green = 255;
	blue = 255;
	ChangeColour();
}
void RGB_LED::Purple() {
	red = 170;
	green = 0;
	blue = 255;
	ChangeColour();
}
void RGB_LED::OFF() {
	red = 0;
	green = 0;
	blue = 0;
	ChangeColour();
}
//

// Set custom colour
void RGB_LED::RGBColour(unsigned char red_val, unsigned char green_val, unsigned char blue_val) {
	red = red_val;
	green = green_val;
	blue = blue_val;
	ChangeColour();
}

// Changes the PWM output value to change the colour of the physical LED
void RGB_LED::ChangeColour() {
	analogWrite(_red_pin, red);
	analogWrite(_green_pin, green);
	analogWrite(_blue_pin, blue);
}