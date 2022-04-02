using System;
using System.Collections.Generic;
using System.Linq;
using BasketProject.Products;

namespace BasketProject.Offers
{
    public class ButterBreadOffer : OfferBase
    {
        protected override void ApplyOffer(IEnumerable<ProductBase> products)
        {
            var validOffers = (int)Math.Floor((double)products.Count(p => p.GetType() == typeof(ButterProduct)) / 2);
            products.Where(w => w.GetType() == typeof(BreadProduct)).Take(validOffers).Select(s => {s.Dicount = 50; return s; }).ToList();
        }

        protected override bool IsOfferValid(IEnumerable<ProductBase> products)
        {
            return products.Count(p => p.GetType() == typeof(ButterProduct)) >= 2;
        }
    }
}
