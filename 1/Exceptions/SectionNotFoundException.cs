namespace Lab1.Exceptions
{
    public class SectionNotFoundException : MainException
    {
        public SectionNotFoundException(string section)
            : base($"Section {section} not found") { }
    }
}