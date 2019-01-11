using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxesCalculator.Entities;

namespace SalesTaxesCalculator.Tests
{
    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public void CalculateTaxPrice()
        {
            Product book = new Product("book", 12.49m, ProductCategory.Book, false);
            Assert.IsTrue(book.PriceWithTaxes == 12.49m, "Book price");

            Product musicCD = new Product("cd", 14.99m, ProductCategory.Other, false);
            Assert.IsTrue(musicCD.PriceWithTaxes == 16.49m, "MusicCD price");

            Product importedCocholate = new Product("importedCocholate", 11.25m, ProductCategory.Food, true);
            Assert.IsTrue(importedCocholate.PriceWithTaxes == 11.85m, "Imported Chocolate price");
        }

        [TestMethod]
        public void Basket1()
        {
            Basket basket = new Basket();
            basket.Add(new BasketElement(1, new Product("Book", 12.49m, ProductCategory.Book, false)));
            basket.Add(new BasketElement(1, new Product("MusicCD", 14.99m, ProductCategory.Other, false)));
            basket.Add(new BasketElement(1, new Product("Chocolate", 0.85m, ProductCategory.Food, false)));

            Assert.IsTrue(basket.GetSalesTaxes() == 1.50m, "Wrong sales taxes");
            Assert.IsTrue(basket.GetTotal() == 29.83m, "Wrong total");
        }

        [TestMethod]
        public void Basket2()
        {
            Basket basket = new Basket();
            basket.Add(new BasketElement(1, new Product("Box of chocolates", 10.00m, ProductCategory.Food, true)));
            basket.Add(new BasketElement(1, new Product("Bottle of perfume", 47.50m, ProductCategory.Other, true)));            

            Assert.IsTrue(basket.GetSalesTaxes() == 7.65m, "Wrong sales taxes");
            Assert.IsTrue(basket.GetTotal() == 65.15m, "Wrong total");
        }

        [TestMethod]
        public void Basket3()
        {
            Basket basket = new Basket();            
            basket.Add(new BasketElement(1, new Product("Bottle of perfume", 27.99m, ProductCategory.Other, true)));
            basket.Add(new BasketElement(1, new Product("Bottle of perfume", 18.99m, ProductCategory.Other, false)));
            basket.Add(new BasketElement(1, new Product("Packet of headache pills", 9.75m, ProductCategory.Medical, false)));
            basket.Add(new BasketElement(1, new Product("Box of chocolates", 11.25m, ProductCategory.Food, true)));

            Assert.IsTrue(basket.GetSalesTaxes() == 6.70m, "Wrong sales taxes");
            Assert.IsTrue(basket.GetTotal() == 74.68m, "Wrong total");
        }
    }
}
