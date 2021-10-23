//Created by and copyright of Nicholas Edward Bailey 07/10/2021
//Binary
//C# Library for working with binary numbers

using System;

public class Binary
{
    private string _value;
    public Binary() { }
    public Binary(string val) { Value = val; }

    public string Value
    {
        get { return _value; }
        set
        {
            _value = null;
            foreach (char chr in value)
            {
                if (chr.ToString() == "0" || chr.ToString() == "1")
                {
                    _value += chr.ToString();
                }
                else
                {
                    throw new ArgumentException("non binary value", nameof(value));
                }
            }
        }
    }

    public decimal ToDecimal()
    {
        decimal val = 0;
        int placevalue = 1;
        char[] chars = _value.ToCharArray();
        for (int i = chars.Length - 1; i >= 0; i--)
        {
            val += int.Parse(chars[i].ToString()) * placevalue;
            placevalue *= 2;
        }
        return val;
    }

    public decimal ToDecimal(Binary bin)
    {
        decimal val = 0;
        int placevalue = 1;
        char[] chars = bin.Value.ToCharArray();
        for (int i = chars.Length - 1; i >= 0; i--)
        {
            val += int.Parse(chars[i].ToString()) * placevalue;
            placevalue *= 2;
        }
        return val;
    }

    // @TODO make check for string is actual binary value
    // Until then use with caution
    public decimal ToDecimal(string str)
    {
        decimal val = 0;
        int placevalue = 1;
        char[] chars = str.ToCharArray();
        for (int i = chars.Length - 1; i >= 0; i--)
        {
            val += int.Parse(chars[i].ToString()) * placevalue;
            placevalue *= 2;
        }
        return val;
    }

    public static Binary ToBinary(decimal dec)
    {
        Binary value = new Binary();
        while (dec != 0)
        {
            decimal remainder = dec % 2;
            if (remainder > 0)
            {
                value.Value += "1";
            }
            else
            {
                value.Value += "0";
            }

            dec = Math.Floor(dec / 2);
        }
        char[] chars = value.Value.ToCharArray();
        Array.Reverse(chars);
        value.Value = new string(chars);
        return value;
    }
}
