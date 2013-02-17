using System;
using System.Collections.Generic;
using System.Text;

class FloatingPointRepresentation
{
    private static int BreakDownIntPart(double decNum)
    {
        int intPart = Math.Abs((int)decNum);
        return intPart;
    }

    private static double BreakDownFractionPart(double decNum, int intPart)
    {
        string strFraction = decNum.ToString();
        StringBuilder fraction = new StringBuilder();
        for (int index = 0; index < strFraction.Length; index++)
        {
            if (strFraction[index] == '.')
            {
                string s = strFraction.Substring(index + 1, strFraction.Length - 1 - index);
                fraction.Append(s);
                break;
            }
        }
        fraction.Insert(0, "0.");
        double fractionPart = double.Parse(fraction.ToString());
        return fractionPart;
    }

    private static List<byte> ConvertToBinary(int decim)
    {
        List<byte> binaryIntPart = new List<byte>();
        while (decim / 2 != 0)
        {
            binaryIntPart.Insert(0, (byte)(decim % 2));
            decim = decim / 2;
        }
        binaryIntPart.Insert(0, (byte)(decim % 2));
        return binaryIntPart;
    }

    private static List<byte> ConvertFractionPartToBinary(double fractionPart)
    {
        int count = 0;
        double product = fractionPart * 2;
        List<byte> fractionBin = new List<byte>();
        while ((count < 23) && (product != 0))
        {
            count++;
            if (product >= 1)
            {
                fractionBin.Add(1);
                product = product - 1;
            }
            else
            {
                fractionBin.Add(0);
            }
            product = product * 2;
        }
        return fractionBin;
    }


    private static List<byte> GetMantissa(List<byte> binaryIntPart, List<byte> binaryFractionPart)
    {
        List<byte> mantissa = new List<byte>();
        binaryIntPart.RemoveAt(0);
        mantissa.AddRange(binaryIntPart);
        mantissa.AddRange(binaryFractionPart);
        return mantissa;
    }

    private static List<byte> GetExponent(List<byte> binaryIntPart)
    {
        List<byte> exponent = new List<byte>();
        int power = binaryIntPart.Count - 1;
        int decExp = 127 + power;
        exponent = ConvertToBinary(decExp);
        return exponent;
    }


    private static List<byte> GetBinaryNum(byte sign, List<byte> exponent, List<byte> mantissa)
    {
        List<byte> binNum = new List<byte>();
        binNum.Add(sign);
        binNum.AddRange(exponent);
        binNum.AddRange(mantissa);
        return binNum;
    }


    private static void PrintResult(List<byte> binNum)
    {
        foreach (byte num in binNum)
        {
            Console.Write(num);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        double decNum = 0.55;
        byte sign;
        if (decNum >= 0)
        {
            sign = 0;
        }
        else
        {
            sign = 1;
        }
        int intPart=BreakDownIntPart(decNum);
        double fractionPart= BreakDownFractionPart(decNum, intPart);
        List<byte> binaryIntPart=ConvertToBinary(intPart);
        List<byte> binaryFractionPart = ConvertFractionPartToBinary(fractionPart);
        List<byte> exponent=GetExponent(binaryIntPart);
        List<byte> mantissa = GetMantissa(binaryIntPart, binaryFractionPart);
        List<byte> binNum = GetBinaryNum(sign, exponent, mantissa);
        PrintResult(binNum);
    }

}

