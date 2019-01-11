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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(BasketElement be in this)
            {
                sb.AppendLine(be.ToString());
            }            
            sb.AppendFormat("Sales Taxes: {0}{1}", this.GetSalesTaxes(), Environment.NewLine);
            sb.AppendFormat("Total: {0}", this.GetTotal());

            return sb.ToString();
        }
    }
}
