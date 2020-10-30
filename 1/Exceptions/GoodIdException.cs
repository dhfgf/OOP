namespace Lab2.Exceptions
{
    public class GoodIdException : MainException
    {
        public GoodIdException(int goodId)
            : base($"There is no good with ID {goodId}") { }
    }
}