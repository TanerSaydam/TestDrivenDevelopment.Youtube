namespace eTicaret.Application;

public sealed class ProductPriceNotValidException : Exception
{
    public ProductPriceNotValidException() : base("Price must be greater than 0") { }
}
