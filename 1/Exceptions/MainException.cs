using System;

namespace Lab1.Exceptions
{
    public class MainException : System.Exception
    {
        public MainException()
        {
        }

        public MainException(string message)
            : base(message)
        {
        }
    }
}