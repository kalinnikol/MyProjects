using System;
using System.Collections.Generic;

class SequenceOfMaxSum
{
    static void Main()
    {
        //input data
        Console.WriteLine("Enter the length of the array:");
        string line = Console.ReadLine();
        uint n = uint.Parse(line);

        //declaration and initialization of the array

        int[] array = new int[n];
        for (uint index = 0; index <= n - 1; index++)
        {
            Console.WriteLine("Enter value ({0}) of the array:", index);
            line = Console.ReadLine();
            array[index] = int.Parse(line);
        }

        //additional variables
        int currentSum = 0;
        uint[,] posArr= new uint[2,n*n]; //will collect the initial and final position of all maximal sums
        uint maxSumCount = 0; // counts the number of sequences with max values
        int maxSum = Int32.MinValue;
        uint start = 0;
        uint stop = 0;


        //implementation
        if (n > 1)
        {
            for (uint outInd = 0; outInd <= n - 1; outInd++)
            {
                currentSum = array[outInd];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSumCount = 1;
                    posArr[0, maxSumCount - 1] = outInd;
                    posArr[1, maxSumCount - 1] = outInd;
                }
                 else if (currentSum == maxSum)
                {
                    maxSumCount++;
                    posArr[0, maxSumCount - 1] = outInd;
                    posArr[1, maxSumCount - 1] = outInd;
                }
                if (outInd != n - 1)
                {
                    for (uint inInd = outInd + 1; inInd <= n - 1; inInd++)
                    {
                        currentSum = currentSum + array[inInd];
                        if (currentSum > maxSum)
                        {
                            maxSum = currentSum;
                            maxSumCount = 1;
                            posArr[0, maxSumCount - 1] = outInd;
                            posArr[1, maxSumCount - 1] = inInd;
                        }
                        else if (currentSum == maxSum)
                        {
                            maxSumCount++;
                            posArr[0, maxSumCount - 1] = outInd;
                            posArr[1, maxSumCount - 1] = inInd;
                        }
                    }
                }
            }
        }
        
        //printing all the posible sums with a maximal values
        if (n > 1)
        {
            for (int maxNum = 0; maxNum <= maxSumCount - 1; maxNum++)
            {
                start = posArr[0, maxNum];
                stop = posArr[1, maxNum];
                for (uint index = start; index <= stop; index++)
                {
                    Console.Write("{0} ", array[index]);
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine(array[0]);
        }
    }
}

