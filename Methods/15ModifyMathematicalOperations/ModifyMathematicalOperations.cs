using System;
using System.Collections.Generic;
using System.Numerics;

class MathematicalOperations
{

    static T MaximalNumber<T>(params T[] array)
    {
        dynamic max = array[0];
        for (int index = 1; index < array.Length; index++)
        {
            if (array[index] > max)
            {
                max = array[index];
            }
        }
        return max;
    }

    static T MinimalNumber<T>(params T[] array)
    {
        dynamic min = array[0];
        for (int index = 1; index < array.Length; index++)
        {
            if (array[index] < min)
            {
                min = array[index];
            }
        }
        return min;
    }

    static T FindSum<T>(params T[] array)
    {
        dynamic sum = 0;
        for (int index = 0; index < array.Length; index++)
        {
            sum = sum + array[index];
        }
        return sum;
    }

    static T FindProduct<T>(params T[] array)
    {
        dynamic product = 1;
        for (int index = 0; index < array.Length; index++)
        {
            product = product * array[index];
        }
        return product;
    }


    static void Main()
    {
        Console.WriteLine("The maximal number is:{0}", MaximalNumber(100, 5, 10378, 6, 3000));
        Console.WriteLine("The minimal number is:{0}", MinimalNumber(100, 5, 10378, 6, 3000));
        Console.WriteLine("The sum is:{0}", FindSum(100, 5, 10378, 6, 3000));
        Console.WriteLine("The product is:{0}", FindProduct(100, 5, 10378, 6, 3000));
        Console.WriteLine("The maximal number is:{0}", MaximalNumber(1.2f, 19f, 10378f, 6f, 3000f));
        Console.WriteLine("The minimal number is:{0}", MinimalNumber(1.2f, 19f, 10378f, 6f, 3000f));
        Console.WriteLine("The sum is:{0}", FindSum(1.2f, 19f, 10378f, 6f, 3000f));
        Console.WriteLine("The product is:{0}", FindProduct(1.2f, 19f, 10378f, 6f, 3000f));
    }
}