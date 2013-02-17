using System;
using System.Collections.Generic;

    class DecimalToBinary

    {
        private static void ConvertDecimalToBinary(uint decim)
        {
            Console.WriteLine("The binary representation of {0} is:", decim);
            List<byte> binary = new List<byte>();
            while (decim / 2 != 0)
            {
                binary.Insert(0,(byte)(decim%2));
                decim = decim / 2;
            }
            binary.Insert(0, (byte)(decim % 2));
            foreach (byte num in binary)
            {
                Console.Write("{0}", num);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            uint decim = uint.Parse(Console.ReadLine());
            ConvertDecimalToBinary(decim);
        }

        
    }
