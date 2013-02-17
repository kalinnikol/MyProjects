using System;
    class BinarySearchAlgorithm
    {
        
        private static int[] SortMyArray()
        {
            Console.WriteLine("Enter length of the array to sort:");
            string line = Console.ReadLine();
            int n = int.Parse(line);
            int minValue = Int32.MaxValue;
            int minValuePos = 0;
            int[] sortArr = new int[n];
            for (int index = 0; index <= n - 1; index++)
            {
                Console.WriteLine("Enter the value of Array[{0}]", index);
                line = Console.ReadLine();
                sortArr[index] = int.Parse(line);
            }

            for (int outInd = 0; outInd <= n - 1; outInd++)
            {
                for (int index = outInd; index <= n - 1; index++)
                {
                    if (sortArr[index] < minValue)
                    {
                        minValue = sortArr[index];
                        minValuePos = index;
                    }
                }
                if (outInd != minValuePos)
                {
                    sortArr[outInd] += sortArr[minValuePos];
                    sortArr[minValuePos] = sortArr[outInd] - sortArr[minValuePos];
                    sortArr[outInd] = sortArr[outInd] - sortArr[minValuePos];
                }
                minValue = Int32.MaxValue;
            }
            
            return sortArr;
        }
        private static void FindIndexOfNumber(int[] sortArray, int start, int end, int searchValue)
        {
            if (end < start)
            {
                Console.WriteLine("The number {0} does not exist int this array!", searchValue);
                return;
            }
            int centerIndex= (start+end)/2;
            if (sortArray[centerIndex] > searchValue)
            {
                end = centerIndex - 1;
            }
            else if (sortArray[centerIndex] < searchValue)
            {
                start = centerIndex + 1;
            }
            else
            {
                Console.WriteLine("The index of number {0} is {1}.", searchValue,centerIndex);
                return;
            }
            FindIndexOfNumber(sortArray,start, end, searchValue);
        }
        static void Main()
        {
            int[] sortArray= SortMyArray();
            Console.WriteLine("Which number do you want to search in the array?");
            int searchValue=int.Parse(Console.ReadLine());
            FindIndexOfNumber(sortArray,0,sortArray.Length, searchValue);
        }

       
    }

