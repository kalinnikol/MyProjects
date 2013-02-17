using System;
using System.Collections.Generic;
using System.Numerics;

class Factorial
{


    private static List<int> ReverseNumber(int startNum)
    {
        string inputNumber = startNum.ToString();
        List<char> reverseList = new List<char>();
        List<int> reverse = new List<int>();
        for (int index = inputNumber.Length - 1; index >= 0; index--)
        {
            reverseList.Add(inputNumber[index]);
        }
        foreach(char el in reverseList)
        {
            reverse.Add((int)el-48);
        }
         return reverse;
    }


    private static List<int> Multiply(List<int> result,List<int> reverse, List<int> revMul)
    {
        List<int> resultOne= new List<int>();
        List<int> resultTwo = new List<int>();
        int transfer = 0;
        for (int inner = 0; inner < reverse.Count; inner++)
        {
            resultOne.Add((revMul[0] * reverse[inner] + transfer) % 10);
            transfer = ((revMul[0] * reverse[inner] + transfer)) / 10;
        }
        if (transfer > 0)
        {
            resultOne.Add(transfer);
        }
        if (revMul.Count>1)
        {
            transfer = 0;
            resultTwo.Add(0);
            for (int inner = 0; inner < reverse.Count; inner++)
            {
                resultTwo.Add((revMul[1] * reverse[inner] + transfer) % 10);
                transfer = revMul[1] * reverse[inner] / 10;
            }
            if (transfer > 0)
            {
                resultTwo.Add(transfer);
            }
        }
        result = AddNumbers(resultOne, resultTwo);
        return result;
    }

    private static List<int> AddNumbers(List<int> firstInt, List<int> secondInt)
    {
        int stop;
        if (firstInt.Count > secondInt.Count)
        {
            stop = firstInt.Count - secondInt.Count;
            for (int count = 1; count <= stop; count++)
            {
                secondInt.Add(0);
            }
        }
        else if (secondInt.Count > firstInt.Count)
        {
            stop = secondInt.Count - firstInt.Count;
            for (int count = 1; count <= stop; count++)
            {
                firstInt.Add(0);
            }
        }

        List<int> result = new List<int>();
        int transfer = 0;
        int sum = 0;
        for (int index = 0; index < (Math.Max(firstInt.Count, secondInt.Count)); index++)
        {
            sum = (firstInt[index] + secondInt[index]) % 10 + transfer;
            transfer = (firstInt[index] + secondInt[index]) / 10;
            result.Add(sum);
        }
        if (transfer != 0)
        {
            result.Add(transfer);
        }
        return result;
    }

    private static BigInteger GetNumber(List<int> result)
    {
        BigInteger factoriel;
        List<int> factList = new List<int>();
        foreach (int el in result)
        {
            factList.Insert(0,el);
        }
        string num = String.Join("",factList);
        factoriel = BigInteger.Parse(num);
        return factoriel;
    }

    static void Main()
    {
        int startNum = 100;
        int multiplier = startNum - 1;
        List<int> reverse = ReverseNumber(startNum);
        List<int> revMul = ReverseNumber(multiplier);
        List<int> result = new List<int>();
        result = Multiply(result, reverse, revMul);
        while (multiplier > 2) 
        {
            multiplier--;
            revMul = ReverseNumber(multiplier);
            result = Multiply(result, result, revMul);
        }
        BigInteger factoriel = GetNumber(result);
        Console.WriteLine(factoriel);
    }

   
}

