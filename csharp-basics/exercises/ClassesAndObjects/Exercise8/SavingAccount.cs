namespace Exercise8
{
    public class SavingAccount
    {

        private double _startingBalance = 0;
        private double _totalWithdrawn = 0;
        private double _totalDeposited = 0;
        private double _balance=0;
        private double _interestRate = 0.05;
        private double _interestEarned = 0;

        public SavingAccount(double startingBalance, double annualInterestRate)
        {
            this._startingBalance = startingBalance;
            this._balance = startingBalance;
            this._interestRate = annualInterestRate;
        }

        public void WithDraw(double cash)
        {
            this._balance -= cash;
            this._totalWithdrawn += cash;
        }

        public double TotalWithdrawn()
        {
            return this._totalWithdrawn;
        }

        public double GetBalance()
        {
            return this._balance;
        }

        public double TotalInterestEarned()
        {
            return this._interestEarned;
        }

        public double TotalDeposited()
        {
            return this._totalDeposited;
        }

        public void AddDepositMoney(double cash)
        {
            this._balance += cash;
            this._totalDeposited += cash;
        }

        public void AddMonthlyInterestMoney(int month)
        {
            double earned = this._balance * this._interestRate / 12 * month; 
            this._balance += earned;
            this._interestEarned += earned; 
        }
    }
}
