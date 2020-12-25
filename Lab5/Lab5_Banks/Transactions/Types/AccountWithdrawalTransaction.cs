using Lab5_Banks.Account;

namespace Lab5_Banks.Types
{
    public class AccountWithdrawalTransaction : IAccountTransaction
    {
        private double _sum;
        private BankAccount _account;

        public AccountWithdrawalTransaction(BankAccount account, double sum)
        {
            _account = account;
            _sum = sum;
        }

        public void Cancel()
        {
            _account.Deposit(_sum);
        }
    }
}