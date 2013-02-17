using System;

class VariationsOfKElements
{
    private static void MakeVariations(int[] vector, int index, int n)
    {
        if (index == -1)
        {
            PrintArray(vector);
        }
        else
        {
            for (int fillingNumber = 1; fillingNumber <= n; fillingNumber++)
            {
                vector[index] = fillingNumber;
                MakeVariations(vector, index - 1, n);
            }
        }
    }


    private static void PrintArray(int[] vector)
    {
        Console.WriteLine("*************");
        for (int i = 0; i < vector.Length; i++)
        {
            Console.Write("{0} ", vector[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Enter value for N");
        int n = int.Parse(Console.ReadLine());

        int k = int.Parse(Console.ReadLine());
        int[] vector = new int[k];
        int index = k - 1;
        MakeVariations(vector, index, n);
    }
}