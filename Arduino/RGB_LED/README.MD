#RGB_LED
##Arduino C++ Library for working with RGB LEDs

Allows setting up of pins and simple colour changes.

Example:
```
#include RGB_LED.h

RGB_LED rgb_led(1, 2, 3); // Creates a new LED which assigns pin 1 to red, 2 to green, 3 to blue
rgb_led.Raspberry(); // Turns the LED to a raspberry colour.
```
