using System;
using System.Collections.Generic;
using Lab5_Banks.Account;
using Lab5_Banks.Properties;

namespace Lab5_Banks
{
    public class Bank
    {
        private List<Client> _clients;
        private List<BankAccount> _accounts;
        private double _debit_persent;
        private double _credit_limit;
        private double _comission;
        private double _untrustful_limit;
        private int _id;
        
        public Bank(BankList bank_list, double debit_persent, double credit_limit, 
                    double comission, double untrustful_limit)
        {
            _debit_persent = debit_persent;
            _credit_limit = credit_limit;
            _comission = comission;
            _untrustful_limit = untrustful_limit;
            _clients = new List<Client>();
            _accounts = new List<BankAccount>();
            _id = bank_list.GetId();
            bank_list.AddBank(this);
        }
        
        public double GetUntrustfulLimit()
        {
            return _untrustful_limit;
        }

        public List<BankAccount> GetAccountList()
        {
            return _accounts;
        }

        public void AddClient(Client client)
        {
            _clients.Add(client);
        }

        public void AddAccount(BankAccount account)
        {
            _accounts.Add(account);
        }

        public int GetAccountId()
        {
            return _accounts.Count + 1;
        }

        public int GetClientId()
        {
            return _clients.Count + 1;
        }

        public double GetDebitInfo()
        {
            return _debit_persent;
        }

        public List<double> GetCreditInfo()
        {
            var info = new List<double>()
            {
                _credit_limit,
                _comission
            };
            return info;
        }
        
        // public void GetInfo()
        // {
        //     Console.WriteLine($"{_id}            Correct");
        // }
        
        // public void Check()
        // {
        //     foreach (var cl in _clients)
        //     {
        //         Console.WriteLine(cl.GetInfo());
        //     }
        // }
    }
}