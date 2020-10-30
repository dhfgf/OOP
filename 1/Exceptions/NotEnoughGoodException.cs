namespace Lab2.Exceptions
{
    public class NotEnoughGoodException : MainException
    {
        public NotEnoughGoodException(int goodId, int shopId)
            : base($"There is not enough good {goodId} in shop {shopId}") { }
    }
}