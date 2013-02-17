using System;
using System.Collections.Generic;
using System.Text;

    class BinToHexadecimal
    {
        private static void BinaryToHexadecimal(List<char> binList)
        {
            StringBuilder hex= new StringBuilder();
            binList=FillDigits(binList);
            string fourDigits = "";
            while (binList.Count != 0)
            {
                fourDigits = String.Join("", binList.GetRange(0,4));
                binList.RemoveRange(0, 4);
                hex=CheckFourDigits(hex, fourDigits);
            }
            Console.WriteLine(hex);
        }

        private static StringBuilder CheckFourDigits(StringBuilder hex, string fourDigits)
        {
            switch (fourDigits)
            {
                case "0000": hex.Append("0");
                    break;
                case "0001": hex.Append("1");
                    break;
                case "0010": hex.Append("2");
                    break;
                case "0011": hex.Append("3");
                    break;
                case "0100": hex.Append("4");
                    break;
                case "0101": hex.Append("5");
                    break;
                case "0110": hex.Append("6");
                    break;
                case "0111": hex.Append("7");
                    break;
                case "1000": hex.Append("8");
                    break;
                case "1010": hex.Append("A");
                    break;
                case "1011": hex.Append("B");
                    break;
                case "1100": hex.Append("C");
                    break;
                case "1101": hex.Append("D");
                    break;
                case "1110": hex.Append("E");
                    break;
                case "1111": hex.Append("F");
                    break;
            }
            return hex;
        }

        private static void PrintResult(List<char> binList)
        {
            foreach (char el in binList)
            {
                Console.Write("" + el);
            }
            Console.WriteLine();
        }

        private static List<char> FillDigits(List<char> binList)
        {
            int n = binList.Count;
            if (n % 4 != 0)
            {
                for (int count = 1; count <= 4-(n % 4); count++)
                {
                    binList.Insert(0, '0');
                }
            }
            return binList;
        }

        private static List<char>  BinStringToBinList(string binary)
        {
            List<char> binList = new List<char>();
            foreach (char el in binary)
            {
                binList.Add(el);
            }
            return binList;
        }

        static void Main(string[] args)
        {
            string binary = "111100110";
            List<char> binList=BinStringToBinList(binary);
            BinaryToHexadecimal(binList);
        }

        

        
    }

