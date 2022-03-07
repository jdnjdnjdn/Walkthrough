using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Tests
{
    [TestClass]
    public class ShoppingCartTests
    {

        [TestMethod]
        public void CanCreateAShoppingCart()
        {
            var cart = new ShoppingCart();
            Assert.IsTrue(cart.LineItems.Count == 0);
        }

        [TestMethod]
        public void CanAddASingleProduct()
        {
            var cart = new ShoppingCart();
            var product = new Product("Dove Soap", 39.99M);

            cart.AddProduct(product);

            Assert.IsTrue(cart.LineItems.Count == 1);
            Assert.IsTrue(cart.TotalPrice == 39.99M);
        }

        [TestMethod]
        public void CanAddMultipleProducts()
        {
            var cart = new ShoppingCart();
            var product = new Product("Dove Soap", 39.99M);

            cart.AddProduct(product, 5);
            cart.AddProduct(product, 3);

            Assert.IsTrue(cart.LineItems.Count == 1);
            Assert.IsTrue(cart.GetProductQuantity("Dove Soap") == 8);
            Assert.IsTrue(cart.TotalPrice == 319.92M);
        }

        [TestMethod]
        public void CanCalculateTaxRateWithManyProducts()
        {
            var cart = new ShoppingCart();
            var doveProduct = new Product("Dove Soap", 39.99M);
            var axeProduct = new Product("Axe Deos", 99.99M);
            var taxRate = .125M;

            cart.AddProduct(doveProduct, 2);
            cart.AddProduct(axeProduct, 2);
            cart.TaxRate = taxRate;

            Assert.IsTrue(cart.GetProductQuantity("Dove Soap") == 2);
            Assert.IsTrue(cart.GetProductQuantity("Axe Deos") == 2);
            Assert.IsTrue(cart.TotalSalesTax == 35.00M);
            Assert.IsTrue(cart.TotalPrice == 314.96M);
        }
    }
}
