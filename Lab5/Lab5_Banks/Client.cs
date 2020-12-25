namespace Lab5_Banks.Properties
{
    public class Client
    {
        private Bank _bank;
        private string _name;
        private string _surname;
        private string _address;
        private string _passport;
        private bool _is_trustful;

        public bool IsTrustful()
        {
            return _is_trustful;
        }

        public Client(Bank bank, string name, string surname, string address = null, string passport = null)
        {
            _bank = bank;
            _name = name;
            _surname = surname;
            _address = address;
            _passport = passport;
            _is_trustful = _Validate();
            _bank.AddClient(this);
        }

        private bool _Validate()
        {
            return (_address != null && _passport != null);
        }

        public void SetAddress(string address)
        {
            _address = address;
            _is_trustful = _Validate();
        }

        public void SetPassport(string passport)
        {
            _passport = passport;
            _is_trustful = _Validate();
        }

        public string GetInfo()
        {
            return $"{_name} {_surname}";
        }
    }
}