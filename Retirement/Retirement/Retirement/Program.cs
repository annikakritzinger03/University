using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayMainMenu();

            Console.ReadKey();
        }

        private static void DisplayMainMenu()
        {
            List<People> _peopleList = new List<People>();
            Console.Clear();

            do
            {
                Console.WriteLine(
                    $"{(int)Menu.ReadDetails}. Insert employee details\n" +
                    $"{(int)Menu.DisplaySortedRetirement}. Display retired employees in sorted order\n" +
                    $"{(int)Menu.DisplayLocals}. Display details of local employees\n" +
                    $"{(int)Menu.SearchByReference}. Search for an employee by the reference number\n" +
                    $"{(int)Menu.Exit}. Exit\n");

                Console.Write("Choose an option: ");
                Menu option = (Menu)Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case Menu.ReadDetails:
                        {
                            ReadDetails(ref _peopleList);
                            break;
                        }
                    case Menu.DisplaySortedRetirement:
                        {
                            Console.WriteLine(DisplaySortedRetirement(_peopleList)); 
                            break;
                        }
                    case Menu.DisplayLocals:
                        {
                            Console.WriteLine(DisplayLocals(_peopleList));
                            break;
                        }
                    case Menu.SearchByReference:
                        {
                            Console.WriteLine(SearchByReference(_peopleList));
                            break;
                        }
                    case Menu.Exit:
                        {
                            Exit();
                            break;
                        }
                }
            } while (true);    
        }

        private static List <People> ReadDetails(ref List <People> list)
        {
            Console.Clear();
            bool again = true;

            while (again)
            {
                Console.Clear();

                Console.Write("Enter the reference: ");
                string reference = Console.ReadLine();
                Console.Write("Enter the surname: ");
                string surname = Console.ReadLine();
                Console.Write("Enter the name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the birth year: ");
                int birthYear = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the country of birth: ");
                string countryOfBirth = Console.ReadLine();

                list.Add(new People{reference = reference, surname = surname, name = name, birthYear = birthYear, 
                    countryOfBirth = countryOfBirth});

                Console.Write("Do you want to enter the details of an employee again? (Y/N)");
                string choice = Console.ReadLine();

                if (choice == "Y" || choice == "y")
                {
                    again = true;
                }
                else
                    again = false;
            }

            Console.Clear();
            return list;
        }

        private static string DisplaySortedRetirement(List<People> list)
        {

            List<People> retired = new List<People>();

            Console.Clear();
            string display = "";
            int age;

            foreach (People employee in list)
            {
                age = 2022 - employee.birthYear;
                if (age>59)
                {
                    retired.Add(employee);
                }
            }

            int temp;

            for (int i = 0; i < retired.Count(); i++)
            {
                for (int j = 0; j < retired.Count() -1; j++)
                {
                    if (retired[i].birthYear < retired[j].birthYear)
                    {
                        temp = retired[i].birthYear;
                        retired[i].birthYear = retired[j].birthYear;
                        retired[j].birthYear = temp;
                    }
                }
            }

            foreach (People retiree in retired)
            {
                display += $"{retiree.name} {retiree.surname} ({retiree.birthYear})\n";
            }

            return display;

            Console.ReadKey();
        }

        private static string DisplayLocals(List<People> list)
        {
            Console.Clear();
            string display = "";

            foreach (People person in list)
            {
                if (person.countryOfBirth == "SA")
                {
                    display += $"{person.reference} --> {person.name} {person.surname} ({person.birthYear}) - {person.countryOfBirth}\n";
                }
            }

            return display;
        }

        private static string SearchByReference(List<People> list)
        {
            Console.Clear();
            string display = "";
            bool found = false;

            Console.Write("Enter the reference of the person you want to search for: ");
            string reference = Console.ReadLine();

            for(int i = 0; i < list.Count(); i++)
            {
                if (reference.ToUpper() == list[i].reference)
                {
                    found = true;
                    display = $"{list[i].reference}, {list[i].name} {list[i].surname}, {list[i].birthYear}, {list[i].countryOfBirth}";
                }
            }

            if (found)
            {
                return display;
            }
            else
            {
                display = "Employee not found.";
            }

            return display;
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }
    }

    class People
    {
        public string reference;
        public string surname;
        public string name;
        public int birthYear;
        public string countryOfBirth;
    }

    enum Menu
    {
        ReadDetails = 1,
        DisplaySortedRetirement = 2,
        DisplayLocals = 3,
        SearchByReference = 4,
        Exit = 5
    }

}
