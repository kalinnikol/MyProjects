using System;
using System.Collections.Generic;

class ElementsMaxSum
{
    static void Main()
    {
        Console.WriteLine("Enter length of the array:");
        string line = Console.ReadLine();
        int n = int.Parse(line);
        Console.WriteLine("Enter number of numbers to sum:");
        line = Console.ReadLine();
        int k = int.Parse(line);
        int maxNum = Int32.MinValue;
        int positionMaxNum = 0;
        int maxSum = 0;
        List<int> numbers = new List<int>();
        for (int index = 0; index <= n - 1; index++)
        {
            Console.WriteLine("Enter number on position [{0}]", index);
            line = Console.ReadLine();
            numbers.Add(int.Parse(line));
        }
        for (int countAdder = 1; countAdder <= k; countAdder++)
        {
            for (int index = 0; index <= numbers.Count-1; index++)
            {
                if (numbers[index] > maxNum)
                {
                    maxNum = numbers[index];
                    positionMaxNum = index;
                }
            }
            maxSum += maxNum;
            numbers.Remove(maxNum);
            if (countAdder < k)
            {
                Console.Write("{0} + ", maxNum);
            }
            else 
            {
                Console.WriteLine("{0}", maxNum);
            }
            maxNum = Int32.MinValue;
        }
        Console.WriteLine("The maximal sum is: {0}", maxSum);
    }
}

