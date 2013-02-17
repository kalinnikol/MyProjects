using System;

class CombinationsOfKElements
{
    private static void MakeCombinations(int[] vector, int index, int n, int start)
    {
        if (index == -1)
        {
            PrintArray(vector);
        }
        else 
        {
            for (int number = start; number <= n; number++)
            {
                vector[index] = number;
                MakeCombinations(vector, index-1, n, number+1);
            }
        }
    }

    private static void PrintArray(int[] vector)
    {
        Console.WriteLine("*************");
        for (int posInVector =vector.Length-1; posInVector >=0 ; posInVector--)
        {
            Console.Write("{0} ", vector[posInVector]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Enter n:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter k:");
        int k = int.Parse(Console.ReadLine());

        int[] vector = new int[k];
        int index=k-1;
        MakeCombinations(vector, index, n,1);
    }
}

