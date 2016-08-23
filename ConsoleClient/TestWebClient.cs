using SFCart.ServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using SFCart;

namespace SFCart
{
    internal class TestWebClient
    {
        WebClient proxy = null;

        public TestWebClient()
        {
            this.proxy = new WebClient();
        }

        public void ShowCart()
        {
            string shopUrl = string.Format("http://localhost:1195/ShoppingCart.svc/Shop");
            byte[] data = this.proxy.DownloadData(shopUrl);
            using (Stream stream = new MemoryStream(data))
            { 
                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(Item));
                Item item = obj.ReadObject(stream) as Item;
                Console.WriteLine(string.Format("Item ID: {}",item.ID));
                Console.WriteLine(string.Format("Item Name: {}", item.Name));
                Console.WriteLine(string.Format("Item Amount: {}", item.Amount));
                Console.WriteLine(string.Format("Item Price: {}", item.Price));
            }
        }
    }
}
