using System;

class CompareTwoArrays
{
    static void Main()
    {
        Console.WriteLine("Enter length of the two arrays");
        string line = Console.ReadLine();
        int n = int.Parse(line);
        int[] arrayOne=new int[n];
        int[] arrayTwo = new int[n];
        Console.WriteLine("Enter first array (each element on seperate line) :");
        for (int index = 0; index <= n - 1; index++)
        {
            line=Console.ReadLine();
            arrayOne[index] = int.Parse(line);
        }
        Console.WriteLine("Enter second array (each element on seperate line) :");
        for (int index = 0; index <= n - 1; index++)
        {
            line = Console.ReadLine();
            arrayTwo[index] = int.Parse(line);
        }
        for (int index = 0; index <= n - 1; index++)
        {
            if (arrayOne[index] > arrayTwo[index])
            {
                Console.Write("Array One[{0}] > Array Two [{0}]", index);
                Console.Write("".PadLeft(10));
                Console.WriteLine("{0} > {1}", arrayOne[index],arrayTwo[index]);
            }
            else if (arrayOne[index] < arrayTwo[index])
            {
                Console.Write("Array One[{0}] < Array Two [{0}]", index);
                Console.Write("".PadLeft(10));
                Console.WriteLine("{0} < {1}", arrayOne[index], arrayTwo[index]);
            }
            else 
            {
                Console.Write("Array One[{0}] = Array Two [{0}]", index);
                Console.Write("".PadLeft(10));
                Console.WriteLine("{0} = {1}", arrayOne[index], arrayTwo[index]);
            }
        }
    }
}

