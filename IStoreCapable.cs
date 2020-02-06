using System;
using System.Collections.Generic;

namespace Inventory
{
    public interface IStoreCapable
    {
        public List<Product> GetAllProduct();
        public void StoreCDProduct(string name, int price, int tracks);
        public void StoreBookProduct(string name, int price, int pages);
    }

}
