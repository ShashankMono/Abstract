using System.Security.Cryptography;
using UseOfAbstractInterface.Models;

namespace UseOfAbstractInterface
{
    internal class Program
    {
        public static Store[] storeDatabase = new Store[0];
        public static Store currentCustomer = null;
        public static string CurrentCustomerName;
        public static string CurrentCustomerContact;
        static void Main(string[] args)
        {
            DisplayMenu();
        }

        public static void DisplayMenu()
        {
            bool[] run = {true};
            while (run[0])
            {
                Console.WriteLine($"\n0.Exit\n" +
                    $"1.Add Customer\n" +
                    $"2.Add product to cart\n" +
                    $"3.Checkout\n" +
                    $"4.Add staff\n" +
                    $"5.Show databse\n");

                int choice = int.Parse( Console.ReadLine() );
                ImplementingCases(choice, run);
            }
        } 

        public static void ImplementingCases(int choice, bool[] run)
        {
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Thank you!");
                    break;

                case 1:
                    AddCustomer();
                    break;

                case 2:
                    Console.WriteLine((currentCustomer != null) ? AddToCart() : "\nPlease add customer first");
                    break;
                    
                case 3:
                    Console.WriteLine((currentCustomer != null) ? CheckOut() : "\nPlease add customer first");
                    break;

                case 4:
                    AddStaff();
                    break;
 
                case 5:
                    ShowDatabase(); break;

                default:
                    Console.WriteLine("Enter correct option");
                    break;

            }
        } 

        public static void AddCustomer()
        {
            TakeInput("Customer");
            Store person = new Customer(CurrentCustomerName,CurrentCustomerContact);
            currentCustomer = person;
            Resize(person);
        }

        public static string CheckOut() {
            Console.WriteLine(currentCustomer.ShowCart());
            currentCustomer = null;
            return "Checked Out!";

        }

        public static void AddStaff()
        {
            TakeInput("Customer");
            Console.WriteLine("Enter Id of staff");
            int id = int.Parse(Console.ReadLine());
            Store person = new Staff(CurrentCustomerName, CurrentCustomerContact,id);
            currentCustomer = person;
            Resize(person);
        }

        public static string AddToCart()
        {
            Console.WriteLine("Enter product name : ");
            string product =  Console.ReadLine();
            Console.WriteLine("Enter price of product : ");
            double price = double.Parse(Console.ReadLine());
            currentCustomer.AddToCart(product,price);
            return $"Sucessfully {product} added";
        }

        public static void TakeInput(string person)
        {
            Console.WriteLine($"Enter {person} Name: ");
            CurrentCustomerName = Console.ReadLine();
            Console.WriteLine($"Enter {person} Contact Number: ");
            CurrentCustomerName = Console.ReadLine();
        }

        public static void Resize(Store person)
        {
            Array.Resize(ref storeDatabase, storeDatabase.Length + 1);
            storeDatabase[storeDatabase.Length - 1] = person;
        }

        public static void ShowDatabase()
        {
            foreach (Store store in storeDatabase)
            {
                Console.WriteLine("============================");
                Console.WriteLine(store.Details());
                Console.WriteLine("============================");
            }
        }

    }
}
