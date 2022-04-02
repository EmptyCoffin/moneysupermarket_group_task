using BasketProject.Offers;
using BasketUnitTests.TestOffers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BasketUnitTests.Offers
{
    [TestClass]
    public class OffersSingletonTests
    {
        
        [TestCleanup]
        public void CleanUp() 
        {
            OffersSingleton.Instance.CurrentOffers.Clear();
        }
        
        [TestMethod]
        public void Instance_ShouldOnlyCreateOnceInstance()
        {
            // act
            var singleton1 = OffersSingleton.Instance;
            var singleton2 = OffersSingleton.Instance;

            // assert
            Assert.AreSame(singleton1, singleton2);
        }

        [TestMethod]
        public void Instance_ShouldMaintainOffersAcrossSingletons()
        {
            // arrange 
            var singleton1 = OffersSingleton.Instance;
            var singleton2 = OffersSingleton.Instance;

            // act
            singleton2.CurrentOffers.Add(new TestOffer1());

            // assert
            Assert.AreEqual(1, singleton2.CurrentOffers.Count);
            Assert.AreEqual(1, singleton1.CurrentOffers.Count);
            Assert.AreEqual(typeof(TestOffer1), singleton2.CurrentOffers.First().GetType());
            Assert.AreEqual(typeof(TestOffer1), singleton1.CurrentOffers.First().GetType());
        }
    }
}