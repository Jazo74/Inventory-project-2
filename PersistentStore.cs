using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Threading;

namespace Inventory
{
    public class PersistentStore : Store
    {
        public List<Product> productList = new List<Product>();

        public PersistentStore()
        {
            if (File.Exists("Store.xml"))
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
            XmlDocument doc = new XmlDocument();
            doc.Load("Store.xml");
            XmlNode root = doc.DocumentElement;
            foreach (XmlNode xmlNode in root)
            {
                type = xmlNode.Attributes["type"].Value;
                name = xmlNode.ChildNodes[0].ChildNodes[0].Attributes[0].Value;
                price = int.Parse(xmlNode.ChildNodes[0].ChildNodes[1].Attributes[0].Value);
                size = int.Parse(xmlNode.ChildNodes[0].ChildNodes[2].Attributes[0].Value);
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
            return products;
        }
    }

}
