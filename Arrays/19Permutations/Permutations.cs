using System;
using System.Collections.Generic;

class Permutations
{
    private static int Input()
    {
        Console.WriteLine("Enter n:");
        int n = int.Parse(Console.ReadLine());
        return n;
    }

    private static void Output(int[] array)
    {
        bool flag=true;
        for (int outI = 0; outI < array.Length-1; outI++)
        {
            for (int inI = outI + 1; inI < array.Length; inI++)
            {
                if (array[outI] == array[inI])
                {
                    flag = false;
                    break;
                }
            }
        }
        if (flag)
        {
            for (int ind = 0; ind < array.Length; ind++)
            {
                Console.Write("{0}", array[ind]);
            }
            Console.WriteLine();
        }
    }

    private static void MakePermutation(int n, int index, int[] array)
    {
        if (index == -1)
        {
            Output(array);
        }
        else 
        {
            for (int num = n; num >= 1; num--)
            {
                array[index] = num;
                MakePermutation(n, index-1, array);
            }
        }
    }

    static void Main()
    {
        int n= Input();
        int[] array= new int[n];
        int index = n - 1;
        MakePermutation(n,index, array);
    }

    
    
}

