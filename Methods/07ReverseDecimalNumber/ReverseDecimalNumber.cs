using System;
using System.Collections.Generic;
using System.Text;

class ReverseDecimalNumber
{
    private static string Input()
    {
        Console.WriteLine("Enter a number in the decimal notation:");
        string inputDecimal = Console.ReadLine();
        return inputDecimal;
    }

    private static void ReverseNumber(string inputDecimal)
    {
        List<char> reverseList=new List<char>();
        for (int index = inputDecimal.Length - 1; index >= 0;index--)
        {
            reverseList.Add(inputDecimal[index]);
        }
        ListToNumber(reverseList);
    }

    private static void ListToNumber(List<char> reverseList)
    {
        int reversedNum;
        string reverseString = String.Join("", reverseList);
        reversedNum = int.Parse(reverseString);
        Console.WriteLine("The reversed number is: {0}", reversedNum);
    }

    static void Main()
    {
        string inputDecimal = Input();
        ReverseNumber(inputDecimal);
    }

    

    
}

