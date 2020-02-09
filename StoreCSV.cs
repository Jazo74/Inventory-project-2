using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Inventory
{
    public abstract class StoreCSV : IStoreCapable
    {
        public void StoreBookProduct(string name, int price, int pages)
        {
            store(CreateProduct("Book", name, price, pages));
        }
        public void StoreCDProduct(string name, int price, int tracks)
        {
            store(CreateProduct("CD", name, price, tracks));
        }
        protected Product CreateProduct(string type, string name, int price, int size)
        {
            if (type == "Book")
            {
                Product newProduct = new BookProduct(name, price, size);
                return newProduct;
            }
            else
            {
                Product newProduct = new CDProduct(name, price, size);
                return newProduct;
            }
        }
        public void store(Product product)
        {
            SaveToCSV(product);
            StoreProduct(product);
        }
        /*public void StoreToMemory(List<Product> products)
        {
            foreach (Product product in products)
            {
                StoreProduct(product);
            }
        }*/
        void SaveToCSV(Product product)
        {
            StreamWriter streamWriter = new StreamWriter("Store.csv", true);
            if (product is BookProduct)
            {
                BookProduct b = (BookProduct)product;
                string record = "Book;";
                record += b.name + ";";
                record += b.price.ToString() + ";";
                record += b.numOfPages.ToString();
                streamWriter.WriteLine(record);
            }
            else
            {
                CDProduct c = (CDProduct)product;
                string record = "CD;";
                record += c.name + ";";
                record += c.price.ToString() + ";";
                record += c.numOfTracks.ToString();
                streamWriter.WriteLine(record);
            }
            streamWriter.Close();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The product has saved to the Store.csv file.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000);
        }
        protected abstract void StoreProduct(Product product);
        public abstract List<Product> LoadProducts();
        public abstract List<Product> GetAllProduct();
    }
}
