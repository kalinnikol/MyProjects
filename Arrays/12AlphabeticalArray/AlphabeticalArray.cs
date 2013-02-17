using System;

class AlphabeticalArray
{
    static void Main()
    {
        char[] alphabet= new char[26];
        for (int index=0; index<=25;index++)
        {
            alphabet[index] = (char)(65 + index);
        }
        Console.WriteLine("Enter a word:");
        string word = Console.ReadLine();
        int indexNum = 0;
        foreach (char symbol in word)
        {
            indexNum = (int)(symbol);
            if (indexNum >= 97)
            {
                indexNum -= 97;
            }
            else 
            {
                indexNum -= 65;
            }
            Console.WriteLine(indexNum);
        }
    }
}

