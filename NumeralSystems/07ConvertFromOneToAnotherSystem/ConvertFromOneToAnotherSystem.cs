using System;
using System.Collections.Generic;
using System.Linq;

class ConvertFromOneToAnotherSystem
{

    private static int FromStartBaseToDec(string numInStartBase, int startBase)
    {
        int n = numInStartBase.Length;
        int decNumber = 0;
        int substractor = n - 1;
        for (int index = n - 1; index >= 0; index--)
        {
            int adder = CheckAdder(index, numInStartBase, substractor, startBase);
            decNumber = decNumber + adder;
            substractor = substractor - 2;
        }
        return decNumber;
    }

    private static int CheckAdder(int index, string numInStartBase, int substractor, int startBase)
    {
        int adder;
        if (numInStartBase[index - substractor] == 'A')
        {
            adder = 10;
        }
        else if (numInStartBase[index - substractor] == 'B')
        {
            adder = 11;
        }
        else if (numInStartBase[index - substractor] == 'C')
        {
            adder = 12;
        }
        else if (numInStartBase[index - substractor] == 'D')
        {
            adder = 13;
        }
        else if (numInStartBase[index - substractor] == 'E')
        {
            adder = 14;
        }
        else if (numInStartBase[index - substractor] == 'F')
        {
            adder = 15;
        }
        else
        {
            adder = (int)(numInStartBase[index - substractor]) - 48;
        }
        adder = adder * (int)(Math.Pow(startBase, index));
        return adder;
    }

    private static void FromDecToEndBase(int endBase, int decNumber)
    {
        List<string> numInEndBase = new List<string>();
        while (decNumber / endBase != 0)
        {
            CheckRemaining(decNumber, numInEndBase, endBase);
            decNumber = decNumber / endBase;
        }
        CheckRemaining(decNumber, numInEndBase,endBase);
        foreach (string num in numInEndBase)
        {
            Console.Write("{0}", num);
        }
        Console.WriteLine();
    }

    private static void CheckRemaining(int decNumber, List<string> numInEndBase, int endBase)
    {
        if (decNumber %  endBase== 15)
        {
            numInEndBase.Insert(0, "F");
        }
        else if (decNumber % endBase == 14)
        {
            numInEndBase.Insert(0, "E");
        }
        else if (decNumber % endBase == 13)
        {
            numInEndBase.Insert(0, "D");
        }
        else if (decNumber % endBase == 12)
        {
            numInEndBase.Insert(0, "C");
        }
        else if (decNumber % endBase == 11)
        {
            numInEndBase.Insert(0, "B");
        }
        else if (decNumber % endBase == 10)
        {
            numInEndBase.Insert(0, "A");
        }
        else
        {
            numInEndBase.Insert(0, (decNumber % 16).ToString());
        }
    }

    static void Main()
    {
        int startBase = 8;
        int endBase = 16;
        string numInStartBase = "6470";
        int decNumber=FromStartBaseToDec(numInStartBase,startBase);
        if (endBase != 10)
        {
            FromDecToEndBase(endBase, decNumber);
        }
    }
}

