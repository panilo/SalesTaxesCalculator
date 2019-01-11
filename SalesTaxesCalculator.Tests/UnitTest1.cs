using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxesCalculator.Entities;

namespace SalesTaxesCalculator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void General()
        {
            Product book = new Product("book", 12.49m, ProductCategory.Book, false);
            Assert.IsTrue(book.PriceWithTaxes == 12.49m, "Book price");

            Product musicCD = new Product("cd", 14.99m, ProductCategory.Other, false);
            Assert.IsTrue(musicCD.PriceWithTaxes == 16.49m, "MusicCD price");

            Product importedCocholate = new Product("importedCocholate", 11.25m, ProductCategory.Food, true);
            Assert.IsTrue(importedCocholate.PriceWithTaxes == 11.85m, "Imported Chocolate price");
        }
    }
}
