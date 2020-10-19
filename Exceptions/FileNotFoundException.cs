namespace Lab1.Exceptions
{
    public class FileNotFoundException : MainException
    {
        public FileNotFoundException(string path)
            : base($"File with path {path} not found") { }
    }
}