using System;

namespace Lab5_Banks.Exceptions
{
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException() : base("Недостаточно денег на счете") { }
        public NotEnoughMoneyException(string message) : base(message) { }
    }
}