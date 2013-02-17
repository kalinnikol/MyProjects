using System;
using System.Collections.Generic;
using System.Numerics;

class MathematicalOperations
{

    static int MaximalNumber (params int[] array)
    {
        int max=array[0];
        for (int index = 1; index < array.Length; index++)
        {
            if (array[index] > max)
            {
                max=array[index];
            }
        }
        return max;
    }

    static int MinimalNumber(params int[] array)
    {
        int min = array[0];
        for (int index = 1; index < array.Length; index++)
        {
            if (array[index] < min)
            {
                min = array[index];
            }
        }
        return min;
    }

    static BigInteger FindSum(params int[] array)
    {
        BigInteger sum = 0;
        for (int index = 0; index < array.Length; index++)
        {
            sum = sum + array[index];
        }
        return sum;
    }
    
    static BigInteger FindProduct(params int[] array)
    {
        BigInteger product = 1;
        for (int index = 0; index < array.Length; index++)
        {
            product = product*array[index];
        }
        return product;
    }

   
    static void Main()
    {
        Console.WriteLine("The maximal number is:{0}", MaximalNumber(100, 5, 10378, 6, 3000));
        Console.WriteLine("The minimal number is:{0}", MinimalNumber(100, 5, 10378, 6, 3000));
        Console.WriteLine("The sum is:{0}", FindSum(100, 5, 10378, 6, 3000));
        Console.WriteLine("The product is:{0}", FindProduct(100, 5, 10378, 6, 3000));
    }
}

