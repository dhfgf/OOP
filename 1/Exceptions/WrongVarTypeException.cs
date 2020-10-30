namespace Lab1.Exceptions
{
    public class WrongVarTypeException : MainException
    {
        public WrongVarTypeException(string type)
            : base($"This value is not {type}") { }
    }
}