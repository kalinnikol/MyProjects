using System;
using System.Collections.Generic;

class SequenceOfGivenSum
{
    static void Main()
    {
        //input data
        Console.WriteLine("Enter the length of the array:");
        string line = Console.ReadLine();
        uint n = uint.Parse(line);
        Console.WriteLine("Enter the value of the searched sum:");
        line = Console.ReadLine();
        int s = int.Parse(line);

        //declaration and initialization of the array

        int[] array =new int[n];
        for (uint index=0; index<=n-1;index++)
        {
            Console.WriteLine("Enter value ({0}) of the array:", index);
            line=Console.ReadLine();
            array[index]=int.Parse(line);
        }
        
        //additional variables
        int currentSum=0;
        uint initialPos = 0;
        uint finalPos=0;
        List<uint> initialPosList = new List<uint>();
        List<uint> finalPosList = new List<uint>();
       

        //implementation

        for (uint outInd = 0; outInd <= n - 1; outInd++)
        {
            currentSum=array[outInd];
            if (currentSum == s)
            {
                initialPosList.Add(outInd);
                finalPosList.Add(outInd);
            }
            if (outInd != n - 1)
            {
                for (uint inInd = outInd + 1; inInd <= n - 1; inInd++)
                {
                    currentSum = currentSum + array[inInd];
                    if (currentSum == s)
                    {
                        initialPosList.Add(outInd);
                        finalPosList.Add(inInd);
                    }
                }
            }
        }
        //we have the index of the inital and final value for each sequence having sum=s
        //now we need to print all the sequences

        for (int sumNum = 0; sumNum <= initialPosList.Count - 1; sumNum++)
        {
            initialPos = initialPosList[sumNum];
            finalPos = finalPosList[sumNum];
            for (uint index = initialPos; index <= finalPos; index++)
            {
                Console.Write("{0} ", array[index]);
            }
            Console.WriteLine();
        }
        if (initialPosList.Count == 0)
        {
            Console.WriteLine("There is no such sum!");
        }
    }
}

