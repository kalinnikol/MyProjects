using System;
using System.Collections.Generic;
using System.Numerics;

class SolveSeveralTasks
{
    private static byte ChooseTask()
    {
        Console.WriteLine("Make a choice between three tasks:");
        Console.WriteLine("1. Reverse the digits of a number.");
        Console.WriteLine("2. Calculate the average of a sequence of integers.");
        Console.WriteLine("3.Solve a linear equation a*x+b=0.");
        string input;
        byte task;
        do
        {
            Console.WriteLine("Enter 1, 2 or 3.");
            input = Console.ReadLine();
        }
        while ((byte.TryParse(input,out task)==false));
        return task;
    }


    private static string InputTaskOne()
    {
        string inputDecimal;
        do
        {
            Console.WriteLine("Enter a number in the decimal notation:");
            inputDecimal=Console.ReadLine();
        }
        while (int.Parse(inputDecimal)<0);

        return inputDecimal;
    }

    private static void ReverseNumber(string inputDecimal)
    {
        List<char> reverseList = new List<char>();
        for (int index = inputDecimal.Length - 1; index >= 0; index--)
        {
            reverseList.Add(inputDecimal[index]);
        }
        ListToNumber(reverseList);
    }

    private static void ListToNumber(List<char> reverseList)
    {
        int reversedNum;
        string reverseString = String.Join("", reverseList);
        reversedNum = int.Parse(reverseString);
        Console.WriteLine("The reversed number is: {0}", reversedNum);
        Console.WriteLine("**************************************");
    }

    private static int[] InputTaskTwo()
    {
        uint n;
        string input;
        do 
        {
            Console.WriteLine("Enter length of sequence:");
            input=Console.ReadLine();
        }
        while ((uint.TryParse(input, out n)==false) || (input=="0"));
        Console.WriteLine(n);
        int[] sequence = new int[n];
        for (uint index = 0; index < n; index++)
        {
            Console.WriteLine("Enter elemnt with index [{0}]", index);
            sequence[index] = int.Parse(Console.ReadLine());
        }
        return sequence;
    }

    private static void FindAverage(int[] sequence)
    {
        BigInteger sum = 0;
        for (int index = 0; index < sequence.Length; index++)
        {
            sum=sum+sequence[index];
        }
        decimal average =(decimal)(sum)/sequence.Length;
        Console.WriteLine("Average number is: {0}", average);
        Console.WriteLine("**************************************");
    }


    private static void SolveLinearEquation()
    {
        double a, b, x;
        string input;
        do 
        {
            Console.WriteLine("Enter a real number different from '0' for coefficient 'a':");
            input=Console.ReadLine();
        }
        while ((double.TryParse(input, out a)==false) || (input=="0"));
        Console.WriteLine("Enter a real number for coefficient 'b':");
        b = double.Parse(Console.ReadLine());
        x = -(b) / a;
        Console.WriteLine("x= {0}", x);
    }

    static void Main()
    {
        begin:
        byte task=ChooseTask();
        if (task == 1)
        {
            string inputDecimal = InputTaskOne();
            ReverseNumber(inputDecimal);
        }
        else if (task == 2)
        {
            int[] sequence = InputTaskTwo();
            FindAverage(sequence);
        }
        else if (task == 3)
        {
            SolveLinearEquation();
        }
        else 
        {
            goto begin;
        }
    }
}

