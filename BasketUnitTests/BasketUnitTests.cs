using BasketProject;
using BasketProject.Offers;
using BasketProject.Products;
using BasketUnitTests.TestOffers;
using BasketUnitTests.TestProducts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BasketUnitTests
{
    [TestClass]
    public class BasketUnitTests
    {
        private Basket _basket;
        private Mock<IOfferService> _mockService;
        private List<OfferBase> _offers;

        [TestInitialize]
        public void Initialise()
        {
            _offers = new List<OfferBase>();
            _mockService = new Mock<IOfferService>();
            _mockService.Setup(s => s.GetCurrentOffers()).Returns(() => _offers).Verifiable();

            _basket = new Basket(_mockService.Object);
        }

        [TestCleanup]
        public void CleanUp() 
        {
            _offers = null;
            _mockService = null;
            _basket = null;
        }

        [TestMethod]
        public void GetTotalPrice_GivenNullBasket_ShouldReturnZero()
        {
            // act
            var result = _basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£0.00", result);
            _mockService.Verify(v => v.GetCurrentOffers(), Times.Never);
        }

        [TestMethod]
        public void GetTotalPrice_GivenEmptyBasket_ShouldReturnZero()
        {
            // arrange
            _basket.Products = Enumerable.Empty<ProductBase>().ToArray();

            // act
            var result = _basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£0.00", result);
            _mockService.Verify(v => v.GetCurrentOffers(), Times.Never);
        }

        [TestMethod]
        public void GetTotalPrice_GivenTestProducts_ShouldReturnSum()
        {
            // arrange
            _basket.Products = new List<ProductBase>
                {
                    new TestProduct1(),
                    new TestProduct2()
                };

            // act
            var result = _basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£4.95", result);
            _mockService.Verify(v => v.GetCurrentOffers(), Times.Once);
        }
        
        [TestMethod]
        public void GetTotalPrice_GivenTestOfferInvalid_ShouldReturnSum()
        {
            // arrange
            _offers.Add(new TestOffer1());
            _basket.Products = new List<ProductBase>
                {
                    new TestProduct1(),
                    new TestProduct2()
                };

            // act
            var result = _basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£4.95", result);
            _mockService.Verify(v => v.GetCurrentOffers(), Times.Once);
        }

        [TestMethod]
        public void GetTotalPrice_GivenTestOfferValid_ShouldReturnDiscountedSum()
        {
            // arrange
            _offers.Add(new TestOffer1());
            _basket.Products = new List<ProductBase>
                {
                    new TestProduct1(),
                    new TestProduct2(),
                    new TestProduct2()
                };

            // act
            var result = _basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£5.68", result);
            _mockService.Verify(v => v.GetCurrentOffers(), Times.Once);
        }

        [TestMethod]
        public void GetTotalPrice_GivenOfferValidWithoutOffer_ShouldReturnDiscountedSum()
        {
            // arrange
            _basket.Products = new List<ProductBase>
                {
                    new TestProduct1(),
                    new TestProduct2(),
                    new TestProduct2()
                };

            // act
            var result = _basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£6.40", result);
            _mockService.Verify(v => v.GetCurrentOffers(), Times.Once);
        }
    }
}
