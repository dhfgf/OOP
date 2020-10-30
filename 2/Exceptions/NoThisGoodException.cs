namespace Lab2.Exceptions
{
    public class NoThisGoodException
    {
        public NoThisGoodException(int goodID, int shopID)
            : base($"There is no good {goodID} in shop {shopID}") { }
    }
}