using System;

namespace Lab5_Banks.Exceptions
{
    public class UntrustfulLimitException : Exception
    {
        public UntrustfulLimitException() : base("Был превышен лимит снятия для невалидированного счета") { }
        public UntrustfulLimitException(string message) : base(message) { }
    }
}