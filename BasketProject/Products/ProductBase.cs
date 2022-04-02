namespace BasketProject.Products
{
    public abstract class ProductBase
    {
        abstract public decimal OriginalPrice {get;}

        public decimal? Dicount {get;set;}

        public decimal Price => Dicount.HasValue ? OriginalPrice - (OriginalPrice * (Dicount.Value / 100)) : OriginalPrice;
    }
}