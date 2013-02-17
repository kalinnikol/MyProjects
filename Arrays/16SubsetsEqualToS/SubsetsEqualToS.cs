using System;
using System.Collections.Generic;

class SubsetsEqualToS
{
    private static int[] InputArray(int n)
    {
        int[] array= new int[n];
        Console.WriteLine("Enter the values of all array elements(each on different line):");
        for (int ind = 0; ind < n; ind++)
        {
            array[ind] = int.Parse(Console.ReadLine());
        }
        return array;
    }



    private static bool PosibleVariations(int[] array, int[] fillingArray, int n, int index, int s, bool flag)
    {
        if (index == -1)
        {
                flag = CheckSum(array, fillingArray, s, n, flag);
        }
        else 
        {
            for (int filler = 0; filler <= 1; filler++)
            {
                fillingArray[index] = filler;
                flag= PosibleVariations(array, fillingArray, n, index - 1, s, flag);
            }
        }
        return flag;
    }

    private static bool CheckSum(int[] array, int[] fillingArray, int s, int n, bool flag)
    {
        int currentSum = 0;       
        List<int> result =new List<int>();
        for (int item = 0; item < n; item++)
        {
            if (fillingArray[item] == 1)
            {
                result.Add(array[item]);
                currentSum+=array[item];
            }
        }
        if (currentSum == s)
        {
            flag = false;
            foreach (int num in result)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
        }
        return flag;
    }


    static void Main()
    {
        Console.WriteLine("Enter length of array:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of sum:");
        int s = int.Parse(Console.ReadLine());
        bool flag = true;
        int[] array = InputArray(n);
        int[] fillingArray= new int[n];
        int index=n-1;
        flag=PosibleVariations(array, fillingArray, n, index,s, flag);
        if (flag)
        {
            Console.WriteLine("No such subset");
        }
    }

    
}

