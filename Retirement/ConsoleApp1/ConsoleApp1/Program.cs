using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        private static List<Pizzas> _pizzaList = new List<Pizzas>();
        static void Main(string[] args)
        {
            MainMenuDisplay();

            Console.ReadKey();
        }

        private static void MainMenuDisplay()
        {
            do
            {          
                Console.WriteLine(
                    $"{(int)Menu.ReadOrder}. New Order\n" +
                    $"{(int)Menu.Checkout}. Go to checkout\n");
                Console.Write("Choose an option: ");
                Menu option = (Menu)Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case Menu.ReadOrder:
                        {
                            Console.Clear();
                            ReadOrder();
                            break; 
                        }                     
                    case Menu.Checkout:
                        {
                            Console.Clear();
                            CheckOut();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Not a valid option. Choose again.");
                            break;
                        }                      
                }

            } while (true);
        }

        private static void ReadOrder()
        {
            Console.WriteLine(
                    $"{(int)Sizes.Large}. Large\n" +
                    $"{(int)Sizes.Medium}. Medium\n" +
                    $"{(int)Sizes.Small}. Small\n");

            Console.Write("Choose a size: ");
            Sizes size = (Sizes)Convert.ToInt32(Console.ReadLine());

            Console.Write($"Enter the number of {size} pizzas you want: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            _pizzaList.Add(new Pizzas { size = size, amount = amount });

            Console.Clear();
        }

        private static void CheckOut()
        {
            double totalAmount = 0;
            string display = "";


            foreach (Pizzas pizza in _pizzaList)
            {
                double unitPrice = 0;

                switch (pizza.size)
                {
                    case Sizes.Large:
                        {
                            unitPrice = 50;
                            break;
                        }
                    case Sizes.Medium:
                        {
                            unitPrice = 25;
                            break;
                        }
                    case Sizes.Small:
                        {
                            unitPrice = 15;
                            break;
                        }
                }

                double total = unitPrice * pizza.amount;
                totalAmount += total;

                Console.WriteLine($"{pizza.size}\tX {pizza.amount}\tR{total}\n");
            }

            Console.WriteLine($"Total Due: R{totalAmount}\n");

            Console.Write("Do you want to choose again? (Y/N): ");
            string again = Console.ReadLine();

            if (again.ToUpper() == "Y")
            {
                Console.Clear();
                _pizzaList.Clear();
                MainMenuDisplay();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }

    class Pizzas
    {
        public Sizes size;
        public int amount;
    }

    enum Sizes
    { 
        Large = 1,
        Medium = 2,
        Small = 3
    }
    enum Menu
    { 
        ReadOrder = 1,
        Checkout = 2
    }


}
