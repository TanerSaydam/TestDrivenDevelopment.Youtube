namespace eTicaret.Application;

public sealed class ProductNameNotUniqueException : Exception
{
    public ProductNameNotUniqueException() : base("Name already using") { }
}
