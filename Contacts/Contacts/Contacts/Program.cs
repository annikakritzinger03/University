using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();

            Console.ReadKey();
        }

        private static void MainMenu()
        {
            List <Contacts> contactsList = new List<Contacts>();

            do
            {
                Console.WriteLine(
                    "1. Add contact\n" +
                    "2. Search contact\n" +
                    "3. Delete cotact\n" +
                    "4. Update contact\n" +
                    "5. Display Contacts\n" +
                    "6. Exit program\n");

                int option = ReadInt("Choose an option: ");

                if (option == -1)
                {
                    Console.Clear();
                    Console.WriteLine("Please choose a valid option\n");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        {
                            Console.Clear();
                            AddNew(ref contactsList);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine(SearchContact(contactsList));
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine(DeleteContact(contactsList));
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            UpdateContact(ref contactsList);
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine(DisplayContacts(contactsList));
                            break;
                        }
                    case 6:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Not a valid option.\n");
                            MainMenu();
                            break;
                        }
                }
            } while (true);

        }

        private static int ReadInt(string question)
        {
            Console.Write(question);
            string answer = Console.ReadLine();

            if (int.TryParse(answer, out int number))
            {
                return number;
            }
            else
            {
                return -1;
            }
        }

        private static void AddNew(ref List<Contacts> list)
        {
            bool another = true;
 
            do
            {
                bool valid = false;
                string name = "";

                while (valid == false)
                {
                    Console.Write("Enter a name: ");
                    name = Console.ReadLine();

                    if (int.TryParse(name.Substring(0, 1), out int num))
                    {
                        Console.WriteLine("Not a valid name format.");
                        valid = false;
                    }
                    else
                        valid = true;
                }

                Console.Write("Enter a number: ");
                string number = Console.ReadLine();

                string validNumber = "+27" + number.Substring(1, 2) + "-" + number.Substring(3, 3) + "-" + number.Substring(6, 4);

                list.Add(new Contacts { name = name, number = validNumber});

                Console.Write("Do you want to add another? (Y/N)");
                if (Console.ReadLine().ToUpper() == "N")
                {
                    another = false;
                    Console.Clear();
                }

            } while (another);

        }

        private static string SearchContact(List<Contacts> list)
        {
            string display = "";
            bool found = false;

            Console.WriteLine("Enter the contact name you want searched:");
            string contactName = Console.ReadLine();

            for (int i = 0; i < list.Count(); i++)
            {
                if (contactName == list[i].name)
                {
                    found = true;
                    display = $"{list[i].name} -> {list[i].number}";
                }
            }

            if (found)
            {
                return display;
            }
            else
            {
                display = $"Contact \"{contactName}\" does not exist";
            }

            return display;
        }

        private static string DeleteContact(List<Contacts> list)
        {
            bool found = false;
            string display = "";

            Console.WriteLine("Enter the name of the contact you want to delete:");
            string contactName = Console.ReadLine();

            for (int i = 0; i < list.Count(); i++)
            {
                if (contactName == list[i].name)
                {
                    found = true;
                    list.Remove(list[i]);
                }
            }

            if (found)
            {
                display = $"Contact \"{contactName}\" deleted";
            }
            else
            {
                display = "Contact not found.";
            }

            return display;
        }

        private static void UpdateContact(ref List<Contacts> list)
        {
            string display = "";

            Console.WriteLine("Enter the name of the contact you want to update:");
            string contactName = Console.ReadLine();
            Console.WriteLine("Enter the new number:");
            string updatedNumber = Console.ReadLine();

            updatedNumber = "+27" + updatedNumber.Substring(1, 2) + "-" + updatedNumber.Substring(3, 3) + "-" + updatedNumber.Substring(6, 4);

            for (int i = 0; i < list.Count(); i++)
            {
                if (contactName == list[i].name)
                {
                     list[i].number = updatedNumber;
                }
            }
        }

        private static string DisplayContacts(List<Contacts> list)
        {
            string display = "";

            foreach(Contacts contact in list)
            {
                display += $"{contact.name} -> {contact.number}\t";
            }

            return display;
        }
    }

    public class Contacts
    {
        public string name;
        public string number;
    }
}
