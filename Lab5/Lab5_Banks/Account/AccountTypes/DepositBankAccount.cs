using System.Collections.Generic;
using Lab5_Banks.Exceptions;
using Lab5_Banks.Properties;
using Lab5_Banks.Types;

namespace Lab5_Banks.Account.Types
{
    public class DepositBankAccount : BankAccount
    {
        private int _current_day;
        private int _days_left;
        private double _persent;
        private double _accumulated;

        public DepositBankAccount(Bank bank, Client owner, double sum, int days)
        {
            _transactions = new Dictionary<int, IAccountTransaction>();
            _bank = bank;
            _owner = owner;
            _sum = sum;
            _untrustful_limit = bank.GetUntrustfulLimit();
            _id = bank.GetAccountId();
            _current_day = 0;
            _days_left = days;
            _type = " Deposit";

            if (sum < 50000)
                _persent = 0.03;
            else if (sum < 100000)
                _persent = 0.035;
            else
                _persent = 0.04;
            
            bank.AddAccount(this);
        }
        
        public override void NextDay()
        {
            var dayly_persent = _persent / 365;
            _current_day++;
            _days_left--;
            _accumulated += _sum * dayly_persent;

            if (_current_day % 28 == 0)
            {
                _sum += _accumulated;
                _current_day = 0;
            }
        }

        public override void Withdrawal(double sum)
        {
            if (!CheckUnttrustfulLimit(sum))
                throw new UntrustfulLimitException();
            if (_days_left > 0)
                throw new DepositIsNotAvailableException();
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
            if (_days_left > 0)
                throw new DepositIsNotAvailableException();
            if (sum > _sum)
                throw new NotEnoughMoneyException();
            _sum -= sum;
            account.Deposit(sum);
            
            var id = GetTransactionId();
            var transaction = new AccountTransferTransaction(this, account, sum);
            _transactions.Add(id, transaction);
        }
    }
}