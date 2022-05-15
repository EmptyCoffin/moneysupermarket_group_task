using BasketProject;
using BasketProject.Offers;
using BasketProject.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasketUnitTests
{
    [TestClass]
    public class BasketIntegrationTests
    {
        private Basket _basket;

        [TestInitialize]
        public void Initialise() 
        {
            var currentOffersService = new OffersService();
            currentOffersService.AddOffers(new OfferBase[] { new ButterBreadOffer(), new MilkOffer() });
            _basket = new Basket(currentOffersService);
        }

        [TestCleanup]
        public void CleanUp() 
        {
            _basket = null;
        }

        [TestMethod]
        public void Test_Scenario_1() 
        {
            // arrange
            _basket.Products = new ProductBase[]{
                    new BreadProduct(),
                    new ButterProduct(),
                    new MilkProduct()
                };

            // act
            var result = _basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£2.95", result);
        }
        
        [TestMethod]
        public void Test_Scenario_2() 
        {
            // arrange
            _basket.Products = new ProductBase[]{
                    new MilkProduct(),
                    new MilkProduct(),
                    new MilkProduct(),
                    new MilkProduct()
                };

            // act
            var result = _basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£3.45", result);
        }
        
        [TestMethod]
        public void Test_Scenario_3() 
        {
            // arrange
            _basket.Products = new ProductBase[]{
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
                };

            // act
            var result = _basket.GetTotalPrice();

            // assert
            Assert.AreEqual("£9.00", result);
        }
    }
}