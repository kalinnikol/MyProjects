using System;

class BiggerInteger
{
    private static int GetMax(int first, int second)
    {
        if (first > second)
        {
            Console.WriteLine("The greater number is: {0}", first);
            return first;
        }
        else if (second > first)
        {
            Console.WriteLine("The greater number is: {0}", second);
            return second;
        }
        else 
        {
            Console.WriteLine("{0}={1}", first, second);
            return first;
        }
    }

    private static void BiggerOfThree(int greater)
    {
        Console.WriteLine("Enter three integers (on different lines):");
        int first = int.Parse(Console.ReadLine());
        int second = int.Parse(Console.ReadLine());
        int third = int.Parse(Console.ReadLine());
        greater = GetMax(first, second);
        greater = GetMax(greater, third);
        Console.WriteLine("The maximal of the three integers is:{0}", greater);
    }

    static void Main()
    {
        int first = -2;
        int second = 5;
        int greater = GetMax(first, second);
        BiggerOfThree(greater);
    }    
}

