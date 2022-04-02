using BasketProject;
using BasketProject.Offers;
using BasketProject.Products;
using BasketUnitTests.TestOffers;
using BasketUnitTests.TestProducts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BasketUnitTests
{
    [TestClass]
    public class BasketUnitTests
    {
        [TestCleanup]
        public void CleanUp() 
        {
            OffersSingleton.Instance.CurrentOffers.Clear();
        }

        [TestMethod]
        public void GetTotalPrice_GivenNullBasket_ShouldReturnZero()
        {
            // arrange
            var basket = new Basket();

            // act
            var result = basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£0.00", result);
        }

        [TestMethod]
        public void GetTotalPrice_GivenEmptyBasket_ShouldReturnZero()
        {
            // arrange
            var basket = new Basket 
            {
                Products = Enumerable.Empty<ProductBase>().ToArray() 
            };

            // act
            var result = basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£0.00", result);
        }

        [TestMethod]
        public void GetTotalPrice_GivenTestProducts_ShouldReturnSum()
        {
            // arrange
            var basket = new Basket 
            {
                Products = new List<ProductBase>
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
        
        [TestMethod]
        public void GetTotalPrice_GivenTestOfferInvalid_ShouldReturnSum()
        {
            // arrange
            OffersSingleton.Instance.CurrentOffers.Add(new TestOffer1());
            var basket = new Basket 
            {
                Products = new List<ProductBase>
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

        [TestMethod]
        public void GetTotalPrice_GivenTestOfferValid_ShouldReturnDiscountedSum()
        {
            // arrange
            OffersSingleton.Instance.CurrentOffers.Add(new TestOffer1());
            var basket = new Basket 
            {
                Products = new List<ProductBase>
                {
                    new TestProduct1(),
                    new TestProduct2(),
                    new TestProduct2()
                }
            };

            // act
            var result = basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£5.68", result);
        }

        [TestMethod]
        public void GetTotalPrice_GivenOfferValidWithoutOffer_ShouldReturnDiscountedSum()
        {
            // arrange
            var basket = new Basket 
            {
                Products = new List<ProductBase>
                {
                    new TestProduct1(),
                    new TestProduct2(),
                    new TestProduct2()
                }
            };

            // act
            var result = basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£6.40", result);
        }
    }
}
