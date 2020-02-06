using System;
namespace Inventory
{   
    public class BookProduct : Product
    {
        public int numOfPages { get; set; }

        public BookProduct(string name, int price, int pages)
        {
            base.name = name;
            base.price = price;
            this.numOfPages = pages;
        }
        public BookProduct() { }
    }
}
