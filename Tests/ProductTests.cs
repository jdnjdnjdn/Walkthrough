using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void CanCreateAProduct()
        {
            var product = new Product("Dove Soap", 39.99M);

            Assert.IsTrue(product.Name == "Dove Soap");
            Assert.AreEqual(product.UnitPrice, 39.99M);
        }
    }
}