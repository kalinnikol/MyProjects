using System;
using System.Collections.Generic;

class PolynomialsAdd
{
    private static void PrintResult(List<double> polynom)
    {
        if (polynom[polynom.Count - 1] != 0)
        {
            Console.Write("{0}.x^{1}", polynom[polynom.Count - 1], polynom.Count - 1);
        }
        for (int count = polynom.Count - 2; count > 0; count--)
        {
            if (polynom[count] != 0)
            {
                Console.Write(" + {0}.x^{1}", polynom[count], count);
            }
        }
        if (polynom[0] != 0)
        {
            Console.Write(" + {0}", polynom[0], 0);
        }
        Console.WriteLine();
    }

    private static List<double> ReversePolynom(List<double> polynomOne)
    {
        List<double> result = new List<double>();
        int repeat = polynomOne.Count;
        for (int count = 0; count < repeat; count++)
        {
            double coefficient = polynomOne[0];
            polynomOne.RemoveAt(0);
            result.Insert(0, coefficient);
            
        }
        polynomOne.Clear();
        polynomOne.AddRange(result);
        return polynomOne;
    }

    private static void AddTwoPolynoms(List<double> polynomOne, List<double> polynomTwo)
    {
        List<double> addResult = new List<double>();
        if (polynomOne.Count > polynomTwo.Count)
        {
            while (polynomOne.Count > polynomTwo.Count)
            {
                polynomTwo.Add(0);
            }
        }
        if (polynomTwo.Count>polynomOne.Count)
        {
            while (polynomTwo.Count > polynomOne.Count)
            {
                polynomOne.Add(0);
            }
        }
        for (int index = 0; index < polynomOne.Count; index++)
        {
            addResult.Add(polynomOne[index]+polynomTwo[index]);
        }
        PrintResult(addResult);
    }


    static void Main()
    {
        List<double> polynomOne = new List<double>() {3, -1, 12, 7 };//3x^3-1x^2+0x+7
        List<double> polynomTwo = new List<double>() {  -7, -12, 4 };//-7x^2-12x+4
        polynomOne= ReversePolynom(polynomOne);
        polynomTwo = ReversePolynom(polynomTwo);
        PrintResult(polynomOne);
        PrintResult(polynomTwo);
        AddTwoPolynoms(polynomOne, polynomTwo);
    }

    
    

   
}

