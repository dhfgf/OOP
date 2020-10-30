namespace Lab2.Exceptions
{
    public class NoThisGoodInThisShopException : MainException
    {
        public NoThisGoodInThisShopException(int goodId, int shopId)
            : base($"There is no good {goodId} in shop {shopId}") { }
    }
}