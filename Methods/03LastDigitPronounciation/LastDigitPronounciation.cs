using System;

class LastDigitPronounciation
{

    private static string PronounceLastDigit(int number)
    {
        if (number < 0)
        {
            number = number * (-1);
        }
        int result = number % 10;
        string lastDigit="";
        switch (result)
        {   
            case 0:
                lastDigit = "zero";
                break;
            case 1:
                lastDigit = "one";
                break;
            case 2:
                lastDigit = "two";
                break;
            case 3:
                lastDigit = "three";
                break;
            case 4:
                lastDigit = "four";
                break;
            case 5:
                lastDigit = "five";
                break;
            case 6:
                lastDigit = "six";
                break;
            case 7:
                lastDigit = "seven";
                break;
            case 8:
                lastDigit = "eight";
                break;
            case 9:
                lastDigit = "nine";
                break;
        }
        return lastDigit;
    }

    static void Main()
    {
        Console.WriteLine("Enter an integer nuber:");
        int number = int.Parse(Console.ReadLine());
        string lastDigit=PronounceLastDigit(number);
        Console.WriteLine("The last digit is {0}.", lastDigit);
    }

   
}

