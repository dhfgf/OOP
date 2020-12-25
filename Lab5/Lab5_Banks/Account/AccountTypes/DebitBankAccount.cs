using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Lab5_Banks.Exceptions;
using Lab5_Banks.Properties;
using Lab5_Banks.Types;

namespace Lab5_Banks.Account.Types
{
    public class DebitBankAccount : BankAccount
    {
        private int _current_day;
        private double _accumulated;

        public DebitBankAccount(Bank bank, Client owner, double sum = 0)
        {
            _transactions = new Dictionary<int, IAccountTransaction>();
            _bank = bank;
            _owner = owner;
            _sum = sum;
            _untrustful_limit = bank.GetUntrustfulLimit();
            _id = bank.GetAccountId();
            _current_day = 0;
            _type = "Debit";
            bank.AddAccount(this);
        }

        public override void Withdrawal(double sum)
        {
            if (!CheckUnttrustfulLimit(sum))
                throw new UntrustfulLimitException();
            if (sum > _sum)
                throw new NotEnoughMoneyException();
            _sum -= sum;
            
            var id = GetTransactionId();
            var transaction = new AccountWithdrawalTransaction(this, sum);
            _transactions.Add(id, transaction);
        }

        public override void Transfer(double sum, BankAccount account)
        {
            if (!CheckUnttrustfulLimit(sum))
                throw new UntrustfulLimitException();
            if (sum > _sum)
                throw new NotEnoughMoneyException();
            _sum -= sum;
            account.Deposit(sum);
            
            var id = GetTransactionId();
            var transaction = new AccountTransferTransaction(this, account, sum);
            _transactions.Add(id, transaction);
        }

        public override void NextDay()
        {
            var persent = _bank.GetDebitInfo();
            var dayly_persent = persent / 365;
            _current_day++;
            _accumulated += _sum * dayly_persent;

            if (_current_day % 28 == 0)
            {
                _sum += _accumulated;
                _current_day = 0;
            }
        }
    }
}