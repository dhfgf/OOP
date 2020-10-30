namespace Lab2.Exceptions
{
    public class ShopIdException : MainException
    {
        public ShopIdException(int shopId)
            : base($"There is no shop with ID {shopId}") { }
    }
}