namespace Lab1.Exceptions
{
    public class ErrorInFileException : MainException
    {
        public ErrorInFileException()
            : base($"Something wrong in file") { }
    }
}