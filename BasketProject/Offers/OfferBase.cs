using System.Collections.Generic;
using BasketProject.Products;

namespace BasketProject.Offers
{
    public abstract class OfferBase
    {
        protected abstract bool IsOfferValid(IEnumerable<ProductBase> products);

        protected abstract void ApplyOffer(IEnumerable<ProductBase> products);

        public void CheckOffer(IEnumerable<ProductBase> products)
        {
            if (IsOfferValid(products))
            {
                ApplyOffer(products);
            }
        }
    }
}