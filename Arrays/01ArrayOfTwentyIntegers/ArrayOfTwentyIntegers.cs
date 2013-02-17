using System;

class ArrayOfTwentyIntegers
{
    static void Main()
    {
        int[] arr = new int[20];
        for (int index = 0; index <= arr.Length - 1; index++)
        {
            arr[index] = index * 5;
            Console.WriteLine(arr[index]);
        }
    }
}

