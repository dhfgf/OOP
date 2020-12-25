using System.Collections.Generic;

namespace Lab5_Banks.Time
{
    public class TimeSettings
    {
        private int _current_day;

        public TimeSettings()
        {
            _current_day = 0;
        }

        public void AddDays(int days, List<Bank> all_banks)
        {
            for (int i = 0; i < days; i++)
            {
                _current_day += days;

                foreach (var bank in all_banks)
                {
                    var all_accounts = bank.GetAccountList();
                    foreach (var account in all_accounts)
                    {
                        account.NextDay();
                    }
                }
            }
        }
    }
}