using BasketProject.Offers;
using BasketProject.Products;
using System.Collections.Generic;
using System.Linq;

namespace BasketProject
{
    public class Basket
    {
        public IEnumerable<ProductBase> Products {get;set;}

        public string GetTotalPrice()
        {
            decimal price = 0;

            if (Products != null && Products.Any()) 
            {
                foreach(var offer in OffersSingleton.Instance.CurrentOffers)
                {
                    offer.CheckOffer(Products);
                }
                price =  Products.Sum(s => s.Price);
            }

            return price.ToString("C2");
        }
    }
}
