using System;
using System.Collections.Generic;

class HexadecimalToDecimal
{

    private static void FromHexToDec(string hexadecimal)
    {
        int n = hexadecimal.Length;
        int number = 0;
        int substractor = n - 1;
        for (int index = n - 1; index >= 0; index--)
        {
            int adder=CheckAdder(index,hexadecimal, substractor);
            number = number + adder;
            substractor = substractor - 2;
        }
        Console.WriteLine("The decimal representation is:{0}", number);
    }

    private static int CheckAdder( int index, string hexadecimal,int substractor)
    {
        int adder;
        if (hexadecimal[index-substractor] == 'A')
        {
            adder = 10;
        }
        else if (hexadecimal[index-substractor] == 'B')
        {
            adder = 11;
        }
        else if (hexadecimal[index-substractor] == 'C')
        {
            adder = 12;
        }
        else if (hexadecimal[index-substractor] == 'D')
        {
            adder = 13;
        }
        else if (hexadecimal[index-substractor] == 'E')
        {
            adder = 14;
        }
        else if (hexadecimal[index-substractor] == 'F')
        {
            adder = 15;
        }
        else
        {
            adder = (int)(hexadecimal[index-substractor])-48;
        }
        adder = adder * (int)(Math.Pow(16, index));
        return adder;
    }

    static void Main()
    {
        FromHexToDec("BDA");
    }
}

