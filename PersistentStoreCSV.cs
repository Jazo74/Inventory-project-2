using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Threading;

namespace Inventory
{
    public class PersistentStoreCSV : StoreCSV
    {
        public List<Product> productList = new List<Product>();

        public PersistentStoreCSV()
        {
            if (File.Exists("Store.csv"))
            {
                productList = LoadProducts();
                Console.WriteLine("The store database has loaded.");
            }
        }
        protected override void StoreProduct(Product product)
        {
            productList.Add(product);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The product has stored to a list in the memory.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override List<Product> GetAllProduct()
        {
            return productList;
        }
        public override List<Product> LoadProducts()
        {
            List<Product> products = new List<Product>();
            string type;
            string name;
            int price;
            int size;
            StreamReader streamReader = new StreamReader("Store.csv");
            while (!streamReader.EndOfStream)
            {
                string[] line = streamReader.ReadLine().Split(";") ;
                type = line[0];
                name = line[1];
                price = int.Parse(line[2]);
                size = int.Parse(line[3]);
                {
                    if (type == "Book")
                    {
                        BookProduct bookProduct = new BookProduct();
                        bookProduct.name = name;
                        bookProduct.price = price;
                        bookProduct.numOfPages = size;
                        products.Add(bookProduct);
                    }
                    else
                    {
                        CDProduct cdProduct = new CDProduct();
                        cdProduct.name = name;
                        cdProduct.price = price;
                        cdProduct.numOfTracks = size;
                        products.Add(cdProduct);
                    }
                }
            }
            streamReader.Close();
            return products;
        }
    }
}
