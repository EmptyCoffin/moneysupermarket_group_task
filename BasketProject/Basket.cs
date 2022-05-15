using BasketProject.Offers;
using BasketProject.Products;
using System.Collections.Generic;
using System.Linq;

namespace BasketProject
{
    public class Basket
    {
        private IOfferService _offerService;
        public IEnumerable<ProductBase> Products {get;set;}
        
        public Basket(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public string GetTotalPrice()
        {
            decimal price = 0;

            if (Products != null && Products.Any()) 
            {
                foreach(var offer in _offerService.GetCurrentOffers())
                {
                    offer.CheckOffer(Products);
                }
                price =  Products.Sum(s => s.Price);
            }

            return price.ToString("C2");
        }
    }
}
