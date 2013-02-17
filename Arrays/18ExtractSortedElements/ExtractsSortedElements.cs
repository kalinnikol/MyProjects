using System;
using System.Collections.Generic;

class ExtractsSortedElements
{
    
    static List<int> result = new List<int>();

    private static int[] InputArray(int n)
    {
        int[] array= new int[n];
        for (int ind = 0; ind < n; ind++)
        {
            array[ind] = int.Parse(Console.ReadLine());
        }
        return array;
    }


    private static int PosibleVariations(int[] array, int[] fillArray, int n, int index, int maxLength)
    {
        if (index == -1)
        {
            maxLength= ExtractSorted(array, fillArray, n, maxLength);
        }
        else
        {
            for (int filler = 0; filler <= 1; filler++)
            {
                fillArray[index] = filler;
                maxLength=PosibleVariations(array, fillArray, n, index - 1, maxLength);
            }
        }
        
        return maxLength;
    }

    private static int ExtractSorted(int[] array, int[] fillArray, int n, int maxLength)
    {
        List<int> currentList = new List<int>();
        for (int item = 0; item < n; item++)
        {
            if (fillArray[item] == 1)
            {
                currentList.Add(array[item]);
            }
            bool isSorted = true;
            for (int ind = 0; ind < currentList.Count-1; ind++)
            {
                if (currentList[ind] > currentList[ind + 1])
                {
                    isSorted = false;
                    break;
                }
            }
            if (isSorted)
            {
                if (currentList.Count > maxLength)
                {
                    maxLength = currentList.Count;
                    result.Clear();
                    for (int ind = 0; ind < currentList.Count; ind++)
                    {
                        result.Add(currentList[ind]);
                    }
                }
            }
        }
        return maxLength;
    }

    private static void PrintResult()
    {
        foreach (int el in result)
        {
            Console.Write("{0} ", el);
        }
        Console.WriteLine();
    }
  

    static void Main()
    {
        Console.WriteLine("Enter length of array:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter all numbers from the array (each on different line):");
        int[] array = InputArray(n);
        List<int> result = new List<int>();
        int maxLength = Int32.MinValue;
        int[] fillArray= new int[n];
        int index=n-1;
        maxLength=PosibleVariations(array, fillArray, n, index,maxLength);
        PrintResult();
    }
}

