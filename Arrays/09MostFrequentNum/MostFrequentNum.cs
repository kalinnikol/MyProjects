using System;

class MostFrequentNum
{
    static void Main()
    {
        Console.WriteLine("Enter length of the array:");
        string line = Console.ReadLine();
        int n = int.Parse(line);
        int[] numbers= new int[n];
        for (int index = 0; index <= n - 1; index++)
        {
            Console.WriteLine("Enter value of Array[{0}]", index);
            line = Console.ReadLine();
            numbers[index] = int.Parse(line);
        }
        int currentNum = 0;
        int mostFrequent = 0;
        int currentRepet = 0;
        int mostFreqRepet = 0;

        for (int outerIndex = 0; outerIndex <= n - 1; outerIndex++)
        {
            currentRepet=1;
            for (int innerIndex = outerIndex+1; innerIndex <= n - 1; innerIndex++)
            {
                if (numbers[outerIndex] == numbers[innerIndex])
                {
                    currentRepet++;
                }
            }
            if (currentRepet > mostFreqRepet)
            {
                mostFreqRepet = currentRepet;
                mostFrequent = numbers[outerIndex];
            }
        }
        Console.WriteLine("The most frequent number is:{0}, having repeated itself {1} times", mostFrequent, mostFreqRepet);
    }
}

