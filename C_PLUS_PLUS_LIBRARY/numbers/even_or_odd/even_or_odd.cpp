#include "even_or_odd.h"

bool Even_Or_Odd::Even(int n)
{
	if (n % 2 == 0) {
		return true;
	}
	return false;
}

bool Even_Or_Odd::Odd(int n)
{
	if (n % 2 == 0) {
		return false;
	}
	return true;
}
