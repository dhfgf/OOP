namespace Lab2.Exceptions
{
    public class MainException : System.Exception
    {
        public MainException() { }

        public MainException(string message)
            : base(message)
        { }
    }
}