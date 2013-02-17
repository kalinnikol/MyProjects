using System;
using System.Collections.Generic;
using System.Linq;

class SieveOfEratosthenes
{
    static void Main()
    {
        bool[] boolArray = new bool[10000000];
        int n= boolArray.Length;
        for (int outerIndex = 2; outerIndex <= Math.Sqrt(n); outerIndex++)
        {
            if (boolArray[outerIndex] == false)
            {
                for (int innerIndex = (outerIndex * outerIndex); innerIndex < n; innerIndex += outerIndex)
                {
                    boolArray[innerIndex] = true;
                }
            }
        }
        for (int index = 2; index < n; index++)
        {
            if (boolArray[index] == false)
            {
                Console.Write("{0} ", index);
            }
        }
    }
}

