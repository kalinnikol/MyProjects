using System;

class MergeSortAlgorithm
{
    static void SortArray(int[] inputArray)
    {
        SplitArray(inputArray, 0, inputArray.Length-1);
    }

    static void SplitArray(int[] inputArray, int lower, int upper)
    {
        if (lower < upper)
        {
            int middle = (lower + upper) / 2;
            SplitArray(inputArray, lower, middle);
            SplitArray(inputArray, middle + 1, upper);
            Merge(inputArray, lower, middle, upper);
        }
    }
    private static void Merge(int[] inputArray, int lower, int middle, int upper)
    {
        int[] tempArr=new int[upper-lower+1];
        int left = lower;
        int right = middle + 1;
        int count = 0;
        while (left <= middle && right <= upper)
        {
            if (inputArray[left] < inputArray[right])
            {
                tempArr[count] = inputArray[left];
                left++;
            }
            else 
            {
                tempArr[count]=inputArray[right];
                right++;
            }
            count++;
        }

        if (left <= middle)
        {
            while (left <= middle)
            {
                tempArr[count]=inputArray[left];
                left++;
                count++;
            }
        }
        else if(right<=upper)
        {
            while (right<=upper)
            {
                tempArr[count]=inputArray[right];
                right++;
                count++;
            }
        }

        for (int index = 0; index < tempArr.Length; index++)
        {
            inputArray[lower+index]=tempArr[index];
        }
    }

    static int[] ReadInput() 
    {
        Console.WriteLine("Enter length of array:");
        int n = int.Parse(Console.ReadLine());
        int[] inputArray = new int[n];
        Console.WriteLine("Enter all elements of the array(each on different line):");
        for (int index = 0; index < inputArray.Length; index++)
        {
            inputArray[index] = int.Parse(Console.ReadLine());
        }
            return inputArray;
    }
    static void PrintArray(int[] inputArray) 
    {
        for (int index = 0; index < inputArray.Length; index++)
        {
            Console.Write("{0} ", inputArray[index]);
        }
        Console.WriteLine();
    }
    static void Main()
    {
        int[] inputArray = ReadInput();
        Console.WriteLine("The array before merge sort is:");
        PrintArray(inputArray);
        SortArray(inputArray);
        Console.WriteLine("The array after merge sort is:");
        PrintArray(inputArray);
    }
}


