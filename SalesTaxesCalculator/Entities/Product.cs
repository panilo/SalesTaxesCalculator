using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxesCalculator.Entities
{
    public class Product
    {
        public string Name { get; private set; }
        public bool Imported { get; private set; }
        public ProductCategory Category { get; private set; }
        public decimal Price { get; private set; }
        
        public decimal PriceWithTaxes {
            get
            {
                return this.Price + this.SaleTax;
            }
        }

        private decimal _saleTax = -1;
        public decimal SaleTax
        {
            get
            {
                if (_saleTax < 0)
                    _saleTax = this.CalcSaleTax();
                return _saleTax;
            }
        }

        private decimal _taxRatio = -1;
        public decimal TaxRatio {
            get
            {
                if (_taxRatio < 0)
                    _taxRatio = this.CalculateTaxRatio();
                return _taxRatio;
            }
        }

        public Product(string name, decimal price, ProductCategory category, bool imported)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
            this.Imported = imported;
        }

        private decimal CalcSaleTax()
        {
            if (this.TaxRatio > 0)
            {
                decimal taxes = (this.Price * this.TaxRatio) / 100;
                taxes = Math.Ceiling(taxes / 0.05m) * 0.05m;
                return taxes;
            }
            else
            {
                return 0;
            }
        }

        private decimal CalculateTaxRatio()
        {
            decimal baseTaxRation = 10;
            if (this.Category == ProductCategory.Book
                || this.Category == ProductCategory.Food
                || this.Category == ProductCategory.Medical)
            {
                baseTaxRation = 0;
            }

            return baseTaxRation + (this.Imported ? 5 : 0);
        }
    }
}
