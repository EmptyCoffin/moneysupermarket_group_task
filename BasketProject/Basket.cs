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
            double price = 0;

            if (Products != null && Products.Any()) 
            {
                price =  Products.Sum(s => s.Price);
            }

            return $"£{price}";
        }
    }
}
