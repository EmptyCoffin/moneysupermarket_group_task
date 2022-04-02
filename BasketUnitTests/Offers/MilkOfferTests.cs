using BasketProject.Offers;
using BasketProject.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BasketUnitTests.Offers
{
    [TestClass]
    public class MilkOfferTests
    {
        private MilkOffer _offer;

        [TestInitialize]
        public void Initialise()
        {
            _offer = new MilkOffer();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _offer = null;
        }

        [TestMethod]
        public void CheckOffer_GivenOfferInvalid_ShouldNotAddDiscount()
        {
            // arrange
            var products = new List<ProductBase>()
            {
                new MilkProduct(),
                new MilkProduct()
            };

            // act
            _offer.CheckOffer(products);

            // assert
            Assert.IsTrue(products.All(a => !a.Dicount.HasValue));
        }

        [TestMethod]
        public void CheckOffer_GivenOfferValid_ShouldAddDiscount()
        {
            // arrange
            var products = new List<ProductBase>()
            {
                new MilkProduct(),
                new MilkProduct(),
                new MilkProduct(),
                new MilkProduct()
            };

            // act
            _offer.CheckOffer(products);

            // assert
            Assert.IsFalse(products.All(a => !a.Dicount.HasValue));
            Assert.AreEqual(3, products.Where(w => w.GetType() == typeof(MilkProduct)).Count(a => !a.Dicount.HasValue));
            Assert.AreEqual(1, products.Where(w => w.GetType() == typeof(MilkProduct)).Count(a => a.Dicount.HasValue));
            Assert.AreEqual(1, products.Where(w => w.GetType() == typeof(MilkProduct)).Count(a => a.Dicount.HasValue && a.Dicount.Value == 100));
        }

        [TestMethod]
        public void CheckOffer_GivenOfferValidBut4thNotAvailable_ShouldNotAddDiscount()
        {
            // arrange
            var products = new List<ProductBase>()
            {
                new MilkProduct(),
                new MilkProduct(),
                new MilkProduct()
            };

            // act
            _offer.CheckOffer(products);

            // assert
            Assert.IsTrue(products.All(a => !a.Dicount.HasValue));
        }

        [TestMethod]
        public void CheckOffer_GivenMultipleOfferValid_ShouldAddDiscountOnce()
        {
            // arrange
            var products = new List<ProductBase>()
            {
                new MilkProduct(),
                new MilkProduct(),
                new MilkProduct(),
                new MilkProduct(),
                new MilkProduct(),
                new MilkProduct(),
                new MilkProduct(),
                new MilkProduct()
            };

            // act
            _offer.CheckOffer(products);

            // assert
            Assert.IsFalse(products.All(a => !a.Dicount.HasValue));
            Assert.AreEqual(6, products.Where(w => w.GetType() == typeof(MilkProduct)).Count(a => !a.Dicount.HasValue));
            Assert.AreEqual(2, products.Where(w => w.GetType() == typeof(MilkProduct)).Count(a => a.Dicount.HasValue));
            Assert.AreEqual(2, products.Where(w => w.GetType() == typeof(MilkProduct)).Count(a => a.Dicount.HasValue && a.Dicount.Value == 100));
        }
    }
}