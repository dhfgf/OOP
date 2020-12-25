using System.Collections.Generic;
using Lab5_Banks.Exceptions;
using Lab5_Banks.Properties;
using Lab5_Banks.Types;

namespace Lab5_Banks.Account.Types
{
    public class CreditBankAccount : BankAccount
    {
        private double _credit_limit;
        private double _comission;

        public CreditBankAccount(Bank bank, Client owner, double sum = 0)
        {
            _transactions = new Dictionary<int, IAccountTransaction>();
            var info = bank.GetCreditInfo();
            _credit_limit = info[0];
            _comission = info[1];
            _bank = bank;
            _owner = owner;
            _type = "Credit";
            _untrustful_limit = bank.GetUntrustfulLimit();
            _id = bank.GetAccountId();
            bank.AddAccount(this);
        }

        public override void NextDay()
        { }

        public override void Withdrawal(double sum)
        {
            if (!CheckUnttrustfulLimit(sum))
                throw new UntrustfulLimitException();
            if (_credit_limit > _sum - sum)
                sum *= _comission;
            _sum -= sum;

            var id = GetTransactionId();
            var transaction = new AccountWithdrawalTransaction(this, sum);
            _transactions.Add(id, transaction);
        }

        public override void Transfer(double sum, BankAccount account)
        {
            if (!CheckUnttrustfulLimit(sum))
                throw new UntrustfulLimitException();
            this.Withdrawal(sum);
            account.Deposit(sum);
            
            var id = GetTransactionId();
            var transaction = new AccountTransferTransaction(this, account, sum);
            _transactions.Add(id, transaction);
        }

        
    }
}