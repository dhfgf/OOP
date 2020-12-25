using System;

namespace Lab5_Banks.Exceptions
{
    public class DepositIsNotAvailableException : Exception
    {
        public DepositIsNotAvailableException() : base("Срок депозита еще не окончен") { }
        public DepositIsNotAvailableException(string message) : base(message) { }
    }
}