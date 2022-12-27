using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the text you want to convert to binary");
            string text = Console.ReadLine();

            Console.WriteLine(ToBinary(text));

            Console.ReadKey();
        }

        public static string ToBinary(string text)
        {
            string binary = "";

            string[] binArray = text.Split(' ');

            foreach (string word in binArray)
            {
                binary += GetNumberForWord(word);
            }

            return binary;

            text = text.Replace(" ", "");
            Console.WriteLine(text);

            do
            {
                string firstChar = text.Substring(0, 1);

                if (firstChar == "o" || firstChar == "O")
                {
                    binary += "1";
                    text = text.Replace(text.Substring(0, 3), "");

                }
                else if (firstChar == "z" || firstChar == "Z")
                {
                    binary += "0";
                    text = text.Replace(text.Substring(0, 4), "");
                }
            }

            while (text.Length != 0);
            Console.WriteLine(binary);
            Console.WriteLine(text);
        }

        private static string GetNumberForWord(string word)
        {
            if (word.ToLower() == "one")
                return "1";
            else if (word.ToLower() == "zero")
                return "0";
            else return "";
        }
    }
}

