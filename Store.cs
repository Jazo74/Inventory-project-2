using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml;

namespace Inventory 
{
    public abstract class Store : IStoreCapable
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
            SaveToXml(product);
            StoreProduct(product);
        }
        
        void SaveToXml(Product product)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root;

            if (File.Exists("Store.xml"))
            {
                doc.Load("Store.xml");
                root = doc.DocumentElement;
                if (product is BookProduct)
                {
                    BookProduct b = (BookProduct)product;
                    XmlNode node2 = doc.CreateElement("product");
                    XmlAttribute attribute2 = doc.CreateAttribute("type");
                    attribute2.Value = "Book";
                    node2.Attributes.Append(attribute2);
                    root.AppendChild(node2);
                    XmlNode node3 = doc.CreateElement("Properties");
                    node2.AppendChild(node3);

                    XmlNode node41 = doc.CreateElement("Property");
                    XmlAttribute attribute41 = doc.CreateAttribute("Title");
                    attribute41.Value = b.name;
                    node41.Attributes.Append(attribute41);
                    node3.AppendChild(node41);

                    XmlNode node42 = doc.CreateElement("Property");
                    XmlAttribute attribute42 = doc.CreateAttribute("Price");
                    attribute42.Value = b.price.ToString();
                    node42.Attributes.Append(attribute42);
                    node3.AppendChild(node42);

                    XmlNode node43 = doc.CreateElement("Property");
                    XmlAttribute attribute43 = doc.CreateAttribute("Pages");
                    attribute43.Value = b.numOfPages.ToString();
                    node43.Attributes.Append(attribute43);
                    node3.AppendChild(node43);

                    doc.Save("Store.xml");
                }
                else
                {
                    CDProduct c = (CDProduct)product;
                    XmlNode node2 = doc.CreateElement("product");
                    XmlAttribute attribute2 = doc.CreateAttribute("type");
                    attribute2.Value = "CD";
                    node2.Attributes.Append(attribute2);
                    root.AppendChild(node2);
                    XmlNode node3 = doc.CreateElement("Properties");
                    node2.AppendChild(node3);

                    XmlNode node41 = doc.CreateElement("Property");
                    XmlAttribute attribute41 = doc.CreateAttribute("Title");
                    attribute41.Value = c.name;
                    node41.Attributes.Append(attribute41);
                    node3.AppendChild(node41);

                    XmlNode node42 = doc.CreateElement("Property");
                    XmlAttribute attribute42 = doc.CreateAttribute("Price");
                    attribute42.Value = c.price.ToString();
                    node42.Attributes.Append(attribute42);
                    node3.AppendChild(node42);

                    XmlNode node43 = doc.CreateElement("Property");
                    XmlAttribute attribute43 = doc.CreateAttribute("Tracks");
                    attribute43.Value = c.numOfTracks.ToString();
                    node43.Attributes.Append(attribute43);
                    node3.AppendChild(node43);

                    doc.Save("Store.xml");
                }
            }
            else
            {
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                root = doc.CreateElement("products");
                doc.AppendChild(root);
                doc.InsertBefore(xmlDeclaration, root);
                if (product is BookProduct)
                {
                    BookProduct b = (BookProduct)product;

                    XmlNode node2 = doc.CreateElement("product");
                    XmlAttribute attribute2 = doc.CreateAttribute("type");
                    attribute2.Value = "Book";
                    node2.Attributes.Append(attribute2);
                    root.AppendChild(node2);
                    XmlNode node3 = doc.CreateElement("Properties");
                    node2.AppendChild(node3);

                    XmlNode node41 = doc.CreateElement("Property");
                    XmlAttribute attribute41 = doc.CreateAttribute("Title");
                    attribute41.Value = b.name;
                    node41.Attributes.Append(attribute41);
                    node3.AppendChild(node41);

                    XmlNode node42 = doc.CreateElement("Property");
                    XmlAttribute attribute42 = doc.CreateAttribute("Price");
                    attribute42.Value = b.price.ToString();
                    node42.Attributes.Append(attribute42);
                    node3.AppendChild(node42);

                    XmlNode node43 = doc.CreateElement("Property");
                    XmlAttribute attribute43 = doc.CreateAttribute("Pages");
                    attribute43.Value = b.numOfPages.ToString();
                    node43.Attributes.Append(attribute43);
                    node3.AppendChild(node43);

                    doc.Save("Store.xml");
                }
                else
                {
                    CDProduct c = (CDProduct)product;
                    XmlNode node2 = doc.CreateElement("product");
                    XmlAttribute attribute2 = doc.CreateAttribute("type");
                    attribute2.Value = "CD";
                    node2.Attributes.Append(attribute2);
                    root.AppendChild(node2);
                    XmlNode node3 = doc.CreateElement("Properties");
                    node2.AppendChild(node3);

                    XmlNode node41 = doc.CreateElement("Property");
                    XmlAttribute attribute41 = doc.CreateAttribute("Title");
                    attribute41.Value = c.name;
                    node41.Attributes.Append(attribute41);
                    node3.AppendChild(node41);

                    XmlNode node42 = doc.CreateElement("Property");
                    XmlAttribute attribute42 = doc.CreateAttribute("Price");
                    attribute42.Value = c.price.ToString();
                    node42.Attributes.Append(attribute42);
                    node3.AppendChild(node42);

                    XmlNode node43 = doc.CreateElement("Property");
                    XmlAttribute attribute43 = doc.CreateAttribute("Tracks");
                    attribute43.Value = c.numOfTracks.ToString();
                    node43.Attributes.Append(attribute43);
                    node3.AppendChild(node43);

                    doc.Save("Store.xml");
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The product has saved to the Store.xml file.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000);
        }
        protected abstract void StoreProduct(Product product);
        public abstract List<Product> LoadProducts();

        public abstract List<Product> GetAllProduct();
    }
}
