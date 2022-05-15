using BasketProject.Offers;
using BasketUnitTests.TestOffers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BasketUnitTests.Offers
{
    [TestClass]
    public class OfferServiceTests
    {
        [TestMethod]
        public void Constructor_GivenOfferServiceCreated_ShouldCreateNewCurrentOffers()
        {
            // act
            var result = new OffersService();

            // assert
            Assert.AreEqual(0, result.GetCurrentOffers().Count());
        }

        [TestMethod]
        public void AddOffers_GivenParameters_ShouldReturnAllAddedOffers()
        {
            // arrange
            var service = new OffersService();

            // act
            service.AddOffers(new List<OfferBase>{new TestOffer1(), new TestOffer1()});

            // assert
            Assert.AreEqual(2, service.GetCurrentOffers().Count());
        }

        [TestMethod]
        public void GetCurrentOffers_GivenOffersAdded_ShouldReturnOffers()
        {
            // arrange
            var service = new OffersService();

            // act
            service.AddOffers(new List<OfferBase>{new TestOffer1(), new TestOffer1(), new TestOffer1()});

            // assert
            Assert.AreEqual(3, service.GetCurrentOffers().Count());
        }
    }
}