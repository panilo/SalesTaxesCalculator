using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxesCalculator.Parsers;
using SalesTaxesCalculator.Entities;

namespace SalesTaxesCalculator.Tests
{
    [TestClass]
    public class ParsersTests
    {
        [TestMethod]
        public void ProductStringParserTest1()
        {
            string productDefinition = "1 book at 12.49";
            ProductStringParser psp = new ProductStringParser(productDefinition);
            Product p = psp.GetProduct();

            Assert.IsNotNull(p);
            Assert.IsTrue(p.Price == 12.49m);
            Assert.IsTrue(p.Name.Equals("book", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(p.Category == ProductCategory.Book);
            Assert.IsFalse(p.Imported);
        }


        [TestMethod]
        public void ProductStringParserTest2()
        {
            string productDefinition = "1 music CD at 14.99";
            ProductStringParser psp = new ProductStringParser(productDefinition);
            Product p = psp.GetProduct();

            Assert.IsNotNull(p);
            Assert.IsTrue(p.Price == 14.99m);
            Assert.IsTrue(p.Name.Equals("music cd", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(p.Category == ProductCategory.Other);
            Assert.IsFalse(p.Imported);
        }

        [TestMethod]
        public void ProductStringParserTest3()
        {
            string productDefinition = "1 chocolate bar at 0.85";
            ProductStringParser psp = new ProductStringParser(productDefinition);
            Product p = psp.GetProduct();

            Assert.IsNotNull(p);
            Assert.IsTrue(p.Price == 0.85m);
            Assert.IsTrue(p.Name.Equals("chocolate bar", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(p.Category == ProductCategory.Food);
            Assert.IsFalse(p.Imported);
        }

        [TestMethod]
        public void ProductStringParserTest4()
        {
            string productDefinition = "1 imported bottle of perfume at 27.99";
            ProductStringParser psp = new ProductStringParser(productDefinition);
            Product p = psp.GetProduct();

            Assert.IsNotNull(p);
            Assert.IsTrue(p.Price == 27.99m);
            Assert.IsTrue(p.Name.Equals("bottle of perfume", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(p.Category == ProductCategory.Other);
            Assert.IsTrue(p.Imported);
        }

        [TestMethod]
        public void ProductStringParserTest5()
        {
            string productDefinition = "1 box of imported chocolates at 11.25";
            ProductStringParser psp = new ProductStringParser(productDefinition);
            Product p = psp.GetProduct();

            Assert.IsNotNull(p);
            Assert.IsTrue(p.Price == 11.25m);
            Assert.IsTrue(p.Name.Equals("box of chocolates", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(p.Category == ProductCategory.Food);
            Assert.IsTrue(p.Imported);
        }

        [TestMethod]
        public void BasketStringParserTest1()
        {
            BasketStringParser bsp = new BasketStringParser();
            bsp.AddProducts("1 book at 12.49");
            bsp.AddProducts("1 music CD at 14.99");
            bsp.AddProducts("1 chocolate bar at 0.85");

            Basket b = bsp.GetBasket();
            Assert.IsNotNull(b);
            Assert.IsTrue(b.Count == 3);
        }
    }
}
