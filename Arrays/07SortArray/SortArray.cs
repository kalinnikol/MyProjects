using System;

class SortArray
{
    static void Main()
    {
        Console.WriteLine("Enter length of the array to sort:");
        string line = Console.ReadLine();
        int n = int.Parse(line);
        int minValue = Int32.MaxValue;
        int minValuePos = 0;
        int[] sortArr=new int[n];
        for (int index = 0; index <= n - 1; index++)
        {
            Console.WriteLine("Enter the value of Array[{0}]", index);
            line = Console.ReadLine();
            sortArr[index] = int.Parse(line);
        }

        for (int outInd = 0; outInd <= n - 1; outInd++)
        {
            for (int index = outInd; index <= n - 1; index++)
            {
                if (sortArr[index] < minValue)
                {
                    minValue = sortArr[index];
                    minValuePos = index;
                }
            }
            if (outInd != minValuePos)
            {
                sortArr[outInd] += sortArr[minValuePos];
                sortArr[minValuePos] = sortArr[outInd] - sortArr[minValuePos];
                sortArr[outInd] = sortArr[outInd] - sortArr[minValuePos];
            }
            minValue = Int32.MaxValue;
        }
        for (int index = 0; index <= n - 1; index++)
        {
            Console.Write("{0} ", sortArr[index]);
        }
    }
}

