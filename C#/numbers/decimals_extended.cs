//Created by Nicholas Edward Bailey 08/10/2021
//Decimals_Extended
//An extension class for decimal values

public static class Decimals_Extended //Strips unneccesary zeros after the decimal place
{
    public static decimal Normalize(this decimal value)
    {
        return value / 1.000000000000000000000000000000000m;
    }
}
