namespace Account
{
    class Account
    {
        private string _name;
        private double _money;

        public Account(string name, double money)
        {
            _name = name;
            _money = money;
        }

        public double Withdrawal(double i)
        {
            _money -= i;
            return i;
        }

        public void Deposit(double deposit)
        {
            _money += deposit;
        }

        public double balance()
        {
            return _money;
        }

        public override string ToString()
        {
            return $"Account: {_name}; Balance: {_money} EUR";
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}
