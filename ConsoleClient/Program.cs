using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFCart.ServiceReference;

namespace SFCart
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClient tc = new TestClient();

            tc.GetShop();
            Console.WriteLine(Environment.NewLine);

            tc.AddItem(1);
            Console.WriteLine(Environment.NewLine);

            tc.AddItem(1);
            Console.WriteLine(Environment.NewLine);

            tc.AddItem(2);
            Console.WriteLine(Environment.NewLine);

            tc.AddItem(5);
            Console.WriteLine(Environment.NewLine);

            tc.AddItem(5);
            Console.WriteLine(Environment.NewLine);

            tc.RemoveItem(5);
            Console.WriteLine(Environment.NewLine);

            tc.GetCart();
            Console.WriteLine(Environment.NewLine);

            Console.ReadLine();
        }
    }
}
