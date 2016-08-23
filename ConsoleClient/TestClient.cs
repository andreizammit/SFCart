using SFCart.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFCart
{
    public class TestClient
    {
        private CartClient client = null;

        public TestClient()
        {
            this.client = new CartClient();
            Console.WriteLine("Cart Init");
        }

        public void GetShop()
        {
            GetShopItemsRequest gir = new GetShopItemsRequest();
            GetShopItemsResponse response = this.client.GetShopItems(gir);

            Console.WriteLine("SHOP");
            foreach (Item i in response.GetShopItemsResult)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(string.Format("ID: {0}", i.ID));
                Console.WriteLine(string.Format("Name: {0}", i.Name));
                Console.WriteLine(string.Format("Amount: {0}", i.Amount));
                Console.WriteLine(string.Format("Price: {0}", i.Price));
            }            
        }

        public void AddItem(int id)
        {
            AddItemRequest air = new AddItemRequest(id);
            AddItemResponse response = this.client.AddItem(air);
            Console.WriteLine(string.Format("Add item: {0}", response.AddItemResult));
        }

        public void RemoveItem(int id)
        {
            RemoveItemRequest rir = new RemoveItemRequest(id);
            RemoveItemResponse response = this.client.RemoveItem(rir);
            Console.WriteLine(string.Format("Remove item: {0}", response.RemoveItemResult));
        }

        public void GetCart()
        {
            GetCartItemsRequest cir = new GetCartItemsRequest();
            GetCartItemsResponse response = this.client.GetCartItems(cir);

            Console.WriteLine("CART");
            foreach (Item i in response.GetCartItemsResult)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(string.Format("ID: {0}", i.ID));
                Console.WriteLine(string.Format("Name: {0}", i.Name));
                Console.WriteLine(string.Format("Amount: {0}", i.Amount));
                Console.WriteLine(string.Format("Price: {0}", i.Price));
            }
        }
    }
}
