using System;
using System.Collections.Generic;

class MaximalElemenInPortion
{
    private static List<int> Input()
    {
        Console.WriteLine("Enter length of the array:");
        int n = int.Parse(Console.ReadLine());
        List<int> array= new List<int>();
        for (int index = 0; index < n; index++)
        {
            Console.WriteLine("Enter value of element [{0}]", index);
            array.Add(int.Parse(Console.ReadLine()));
        }
        return array;
    }

    private static int FindMax(List<int> array, int start)
    {
        int maxValue=Int32.MinValue;
        for (int index = start; index < array.Count; index++)
        {
            if (array[index] > maxValue)
            {
                maxValue=array[index];
            }
        }
        return maxValue;
    }

    private static void SortingArray(int start, int maxValue, List<int> array)
    {
        List<int> sortedRight = new List<int>();
        List<int> sortedLeft = new List<int>();
        sortedRight.Add(maxValue);
        array.Remove(maxValue);
        while (array.Count > start+1)
        {
            maxValue=FindMax(array, start);
            sortedRight.Insert(0,maxValue);
            array.Remove(maxValue);
        }
        while (array.Count > 0)
        {
            maxValue= FindMax(array,0);
            sortedLeft.Insert(0,maxValue);
            array.Remove(maxValue);
        }
        Merge(sortedRight, sortedLeft);
    }

    private static void Merge(List<int> sortedRight, List<int> sortedLeft)
    {
        List<int> merged= new List<int>();
        while ((sortedRight.Count>0)&&(sortedLeft.Count>0))
        {
            if (sortedRight[0] <= sortedLeft[0])
            {
                merged.Add(sortedRight[0]);
                sortedRight.RemoveAt(0);
            }
            else
            {
                merged.Add(sortedLeft[0]);
                sortedLeft.RemoveAt(0);
            }
        }
        if (sortedRight.Count > 0)
        {
            merged.AddRange(sortedRight);
        }
        if (sortedLeft.Count > 0)
        {
            merged.AddRange(sortedLeft);
        }
        PrintSorted(merged);
    }

    private static void PrintSorted(List<int> sorted)
    {
        Console.WriteLine("The sorted arrray is:");
        foreach (int num in sorted)
        {
            Console.Write("{0} ", num);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        List<int> array = Input();
        Console.WriteLine("Enter a starting index to specify array portion");
        int start = int.Parse(Console.ReadLine());
        int maxValue = FindMax(array, start);
        Console.WriteLine("The maximum value in the portion from index {0} to index {1} is {2}.", start, array.Count-1, maxValue);
        //so far goes the implementation of the first part of the task
        //the following code implements the sorting part
        SortingArray(start, maxValue, array);
    }
}

