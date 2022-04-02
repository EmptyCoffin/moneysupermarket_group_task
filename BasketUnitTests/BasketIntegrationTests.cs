using BasketProject;
using BasketProject.Offers;
using BasketProject.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BasketUnitTests
{
    [TestClass]
    public class BasketIntegrationTests
    {
        [TestInitialize]
        public void Initialise() 
        {
            OffersSingleton.Instance.CurrentOffers.AddRange(new OfferBase[] { new ButterBreadOffer(), new MilkOffer() });
        }

        [TestCleanup]
        public void CleanUp() 
        {
            OffersSingleton.Instance.CurrentOffers.Clear();
        }

        [TestMethod]
        public void Test_Scenario_1() 
        {
            // arrange
            var basket = new Basket
            {
                Products = new ProductBase[]{
                    new BreadProduct(),
                    new ButterProduct(),
                    new MilkProduct()
                }
            };

            // act
            var result = basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£2.95", result);
        }
        
        [TestMethod]
        public void Test_Scenario_2() 
        {
            // arrange
            var basket = new Basket
            {
                Products = new ProductBase[]{
                    new MilkProduct(),
                    new MilkProduct(),
                    new MilkProduct(),
                    new MilkProduct()
                }
            };

            // act
            var result = basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£3.45", result);
        }
        
        [TestMethod]
        public void Test_Scenario_3() 
        {
            // arrange
            var basket = new Basket
            {
                Products = new ProductBase[]{
                    new BreadProduct(),
                    new ButterProduct(),
                    new ButterProduct(),
                    new MilkProduct(),
                    new MilkProduct(),
                    new MilkProduct(),
                    new MilkProduct(),
                    new MilkProduct(),
                    new MilkProduct(),
                    new MilkProduct(),
                    new MilkProduct()
                }
            };

            // act
            var result = basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£9.00", result);
        }
    }
}