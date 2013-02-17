using System;

    class RepetitionsOfNumberInArray
    {
        
        private static int[] InputArrray()
        {
            Console.WriteLine("Enter number of elements in the array");
            int n = int.Parse(Console.ReadLine());
            int[] array= new int[n]; 
            for (int index=0; index<n; index++)
            {
                Console.WriteLine("Enter elment number {0}", index);
                array[index]=int.Parse(Console.ReadLine());
            }
            return array;
        }

        private static void CountApperances(int[] array, int number)
        {
            int count =0;
            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] == number)
                {
                    count++;
                }
            }
            PrintCount(number, count);
        }

        private static void PrintCount(int number, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("The number {0} doesn`t appear in the array!", number);
            }
            else
            {
                Console.WriteLine("The number {0} appears {1} time(s) in the array", number, count);
            }
        }

        static void Main()
        {
            int[] array = InputArrray();
            Console.WriteLine("Enter number to be search in the array:");
            int number = int.Parse(Console.ReadLine());
            CountApperances(array, number);
            CountApperances(array,37);
            CountApperances(array, 10);
            CountApperances(array, 0);
        }

        

        

    }

