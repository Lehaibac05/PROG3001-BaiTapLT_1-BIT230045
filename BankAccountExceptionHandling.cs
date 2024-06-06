namespace BankAccountExceptionHandling
{
    public class Program
    {
        public class InsufficientFundsException : Exception
        {
            public InsufficientFundsException(string message) : base(message) { }
        }
        public class NegativeAmountException : Exception
        {
            public NegativeAmountException(string message) : base(message) { }
        }

        public class BankAccount
        {
            private double balance;

            public double Balance
            {
                get { return balance; }
            }
            public void Deposit(double amount)
            {
                if (amount < 0)
                {
                    throw new NegativeAmountException("Cannot deposit a negative amount.");
                }
                balance += amount;
            }

            public void Withdraw(double amount)
            {
                if (amount < 0)
                {
                    throw new NegativeAmountException("Cannot withdraw a negative amount.");
                }
                if (balance - amount < 0)
                {
                    throw new InsufficientFundsException("Insufficient funds in the account.");
                }
                balance -= amount;
            }
        }
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            try
            {
                account.Deposit(1000.0);
                Console.WriteLine($"Deposited $1000.0. Current balance: {account.Balance}");

                account.Withdraw(500.0);
                Console.WriteLine($"Withdrew $500.0. Current balance: {account.Balance}");

                account.Withdraw(600.0);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NegativeAmountException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
