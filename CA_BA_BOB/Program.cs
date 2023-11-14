namespace CA_BA_BOB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> list = null;
            try
            {
                list = new List<Account>()
                {
                    new SavingAccount("Shubham", 5000),
                    new CurrentAccount("Akshay", 10000),
                    new SavingAccount("Ajinkya", 7000),
                    new CurrentAccount("Yash", 8000),
                    new SavingAccount("Sushil", 10000),
                };
            }
            catch (MyException ex) 
            {
                Console.WriteLine(ex.sms);
            }

            foreach(Account account in list) 
            {
                if(account.GetType()==typeof(SavingAccount))
                {
                    Console.WriteLine("Enter Deposite Amount in Saving Account of {0} : ", account.Name);
                    account .Deposit(Convert.ToDouble(Console.ReadLine()));
                }
                else
                {
                    Console.WriteLine("Enter Deposite Amount in Current Account of {0} : ", account.Name);
                    account.Deposit(Convert.ToDouble(Console.ReadLine()));
                }
            }

            foreach (Account account in list)
            {
                if (account.GetType() == typeof(SavingAccount))
                {
                    Console.WriteLine("Enter Withdraw Amount in Saving Account of {0} : ", account.Name);
                    account.performevent += (a, b) => { Console.WriteLine("SMS : Amount Withdrawn : {0} Total Balance : {1}", a, b); };
                    account.performevent += (a, b) => { Console.WriteLine("Email : Amount Withdrawn : {0} Total Balance : {1}", a, b); };
                    account.withdraw(Convert.ToDouble(Console.ReadLine()));
                }
                else
                {
                    Console.WriteLine("Enter Withdraw Amount in Current Account of {0} : ", account.Name);
                    account.performevent += (a, b) => { Console.WriteLine("SMS : Amount Withdrawn : {0} Total Balance : {1}", a, b); };
                    account.performevent += (a, b) => { Console.WriteLine("Email : Amount Withdrawn : {0} Total Balance : {1}", a, b); };
                    account.withdraw(Convert.ToDouble(Console.ReadLine()));
                }
            }

            foreach (Account account in list)
            {
                if (account.GetType() == typeof(SavingAccount))
                {
                    Console.WriteLine("Interest payed for " + account.Name + " : " + SavingAccount.Payinterest((SavingAccount)a));
                }                
            }
        }
    }
}