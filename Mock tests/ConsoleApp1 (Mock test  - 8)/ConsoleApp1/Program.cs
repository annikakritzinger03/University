using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Accounts> _accountsList = new List<Accounts>();

            do
            {
                Console.WriteLine(
                    $"{(int)Menu.CaptureDetails}. Capture details\n" +
                    $"{(int)Menu.UpdateAccountBalance}. Withdraw/deposit\n" +
                    $"{(int)Menu.DeleteAccount}. Delete an account\n" +
                    $"{(int)Menu.Sort}. Sort by balance amounts\n");
                Console.Write("Choose an option: ");
                Menu option = (Menu)Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case Menu.CaptureDetails:
                        {
                            Console.Clear();
                            CaptureDetails(ref _accountsList);
                            break;
                        }
                    case Menu.UpdateAccountBalance:
                        {
                            Console.Clear();
                            Console.WriteLine(UpdateAccountBalance(_accountsList)); 
                            break;
                        }
                    case Menu.DeleteAccount:
                        {
                            Console.Clear();
                            Console.WriteLine(DeleteAccount(_accountsList)); 
                            break;
                        }
                    case Menu.Sort:
                        {
                            Console.Clear();
                            Console.WriteLine(Sort(_accountsList));
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Not a valid option.");
                            break;
                        }                        
                }
            } while (true);

            Console.ReadKey();
        }

        private static List<Accounts> CaptureDetails(ref List<Accounts> accountsList)
        {
            bool again = true;
            int length = 0;

            while (again)
            {
                length++;
                Console.Clear();

                Console.Write("Insert the account number: ");
                string accountNum = Console.ReadLine();

                if (accountNum.Substring(0, 3).ToUpper() != "ACC" || 
                    Convert.ToInt32(accountNum.Substring(3, 3)) != length)
                {
                    Console.WriteLine("Enter the account number in the correct format...");
                }

                Console.Write("Insert the account holder's name: ");
                string holderName = Console.ReadLine();
                Console.Write("Insert the current account balance: ");
                int accountBalance = Convert.ToInt32(Console.ReadLine());

                accountsList.Add(new Accounts { accountNum = accountNum, holderName = holderName, balance = accountBalance });

                Console.Write("Do you want to add another account? (Y/N)");
                if (Console.ReadLine().ToUpper() == "N")
                {
                    again = false;
                    Console.Clear();
                }
            }

            return accountsList;
        }

        private static string UpdateAccountBalance(List<Accounts> accountsList)
        {
            string choice = "";
            string display = "Your balance is now R";

            Console.Write("1. Withdraw an amount?\n2.Deposit an amount?\nChoose an option: ");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 1)
            {
                choice = "withdraw";
            }
            else if (answer == 2)
            {
                choice = "deposit";
            }

            Console.Write($"Enter the amount you want to {choice}: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the account number: ");
            string account = Console.ReadLine();

            foreach (Accounts item in accountsList)
            {
                if (account == item.accountNum)
                {
                    if (choice == "withdraw")
                    {
                        item.balance -= amount;
                        display += item.balance;
                    }
                    else if (choice == "deposit")
                    {
                        item.balance += amount;
                        display += item.balance;
                    }
                }
            }

            return display;

        }

        private static string DeleteAccount(List<Accounts> accountsList)
        {
            string display = "Account ";

            Console.Write("Enter the account number: ");
            string account = Console.ReadLine();

            foreach (Accounts item in accountsList)
            {
                if (account == item.accountNum)
                {                  
                    accountsList.Remove(item);
                    display += item.accountNum + " has been deleted.";
                    break;
                }
            }

            return display;
        }

        private static string Sort(List<Accounts> accountsList)
        {
            string display = "";
            int temp;

            for (int i = 0; i < accountsList.Count(); i++)
            {
                for (int j = 0; j < accountsList.Count() - 1; j++)
                {
                    if (accountsList[i].balance < accountsList[j].balance)
                    {
                        temp = accountsList[i].balance;
                        accountsList[i].balance = accountsList[j].balance;
                        accountsList[j].balance = temp;
                    }
                }
            }

            foreach (Accounts item in accountsList)
            {
                display += item.balance + " ";
            }

            return display;
        }
    }

    enum Menu
    { 
        CaptureDetails = 1,
        UpdateAccountBalance = 2,
        DeleteAccount = 3,
        Sort = 4
    }

    public class Accounts
    {
        public string accountNum;
        public string holderName;
        public int balance;
    }

}
