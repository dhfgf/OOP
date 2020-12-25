using Lab5_Banks.Account;

namespace Lab5_Banks.Types
{
    public class AccountTransferTransaction : IAccountTransaction
    {
        private BankAccount _from;
        private BankAccount _to;
        private double _sum;

        public AccountTransferTransaction(BankAccount from, BankAccount to, double sum)
        {
            _from = from;
            _to = to;
            _sum = sum;
        }
        
        public void Cancel()
        {
            _from.Deposit(_sum); 
            _to.Withdrawal(_sum); // могут быть проблемы с отменой в минус
        }
    }
}