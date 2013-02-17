using System;
using System.Collections.Generic;

    class DecimalToHexadecimal
    {
        private static void ConvertDecimalToHexadecimal(uint decim)
        {
            Console.WriteLine("The hexadecimal representation of {0} is:", decim);
            List<string> hexadecimal = new List<string>();
            while (decim / 16 != 0)
            {
                CheckRemaining(decim, hexadecimal);
                decim = decim / 16;
            }
            CheckRemaining(decim, hexadecimal);
            foreach (string num in hexadecimal)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
        }

        private static void CheckRemaining(uint decim, List<string> hexadecimal)
        {
            if (decim % 16 == 15)
            {
                hexadecimal.Insert(0, "F");
            }
            else if (decim % 16 == 14)
            {
                hexadecimal.Insert(0, "E");
            }
            else if (decim % 16 == 13)
            {
                hexadecimal.Insert(0, "D");
            }
            else if (decim % 16 == 12)
            {
                hexadecimal.Insert(0, "C");
            }
            else if (decim % 16 == 11)
            {
                hexadecimal.Insert(0, "B");
            }
            else if (decim % 16 == 10)
            {
                hexadecimal.Insert(0, "A");
            }
            else
            {
                hexadecimal.Insert(0, (decim % 16).ToString());

            }
        }

        static void Main()
        {
            ConvertDecimalToHexadecimal(10);
            ConvertDecimalToHexadecimal(160);
        }
    }

