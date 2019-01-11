using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesTaxesCalculator.Entities;
using System.Text.RegularExpressions;

namespace SalesTaxesCalculator.Parsers
{
    public class BasketStringParser
    {
        //Having an input string like 
        /*
         * 1 book at 12.49
         * 1 music CD at 14.99
         * 1 chocolate bar at 0.85                  
         */
        //Get a basket element for each row
        //If an element couldn't be parsed then raise an exception or alter user in some fashion

        private StringBuilder _unparsed;        

        public BasketStringParser()
        {
            this._unparsed = new StringBuilder();
        }

        public void AddProducts(string products)
        {
            this._unparsed.AppendLine(products);
        }
        
        public Basket GetBasket()
        {
            Basket toReturn = new Basket();

            Regex regex = new Regex(@"^([0-9]+)\s(imported\s)?([A-Za-z0-9\s]+)\sat\s([0-9.]+)$");
            string[] lines = this._unparsed.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length <= 0)
            {
                throw new ArgumentException("No line to read");
            }
            else
            {
                foreach (string line in lines)
                {

                    Match match = regex.Match(line);

                    if (match.Groups.Count <= 0)
                    {
                        throw new ArgumentException("A basket element cannot be parsed");
                    }
                    else
                    {
                        int quantity = 0;
                        if (!int.TryParse(match.Groups[1].Value, out quantity))
                        {
                            throw new ArgumentException("Quantity bad format");
                        }

                        ProductStringParser psp = new ProductStringParser(line);
                        Product product = psp.GetProduct();

                        toReturn.Add(new BasketElement(quantity, product));
                    }
                }
            }

            return toReturn;            
        }        
    }
}
