using System;
using Lab5_Banks.Account;
using Lab5_Banks.Account.Types;
using Lab5_Banks.Properties;
using Lab5_Banks.Time;

namespace Lab5_Banks
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            { 
            var bank_list = BankList.GetInstance();
            var time_settings = new TimeSettings();
            
            Bank bank1 = new Bank(bank_list, 0.02, 500, 0.05, 5000);
            
            Client cl1 = new Client(bank1,"First", "Client", "City", "1234");
            // delete passport -> untrustfulException
            
            BankAccount acc1 = new DebitBankAccount(bank1, cl1, 1000000);
            BankAccount acc2 = new CreditBankAccount(bank1, cl1);
            BankAccount acc3 = new DepositBankAccount(bank1, cl1, 1000000, 28);
            Console.WriteLine($"{acc1.GetInfo()}\n{acc2.GetInfo()}\n{acc3.GetInfo()}\n");

            time_settings.AddDays(30, bank_list._all_banks);
            Console.WriteLine($"{acc1.GetInfo()}\n{acc2.GetInfo()}\n{acc3.GetInfo()}\n");
            
            acc3.Withdrawal(6000);
            Console.WriteLine($"{acc1.GetInfo()}\n{acc2.GetInfo()}\n{acc3.GetInfo()}\n");
            
            acc3.Transfer(10000, acc1); // также учитывается в транзакциях acc1
            Console.WriteLine($"{acc1.GetInfo()}\n{acc2.GetInfo()}\n{acc3.GetInfo()}\n");
            
            acc1.Deposit(3000000);
            Console.WriteLine($"{acc1.GetInfo()}\n{acc2.GetInfo()}\n{acc3.GetInfo()}\n");
            
            acc1.CancelTransaction(2);
            Console.WriteLine($"{acc1.GetInfo()}\n{acc2.GetInfo()}\n{acc3.GetInfo()}\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}