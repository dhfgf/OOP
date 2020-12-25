using System.Collections.Generic;
using Lab5_Banks.Properties;
using Lab5_Banks.Types;

namespace Lab5_Banks.Account
{
    public abstract class BankAccount
    {
        protected Bank _bank;
        protected Client _owner;
        protected double _sum;
        protected int _id;
        protected string _type;
        protected double _untrustful_limit;
        protected Dictionary<int, IAccountTransaction> _transactions;

        protected bool CheckUnttrustfulLimit(double sum)
        {
            if (!_owner.IsTrustful() && sum > _untrustful_limit)
                return false;
            else
            {
                return true;
            }
        }
        
        public string GetInfo()
        {
            return $"Type: {_type}\tSum: {_sum}";
        }
        public abstract void NextDay();
        public abstract void Withdrawal(double sum);
        public abstract void Transfer(double sum, BankAccount account);
        public void Deposit(double sum)
        {
            _sum += sum;
            
            var id = GetTransactionId();
            var transaction = new AccountDepositTransaction(this, sum);
            _transactions.Add(id, transaction);
        }

        protected int GetTransactionId()
        {
            return _transactions.Count + 1;
        }

        public void CancelTransaction(int transaction_id)
        {
            _transactions[transaction_id].Cancel();
        }

        // public void Check()
        // {
        //     Client client = new Client(_bank, "a", "b");
        //     _bank.AddClient(client);
        // }
    }
}