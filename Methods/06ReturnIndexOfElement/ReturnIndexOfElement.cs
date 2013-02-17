using System;

class ReturnIndexOfElement
{
    private static int[] InputArrray()
    {
        Console.WriteLine("Enter number of elements in the array");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int index = 0; index < n; index++)
        {
            Console.WriteLine("Enter element number {0}", index);
            array[index] = int.Parse(Console.ReadLine());
        }
        return array;
    }

    private static int FindIndex(int[] array)
    {
        int isBigger;
        for (int position = 0; position < array.Length; position++)
        {
            isBigger = CheckNeighbours(array, position);
            if (isBigger == 1)
            {
                return position;
            }
        }
        return -1;
    }

    private static int CheckNeighbours(int[] array, int position)
    {
        int isBigger;
        if ((position - 1 >= 0) && (position + 1 <= array.Length - 1))
        {
            if ((array[position] > array[position - 1]) && (array[position] > array[position + 1]))
            {
                isBigger = 1;
                return isBigger;
            }
            else
            {
                isBigger = -1;
                return isBigger;
            }
        }
        else
        {
            isBigger = 0;
            return isBigger;
        }
    }


    

    private static void PrintResult(int index)
    {
        if (index == -1)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine("The index of the first element bigger than its neighbours is {0}.", index);
        }
    }

    static void Main()
    {
        int[] array = InputArrray();
        int index = FindIndex(array);
        PrintResult(index);
    }
}

