using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Threading;

namespace Inventory
{
    public class PersistentStore : Store
    {
        public List<Product> productList = new List<Product>();

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
            XmlSerializer xmlReader = new XmlSerializer(productList.GetType());
            FileStream file = new FileStream("Book&CDShop.xml", FileMode.Open);
            List<Product> newList = (List<Product>)xmlReader.Deserialize(file);
            file.Close();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The deSerialization has completed.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000);
            return newList;
        }
    }

}
