using System;
using System.Collections.Generic;
using System.Threading;

namespace Inventory
{
    public abstract class CSvStore : IStoreCapable
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The product has saved to the xml file.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000);
        }
        protected abstract void StoreProduct(Product product);
        public abstract List<Product> LoadProducts();

        public abstract List<Product> GetAllProduct();
    }
}
