using System;
using System.Collections.Generic;

class BinaryToDecimal
{

    private static void ConvertToDecimal(string binary)
    {
        int n = binary.Length;
        int number = 0;
        int substractor = n - 1;
        for (int index = n-1; index >=0; index--)
        {
            number = number + ((((int)(binary[index-substractor]))-48) * (int)(Math.Pow(2,index)));
            substractor = substractor - 2;
        }
        Console.WriteLine("The decimal representation is:{0}", number);
    }

    static void Main()
    {		
        string binary = "111001";
        ConvertToDecimal(binary);
        ConvertToDecimal("1010");
    }

   
}

