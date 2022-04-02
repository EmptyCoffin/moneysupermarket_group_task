using System.Collections.Generic;

namespace BasketProject.Offers
{
    public sealed class OffersSingleton
    {
        public List<OfferBase> CurrentOffers { get; set; }

        private static OffersSingleton _instance;

        private OffersSingleton()
        {
            CurrentOffers = new List<OfferBase>();
        }

        public static OffersSingleton Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new OffersSingleton();

                return _instance;
            }
        }
    }
}