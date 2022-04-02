namespace BasketProject.Products
{
    public abstract class ProductBase
    {
        abstract public double OriginalPrice {get;}

        public double? Dicount {get;set;}

        public double Price => Dicount.HasValue ? OriginalPrice - (OriginalPrice * (Dicount.Value / 100)) : OriginalPrice;
    }
}