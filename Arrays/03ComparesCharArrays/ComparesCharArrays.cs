using System;

    class ComparesCharArrays
    {
        static void Main()
        {
            Console.WriteLine("Enter length of the two arrays:");
            string line = Console.ReadLine();
            int n = int.Parse(line);
            char[] charArrayOne = new char[n];
            char[] charArrayTwo = new char[n];
            Console.WriteLine("Enter elements of the first char array (on separate lines):");
            for (int index = 0; index <= n - 1; index++)
            {
                line = Console.ReadLine();
                charArrayOne[index] = char.Parse(line);
            }
            Console.WriteLine("Enter elements of the second char array (on separate lines):");
            for (int index = 0; index <= n - 1; index++)
            {
                line = Console.ReadLine();
                charArrayTwo[index] = char.Parse(line);
            }
            for (int index = 0; index <= n - 1; index++)
            {
                if (charArrayOne[index] > charArrayTwo[index])
                {
                    Console.Write("Array of chars One [{0}] > Array of chars Two [{0}]", index);
                    Console.Write("".PadLeft(10));
                    Console.WriteLine("{0} > {1}",charArrayOne[index],charArrayTwo[index]);
                }
                else if (charArrayOne[index] < charArrayTwo[index])
                {
                    Console.Write("Array of chars One [{0}] < Array of chars Two [{0}]", index);
                    Console.Write("".PadLeft(10));
                    Console.WriteLine("{0} < {1}", charArrayOne[index], charArrayTwo[index]);
                }
                else 
                {
                    Console.Write("Array of chars One [{0}] = Array of chars Two [{0}]", index);
                    Console.Write("".PadLeft(10));
                    Console.WriteLine("{0} = {1}", charArrayOne[index], charArrayTwo[index]);
                }
            }
        }
    }

