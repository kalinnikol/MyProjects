using System;
using System.Collections.Generic;
using System.Linq;

class QuickSortAlgorithm
{
    static void Main()
    {
        //it would be easier to debbug with a specific array of strings,
        //so, firstly I create an array of strings and later I will use it as a list
        string[] unsortedArray = new string[12] { "January", "February", "March", "April", "May", "June", 
                                                  "July", "August", "September", "October", "November", "December"};
        List<string> sortList = new List<string>();
        sortList = unsortedArray.ToList();

        ////or you can read them from the console (UNCOMMENT THE FOLLOWING CODE):
        //Console.WriteLine("Enter number of string elements:");
        //int n = int.Parse(Console.ReadLine());
        //List<string> sortList = new List<string>();
        //for (int index = 0; index < n; index++)
        //{
        //    sortList.Add(Console.ReadLine());
        //}

        //Print the list of string while not sorted:
        Console.WriteLine("The unsorted list of string elements is:");
        foreach (string element in sortList)
        {
            Console.Write("{0} ", element);
        }
        Console.WriteLine();

        //Call QuickSort method, containing the quick sort algorithm:
        sortList = QuickSort(sortList);
        
        //Print the sorted array of strings:
        Console.WriteLine("The sorted list of string elements is:");
        foreach (string element in sortList)
        {
            Console.Write("{0} ", element);
        }
        Console.WriteLine();
    }

    private static List<string> QuickSort(List<string> sortedList)
    {
        //the "if" clause should terminate the recursion when the subarray becomes one or less
        if (sortedList.Count > 1)
        {
            int pivotIndex = (sortedList.Count) / 2;
            string pivot = sortedList[pivotIndex];

            //Divide the array in two arrays with smaller than the pivot elements
            //and greater than the pivot elements:
            List<string> leftPart = new List<string>();
            List<string> rightPart = new List<string>();

            for (int index = 0; index < sortedList.Count; index++)
            {
                if (index != pivotIndex)
                {
                    if (string.Compare(sortedList[index], pivot) <= 0)
                    {
                        leftPart.Add(sortedList[index]);
                    }
                    else
                    {
                        rightPart.Add(sortedList[index]);
                    }
                }
            }

            //will call the same method for each subarray longer than one element
            //these two lines insure recursion
            leftPart = QuickSort(leftPart);
            rightPart = QuickSort(rightPart);

            //clears the array sortedArray to fill it with the two subarrays and the pivot element
            for (int index = 0; index < sortedList.Count; index++)
            {
                sortedList[index] = null;
            }
            //fills sortedArray with the smaller than the pivot elements
            for (int index = 0; index < leftPart.Count; index++)
            {
                sortedList[index]=leftPart[index];
            }
            //fills the sortedArray with the pivot element
            sortedList[leftPart.Count] = pivot;
            //fills the sortedArray with the greater than the pivot elements
            for (int index = leftPart.Count + 1; index < leftPart.Count + rightPart.Count + 1; index++)
            {
                sortedList[index] = rightPart[index - leftPart.Count - 1];
            }
        

        }
        //returns the result
        return sortedList;
    }
}
