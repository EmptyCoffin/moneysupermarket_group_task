using System.Collections.Generic;

namespace BasketProject.Offers
{
    public class OffersService : IOfferService
    {
        private List<OfferBase> _currentOffers;

        public OffersService()
        {
            _currentOffers = new List<OfferBase>();
        }

        public void AddOffers(IEnumerable<OfferBase> offers)
        {
            _currentOffers.AddRange(offers);
        }

        public IEnumerable<OfferBase> GetCurrentOffers()
        {
            return _currentOffers;
        }
    }
}