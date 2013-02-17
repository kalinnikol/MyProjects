using System;

class MaximalIncreasingSequence
{
    static void Main()
    {
        Console.WriteLine("Enter length of the array:");
        string line = Console.ReadLine();
        int n = int.Parse(line);
        int[] arr = new int[n];
        int firstOfSequence = 0;
        int numberToCount;
        int maxSequence = 0;
        int countIncreasing = 1;

        for (int index = 0; index <= n - 1; index++)
        {
            Console.WriteLine("Enter value of the {0} element of the array", index);
            line = Console.ReadLine();
            arr[index] = int.Parse(line);
        }
        numberToCount = arr[0];
        for (int index = 0; index <= n - 2; index++)
        {
            if (arr[index]== arr[index+1]-1)
            {
                countIncreasing++;
            }
            else
            {
                if (countIncreasing >= maxSequence)
                {
                    maxSequence = countIncreasing;
                    firstOfSequence = index - maxSequence +1;

                }
                countIncreasing = 1;
            }
        }
        if (countIncreasing >= maxSequence)
        {
            maxSequence = countIncreasing;
            firstOfSequence = n - maxSequence;
        }
        if ((maxSequence == 1) && (n != 1))
        {
            Console.WriteLine("No such sequence!");
        }
        else
        {
            Console.WriteLine("The maximal sequence of increasing numbers is:");
            for (int index = 0; index <= maxSequence - 1; index++)
            {
                Console.Write("{0} ", arr[firstOfSequence]);
                firstOfSequence++;
            }
            Console.WriteLine();
        }
    }
}

