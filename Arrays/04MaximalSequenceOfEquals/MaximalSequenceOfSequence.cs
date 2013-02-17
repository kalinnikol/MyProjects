using System;

class MaximalSequenceOfSequence
{
    static void Main()
    {
        string line = Console.ReadLine();
        int n = int.Parse(line);
        int[] arr = new int[n];
        int repeatNumber = 0;
        int numberToCount;
        int maxSequence = 0;
        int countEquals = 0;

        for (int index = 0; index <= n - 1; index++)
        {
            line = Console.ReadLine();
            arr[index] = int.Parse(line);
        }
        numberToCount = arr[0];
        for (int index = 0; index <= n - 1; index++)
        {
            if (arr[index] == numberToCount)
            {
                countEquals++;
            }
            else
            {
                if (countEquals >= maxSequence)
                {
                    maxSequence = countEquals;
                    repeatNumber = numberToCount;
                }
                numberToCount = arr[index];
                countEquals = 1;
            }
        }
        if (countEquals >= maxSequence)
        {
            maxSequence = countEquals;
            repeatNumber = numberToCount;
        }
        for (int index = 0; index <= maxSequence - 1; index++)
        {
            Console.Write("{0} ", repeatNumber);
        }
    }
}

