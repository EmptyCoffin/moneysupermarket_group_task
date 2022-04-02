using BasketUnitTests.TestProducts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasketUnitTests.Products
{
    [TestClass]
    public class ProductBaseTests
    {
        [TestMethod]
        public void Price_GivenNoDiscount_ShouldReturnOriginalPrice()
        {
            // arrange
            var product = new TestProduct1();

            // act
            var result = product.Price;

            // assert
            Assert.AreEqual(product.OriginalPrice, result);
        }

        [DataTestMethod]
        [DataRow(30, 2.45)]
        [DataRow(100, 0)]
        [DataRow(0, 3.50)]
        public void Price_GivenDiscount_ShouldReturnDiscountedPrice(double discount, double expectedValue)
        {
            // arrange
            var product = new TestProduct1
            {
                Dicount = (decimal)discount
            };

            // act
            var result = product.Price;

            // assert
            Assert.AreEqual((decimal)expectedValue, result);
        }
    }
}