using System;
using System.Collections.Generic;

class SignedShortToBinary
{
    private static List<byte> ConvertDecimalToBinary(int numToConvert)
    {
        List<byte> binary = new List<byte>();
        while (numToConvert / 2 != 0)
        {
            binary.Insert(0,(byte)(numToConvert%2));
            numToConvert = numToConvert/2;
        }
        binary.Insert(0, (byte)(numToConvert % 2));
        return binary;
    }

    private static void PrintResult(List<byte> binary)
    {
        foreach (byte num in binary)
        {
            Console.Write("{0}", num);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int numToConvert = -32767;
        List<byte> binary= new List<byte>();
        if (numToConvert >= 0)
        {
             binary=ConvertDecimalToBinary(numToConvert);
        }
        else
        {
            numToConvert = (int)(Math.Pow(2,15))-(Math.Abs(numToConvert));
            binary=ConvertDecimalToBinary(numToConvert);
            int stop= 15-binary.Count;
            for (int count=1; count<=stop; count++)
            {
                binary.Insert(0, 0);
            }
            binary.Insert(0,1);
        }
        PrintResult(binary);
    }
}

