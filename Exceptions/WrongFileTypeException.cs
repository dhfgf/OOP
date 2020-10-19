namespace Lab1.Exceptions
{
    public class WrongFileTypeException : MainException
    {
        public WrongFileTypeException()
            : base("File type is not .ini") { }
    }
}