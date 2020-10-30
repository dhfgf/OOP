namespace Lab2.Exceptions
{
    public class ImpossibleToFindShopException : MainException
    {
        public ImpossibleToFindShopException()
            : base($"There is no shops to buy this order") { }
    }
}