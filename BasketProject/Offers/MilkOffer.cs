using BasketProject.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketProject.Offers
{
    public class MilkOffer : OfferBase
    {
        protected override void ApplyOffer(IEnumerable<ProductBase> products)
        {
            var validOffers = (int)Math.Floor((double)products.Count(p => p.GetType() == typeof(MilkProduct)) / 4);
            products.Where(w => w.GetType() == typeof(MilkProduct)).Take(validOffers).Select(s => {s.Dicount = 100; return s; }).ToList();
        }

        protected override bool IsOfferValid(IEnumerable<ProductBase> products)
        {
            return products.Count(c => c.GetType() == typeof(MilkProduct)) >= 3;
        }
    }
}