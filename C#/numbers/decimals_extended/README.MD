# decimals_extended
C# class that extends the decimal variable with useful functions.

## Functions:
### Normalize()
Strips a decimal value of excess zeros.

### Usage Example:
```
decimal val = 1.1000000000;
val = val.Normalize();
// val now equals 1.1 as Normalize strips it of excess zeros.
```
