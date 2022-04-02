using BasketProject;
using BasketProject.Products;
using BasketUnitTests.TestProducts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BasketUnitTests
{
    [TestClass]
    public class BasketUnitTests
    {
        [TestMethod]
        public void GetTotalPrice_GivenNullBasket_ShouldReturnZero()
        {
            // arrange
            var basket = new Basket();

            // act
            var result = basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£0", result);
        }

        [TestMethod]
        public void GetTotalPrice_GivenEmptyBasket_ShouldReturnZero()
        {
            // arrange
            var basket = new Basket 
            {
                Products = Enumerable.Empty<IProduct>().ToArray() 
            };

            // act
            var result = basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£0", result);
        }

        [TestMethod]
        public void GetTotalPrice_GivenTestProducts_ShouldReturnSum()
        {
            // arrange
            var basket = new Basket 
            {
                Products = new List<IProduct>
                {
                    new TestProduct1(),
                    new TestProduct2()
                }
            };

            // act
            var result = basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£4.95", result);
        }
    }
}
