using System;
using System.IO;

namespace Inventory
{
    class Program
    {
        static public StoreManager storeManager;
        static void Main(string[] args)
        {
            storeManager = new StoreManager();
            if (args.Length > 0 && args[0] == "xml")
            {
                PersistentStoreCSV myStore = new PersistentStoreCSV();
                storeManager.AddStorage(myStore);
            }
            else
            {
                PersistentStore myStore = new PersistentStore();
                storeManager.AddStorage(myStore);
            }
            bool loop = true;
            while (loop)
            {
                Menu();
                loop = Choose();
            }
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the My Store");
            Console.WriteLine();
            Console.WriteLine("(1) Store a new book");
            Console.WriteLine("(2) Store a new CD");
            Console.WriteLine("(3) List all the products");
            Console.WriteLine("(4) The value of all the stored product");
            Console.WriteLine("(0) Exit program");
        }
        static bool Choose()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine();
                    storeManager.AddBookProduct(AnyInput("The name of the book: "), JustNumber("The price of the book: "), JustNumber("Number of pages: "));
                    return true;
                case "2":
                    Console.WriteLine();
                    storeManager.AddCDProduct(AnyInput("The name of the CD: "), JustNumber("The price of the CD: "), JustNumber("Number of tracks: "));
                    return true;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Store inventory list");
                    Console.WriteLine();
                    Console.WriteLine("Type          Title                           Size           Price");
                    Console.WriteLine("------------------------------------------------------------------");

                    foreach (Product product in storeManager.ListProducts())
                    {
                        if (product is BookProduct)
                        {
                            Console.Write("Book  ");
                            BookProduct book = (BookProduct)product;
                            Console.Write(book.name.PadRight(40));
                            string pages = book.numOfPages.ToString() + " pages";
                            Console.Write(pages.PadRight(15));
                            string price = book.price.ToString() + " $";
                            Console.WriteLine(price.PadLeft(5));
                        }
                        else
                        {
                            Console.Write("CD    ");
                            CDProduct cd = (CDProduct)product;
                            Console.Write(cd.name.PadRight(40));
                            string tracks = cd.numOfTracks.ToString() + " tracks";
                            Console.Write(tracks.PadRight(15));
                            string price = cd.price.ToString() + " $";
                            Console.WriteLine(price.PadLeft(5));
                        }
                    }
                    Console.WriteLine();
                    AnyInput("Press any key to continue...");
                    return true;
                case "4":
                    Console.WriteLine();
                    Console.WriteLine("The value of all products in the store: " + Convert.ToString(storeManager.GetTotalProductPrice()) + " $.");
                    AnyInput("Press any key to continue...");
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }
        public static int JustNumber(string inputMessage)
        {
            int number;
            string input;
            while (true)
            {
                Console.Write(inputMessage);
                input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    return int.Parse(input);
                }
                else
                {
                    Console.WriteLine("It is not a number!");
                }
            }
        }
        public static string AnyInput(string inputMessage)
        {
            Console.Write(inputMessage);
            return Console.ReadLine();
        }
    }
}
