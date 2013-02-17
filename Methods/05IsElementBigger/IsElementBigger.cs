using System;

    class IsElementBigger
    {

        private static int CheckNeighbours(int[] array,int position)
        {
            int isBigger;
            if ((position - 1 >= 0) && (position + 1 <= array.Length - 1))
            {
                if ((array[position] > array[position - 1]) && (array[position] > array[position + 1]))
                {
                    isBigger = 1;
                    return isBigger;
                }
                else
                {
                    isBigger = -1;
                    return isBigger;
                }
            }
            else
            {
                isBigger = 0;
                return isBigger;
            }
        }


        private static int[] InputArrray()
        {
            Console.WriteLine("Enter number of elements in the array");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int index = 0; index < n; index++)
            {
                Console.WriteLine("Enter elment number {0}", index);
                array[index] = int.Parse(Console.ReadLine());
            }
            return array;
        }

        private static void PrintResult(int isBigger)
        {
            if (isBigger == 1)
            {
                Console.WriteLine("The number is bigger than its two neighbours.");
            }
            else if (isBigger == -1)
            {
                Console.WriteLine("The number is not bigger than its two neighbours");
            }
            else if (isBigger == 0)
            {
                Console.WriteLine("The number doesn`t have two neighbours.");
            }
        }

        static void Main()
        {
            int[] array = InputArrray();
            Console.WriteLine("Enter position of number (from 0 to {0}):", array.Length-1);
            int position = int.Parse(Console.ReadLine());
            int isBigger=CheckNeighbours(array, position);
            PrintResult(isBigger);
        }

        
    }

