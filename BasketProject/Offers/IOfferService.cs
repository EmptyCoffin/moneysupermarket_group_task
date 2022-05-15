using System.Collections.Generic;

namespace BasketProject.Offers
{
    public interface IOfferService
    {
        void AddOffers(IEnumerable<OfferBase> offers);

        IEnumerable<OfferBase> GetCurrentOffers();
    }
}