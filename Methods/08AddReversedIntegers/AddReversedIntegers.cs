using System;

using System.Collections.Generic;
    class AddReversedIntegers
    {
        private static void AddReversed(List<byte> firstInt, List<byte> secondInt)
        {
            int stop;
            if (firstInt.Count > secondInt.Count)
            {
                stop = firstInt.Count - secondInt.Count;
                for (int count = 1; count <= stop; count++)
                {
                    secondInt.Add(0);
                }
            }
            else if (secondInt.Count > firstInt.Count)
            {
                stop = secondInt.Count - firstInt.Count;
                for (int count = 1; count <= stop; count++)
                {
                    firstInt.Add(0);
                }
            }

            List<byte> result= new List<byte>();
            byte transfer = 0;
            byte sum = 0;
            for (int index = 0; index < (Math.Max(firstInt.Count, secondInt.Count)); index++)
            {
                sum = (byte)((firstInt[index] + secondInt[index]) % 10 + transfer);
                transfer = (byte)((firstInt[index] + secondInt[index]) / 10);
                result.Add(sum);
            }
            if (transfer != 0)
            {
                result.Add(transfer);
            }
            PrintResult(result);
        }

        private static void PrintResult(List<byte> result)
        {
            foreach (byte digit in result)
            {
                Console.Write("{0} ", digit);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            //reversing the integers if read from the console can be done as shown in the method from the previous task
            //in this task I will use lists that represent already reversed integers
            List<byte> firstInt = new List<byte>() {3,4,5,6};
            List<byte> secondInt=new List<byte>(){9};
            AddReversed(firstInt, secondInt);
            firstInt=new List<byte>{9,9,9,9};
            secondInt = new List<byte> {1,1,1,1};
            AddReversed(firstInt, secondInt);
        }

        
    }

