using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesTaxesCalculator.Entities;
using SalesTaxesCalculator.Parsers;

namespace SalesTaxesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter products below then press '=' to get receipt");

            BasketStringParser bsp = new BasketStringParser();
            while (true)
            {
                string val = Console.ReadLine();
                if (val.Equals("="))
                    break;

                bsp.AddProducts(val);
            }

            Console.WriteLine(bsp.GetBasket().ToString());

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
