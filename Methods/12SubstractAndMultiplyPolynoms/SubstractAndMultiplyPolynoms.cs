using System;
using System.Collections.Generic;

class SubstractAndMultiplyPolynoms
{
    private static void PrintResult(List<double> polynom)
    {
        if (polynom[polynom.Count - 1] != 0)
        {
            Console.Write("{0}.x^{1} ", polynom[polynom.Count - 1], polynom.Count - 1);
        }
        for (int count = polynom.Count - 2; count > 0; count--)
        {
            if (polynom[count] != 0)
            {
                if (polynom[count] >0)
                {
                    Console.Write("+ ");
                }
                Console.Write("{0}.x^{1} ", polynom[count], count);
            }
        }
        if (polynom[0] != 0)
        {
            if (polynom[0] > 0)
            {
                Console.Write("+");
            }
            Console.Write(" {0}", polynom[0], 0);
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

    private static void SubstractTwoPolynoms(List<double> polynomOne, List<double> polynomTwo)
    {
        List<double> substrResult = new List<double>();
        if (polynomOne.Count > polynomTwo.Count)
        {
            while (polynomOne.Count > polynomTwo.Count)
            {
                polynomTwo.Add(0);
            }
        }
        if (polynomTwo.Count > polynomOne.Count)
        {
            while (polynomTwo.Count > polynomOne.Count)
            {
                polynomOne.Add(0);
            }
        }
        for (int index = 0; index < polynomOne.Count; index++)
        {
            substrResult.Add(polynomOne[index] - polynomTwo[index]);
        }
        PrintResult(substrResult);
    }


    private static void MultiplyTwoPolynoms(List<double> polynomOne, List<double> polynomTwo)
    {
       
        if (polynomOne.Count > polynomTwo.Count)
        {
            while (polynomOne.Count > polynomTwo.Count)
            {
                polynomTwo.Add(0);
            }
        }
        if (polynomTwo.Count > polynomOne.Count)
        {
            while (polynomTwo.Count > polynomOne.Count)
            {
                polynomOne.Add(0);
            }
        }
        double[] multiplyResult=new double[2*polynomOne.Count-1];
        multiplyResult[0]=polynomOne[0]*polynomTwo[0];
        for (int coefNum = 1; coefNum <= polynomOne.Count - 1; coefNum++)
        {
            for (int upper = 0; upper <= coefNum; upper++)
            {
                for (int lower=0; lower<=upper; lower++)
                {
                    if (upper + lower == coefNum)
                    {
                        multiplyResult[coefNum]=multiplyResult[coefNum]+polynomOne[lower]*polynomTwo[upper]+polynomTwo[lower]*
                            polynomOne[upper];
                    }
                }
            }
        }

        for (int coefNum = polynomOne.Count; coefNum < 2*polynomOne.Count - 2; coefNum++)
        {
            for (int upper = 0; upper <= polynomOne.Count-1; upper++)
            {
                for (int lower = 0; lower <= upper; lower++)
                {
                    if (upper + lower == coefNum)
                    {
                        multiplyResult[coefNum] = multiplyResult[coefNum] + polynomOne[lower] * polynomTwo[upper] + polynomTwo[lower] *
                            polynomOne[upper];
                        if (upper == lower)
                        {
                            multiplyResult[coefNum] = multiplyResult[coefNum] - polynomOne[lower] * polynomTwo[upper];
                        }
                    }
                }
            }
        }
        multiplyResult[multiplyResult.Length-1] = polynomOne[polynomOne.Count-1] * polynomTwo[polynomTwo.Count-1];

        List<double> multiply = new List<double>();
        multiply.AddRange(multiplyResult);
        PrintResult(multiply);
    }

    static void Main()
    {
        List<double> polynomOne = new List<double>() { 3, -1, 0, 7 };//3x^3-1x^2+0x+7
        List<double> polynomTwo = new List<double>() { -7, -12, 4 };//-7x^2-12x+4
        polynomOne = ReversePolynom(polynomOne);
        polynomTwo = ReversePolynom(polynomTwo);
        PrintResult(polynomOne);
        PrintResult(polynomTwo);
        //this method will substract the first polynom from the second
        SubstractTwoPolynoms(polynomOne, polynomTwo);
        MultiplyTwoPolynoms(polynomOne, polynomTwo);
    }

    
}

