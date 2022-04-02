using BasketProject.Products;
using BasketUnitTests.TestOffers;
using BasketUnitTests.TestProducts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BasketUnitTests.Offers
{
    [TestClass]
    public class OfferBaseTests
    {
        [TestMethod]
        public void CheckOffer_GivenOfferInvalid_ShouldNotHaveAnyDiscounts()
        {
            // arrange
            var offer = new TestOffer1();
            var products = new List<ProductBase>()
            {
                new TestProduct2()
            };

            // act
            offer.CheckOffer(products);

            // assert
            Assert.IsTrue(products.All(a => !a.Dicount.HasValue));
        }

        [TestMethod]
        public void CheckOffer_GivenOfferValid_ShouldApplyDiscountToLastItem()
        {
            // arrange
            var offer = new TestOffer1();
            var products = new List<ProductBase>()
            {
                new TestProduct2(),
                new TestProduct2()
            };

            // act
            offer.CheckOffer(products);

            // assert
            Assert.IsFalse(products.All(a => !a.Dicount.HasValue));
            Assert.IsFalse(products.First().Dicount.HasValue);
            Assert.IsTrue(products.Last().Dicount.HasValue);
        }
    }
}