using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SalesTaxesCalculator.Entities;

namespace SalesTaxesCalculator.Parsers
{
    public class ProductStringParser
    {
        private string _unparsed;

        public ProductStringParser(string product)
        {
            this._unparsed = product;
        }

        public Product GetProduct()
        {
            Regex regex = new Regex(@"^([0-9]+)\s(imported\s)?([A-Za-z0-9\s]+)\sat\s([0-9.]+)$");
            Match match = regex.Match(this._unparsed);

            if (match.Groups.Count <= 0)
            {
                throw new ArgumentException("A product cannot be parsed");
            }
            else
            {                             
                string productName = match.Groups[3].Value;
                bool imported = string.IsNullOrEmpty(match.Groups[2].Value) ? false : true;
                if (productName.ToLower().Contains("imported"))
                {
                    imported = true;
                    productName = productName.ToLower().Replace("imported ", "");
                }

                ProductCategory productCategory = ProductCategory.Other;
                if (productName.ToLowerInvariant().Contains("book"))
                {
                    productCategory = ProductCategory.Book;
                }
                if (productName.ToLowerInvariant().Contains("chocolate"))
                {
                    productCategory = ProductCategory.Food;
                }
                if (productName.ToLowerInvariant().Contains("pills"))
                {
                    productCategory = ProductCategory.Medical;
                }

                decimal price = 0;
                if (!decimal.TryParse(match.Groups[4].Value, out price))
                {
                    throw new ArgumentException("Price bad format");
                }

                Product product = new Product(productName, price, productCategory, imported);                

                return product;
            }
        }
    }
}
