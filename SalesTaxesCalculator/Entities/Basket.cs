using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxesCalculator.Entities
{
    public class Basket : List<BasketElement>
    {        
        public decimal GetSalesTaxes()
        {
            return this.Sum(be => be.Quantity * be.Product.SaleTax);
        }

        public decimal GetTotal()
        {
            return this.Sum(be => be.Quantity * be.Product.PriceWithTaxes);
        }
    }
}
