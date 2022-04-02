using BasketProject.Offers;
using BasketProject.Products;
using BasketUnitTests.TestProducts;
using System.Collections.Generic;
using System.Linq;

namespace BasketUnitTests.TestOffers
{
    public class TestOffer1 : OfferBase
    {
        protected override void ApplyOffer(IEnumerable<ProductBase> products)
        {
            products.Where(w => w.GetType() == typeof(TestProduct2)).Last().Dicount = 50;
        }

        protected override bool IsOfferValid(IEnumerable<ProductBase> products)
        {
            return products.Count(a => a.GetType() == typeof(TestProduct2)) > 1;
        }
    }
}