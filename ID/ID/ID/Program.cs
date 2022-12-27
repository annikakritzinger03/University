using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert your ID number");     //0312110099081
            string id = Console.ReadLine();

            Console.WriteLine("\nBirthday:\t\t\tGender:\t\tCitizenship:");
            Console.WriteLine(DisplayDetails(id));

            Console.ReadKey();
        }

        private static string DisplayDetails(string id)
        {
            string display = "";

            //yymmdd
            int year = Convert.ToInt32(id.Substring(0, 2));

            if (year > 22)
            {
                year += 1900;
            }
            else
            {
                year += 2000;
            }
           
            int month = Convert.ToInt32(id.Substring(2, 2));
            int day = Convert.ToInt32(id.Substring(4, 2));

            DateTime dateTime = new DateTime(year, month, day);
            display += dateTime.ToLongDateString();

            //0000-4999 (F)     5000-9999 (M)
            int gender = Convert.ToInt32(id.Substring(6, 4));

            if (gender < 5000)
            {
                display += "\t\tFemale";
            }
            else
            {
                display += "\t\tMale";
            }

            //citizen = 0    permanent resident = 1
            if (id[10] == '1')
            {
                display += "\t\tPermanent resident";
            }
            else
            {
                display += "\t\tSA citizen";
            }

            return display;
        }
    }
}
