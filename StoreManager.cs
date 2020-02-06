using System;
using System.Collections.Generic;
namespace Inventory
{
    public class StoreManager
    {
        IStoreCapable myStorage;
        
        public void AddStorage(IStoreCapable store)
        {
            myStorage = store;
        }
        public void AddCDProduct(string name, int price, int tracks)
        {
            myStorage.StoreCDProduct(name, price, tracks);
        }
        public void AddBookProduct(string name, int price, int pages)
        {
            myStorage.StoreBookProduct(name, price, pages);
        }
        public List<Product> ListProducts()
        {
            List<Product> productList = myStorage.GetAllProduct();
            return productList;
        }
        public int GetTotalProductPrice()
        {
            int value = 0;
            foreach (Product product in ListProducts())
            {
                value += product.price;
            }
            return value;
        }

    }
}
