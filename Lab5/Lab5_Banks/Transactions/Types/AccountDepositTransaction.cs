using System;
using Lab5_Banks.Account;

namespace Lab5_Banks.Types
{
    public class AccountDepositTransaction : IAccountTransaction
    {
        private double _sum;
        private BankAccount _account;

        public AccountDepositTransaction(BankAccount account, double sum)
        {
            _account = account;
            _sum = sum;
        }

        public void Cancel()
        {
            _account.Withdrawal(_sum); // могут быть проблемы с отменой в минус
        }
    }
}