using BasketProject.Offers;
using BasketProject.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BasketUnitTests.Offers
{
    [TestClass]
    public class ButterBreadOfferTests
    {
        private ButterBreadOffer _offer;

        [TestInitialize]
        public void Initialise()
        {
            _offer = new ButterBreadOffer();
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
                new ButterProduct(),
                new BreadProduct()
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
                new ButterProduct(),
                new ButterProduct(),
                new BreadProduct()
            };

            // act
            _offer.CheckOffer(products);

            // assert
            Assert.IsFalse(products.All(a => !a.Dicount.HasValue));
            Assert.IsTrue(products.Where(w => w.GetType() == typeof(ButterProduct)).All(a => !a.Dicount.HasValue));
            Assert.IsTrue(products.Where(w => w.GetType() == typeof(BreadProduct)).All(a => a.Dicount.HasValue));
            Assert.IsTrue(products.Where(w => w.GetType() == typeof(BreadProduct)).All(a => a.Dicount.Value == 50));
        }

        [TestMethod]
        public void CheckOffer_GivenMultipleOfferValid_ShouldAddDiscountOnce()
        {
            // arrange
            var products = new List<ProductBase>()
            {
                new ButterProduct(),
                new ButterProduct(),
                new ButterProduct(),
                new ButterProduct(),
                new BreadProduct()
            };

            // act
            _offer.CheckOffer(products);

            // assert
            Assert.IsFalse(products.All(a => !a.Dicount.HasValue));
            Assert.IsTrue(products.Where(w => w.GetType() == typeof(ButterProduct)).All(a => !a.Dicount.HasValue));
            Assert.IsTrue(products.Where(w => w.GetType() == typeof(BreadProduct)).All(a => a.Dicount.HasValue));
            Assert.IsTrue(products.Where(w => w.GetType() == typeof(BreadProduct)).All(a => a.Dicount.Value == 50));
        }

        
        [TestMethod]
        public void CheckOffer_GivenMultipleOfferValidAndProducts_ShouldAddDiscountTwice()
        {
            // arrange
            var products = new List<ProductBase>()
            {
                new ButterProduct(),
                new ButterProduct(),
                new ButterProduct(),
                new ButterProduct(),
                new BreadProduct(),
                new BreadProduct(),
                new BreadProduct()
            };

            // act
            _offer.CheckOffer(products);

            // assert
            Assert.IsFalse(products.All(a => !a.Dicount.HasValue));
            Assert.IsTrue(products.Where(w => w.GetType() == typeof(ButterProduct)).All(a => !a.Dicount.HasValue));
            Assert.AreEqual(2, products.Where(w => w.GetType() == typeof(BreadProduct)).Count(a => a.Dicount.HasValue && a.Dicount.Value == 50));
            Assert.AreEqual(1, products.Where(w => w.GetType() == typeof(BreadProduct)).Count(a => !a.Dicount.HasValue));
        }
    }
}