using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Lab5_Banks
{
    public class BankList
    {
        public List<Bank> _all_banks;
        private static BankList _instance;

        private BankList()
        {
            _all_banks = new List<Bank>();
        }

        public static BankList GetInstance()
        {
            if (_instance == null)
                _instance = new BankList();
            return _instance;
        }

        public void AddBank(Bank bank)
        {
            _all_banks.Add(bank);
        }

        public int GetId()
        {
            return _all_banks.Count + 1;
        }

        public List<Bank> GetBankList()
        {
            return _all_banks;
        }

        // public void Check()
        // {
        //     foreach (var bank in _all_banks)
        //     {
        //         bank.GetInfo();
        //     }
        // }
    }
}