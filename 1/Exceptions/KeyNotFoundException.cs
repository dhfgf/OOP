namespace Lab1.Exceptions
{
    public class KeyNotFoundException : MainException
    {
        public KeyNotFoundException(string key)
            : base($"Key {key} not found") { }
    }
}