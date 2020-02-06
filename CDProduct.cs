using System;
namespace Inventory
{
    public class CDProduct : Product
    {
        public int numOfTracks { get; set; }

        public CDProduct(string name, int price, int tracks)
        {
            base.name = name;
            base.price = price;
            this.numOfTracks = tracks;
        }
        public CDProduct() { }
    }
}
