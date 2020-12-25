using System.Runtime.InteropServices;
using System.Threading;
using Lab5_Banks.Account;

namespace Lab5_Banks
{
    public interface IAccountTransaction
    { 
        void Cancel();
    }
}