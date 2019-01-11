using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxesCalculator.Entities
{
    public class BasketElement
    {
        public int Quantity { get; private set; }
        public Product Product { get; private set; }

        public BasketElement(int quantity, Product product)
        {
            this.Quantity = quantity;
            this.Product = product;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}: {2}", this.Quantity, this.Product.Name, this.Product.PriceWithTaxes);
        }
    }
}
