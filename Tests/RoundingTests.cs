using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class RoundingTests
    {
        [TestMethod]
        public void ShouldRoundUp()
        {
            var product = new Product("Roundup", .565M);

            Assert.IsTrue(product.UnitPrice == .57M);
        }

        [TestMethod]
        public void ShouldRoundDown()
        {
            var product = new Product("Roundup", .5649M);

            Assert.IsTrue(product.UnitPrice == .56M);
        }
    }
}
