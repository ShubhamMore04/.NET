namespace CA_Account
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message m =new Message();
           List<Account> list = new List<Account>();
            Console.WriteLine("_______________________________________");
            try
            {
                list.Add(new SavingAccount("Amar", 200000));
                list.Add(new SavingAccount("Sneha", 300000));
                list.Add(new CurrentAccount("Shriya", 20000));
                list.Add(new SavingAccount("Sneha", 300000));
                list.Add(new CurrentAccount("Shriya", 20000));
                //list.Add(new SavingAccount("Sneha", 300000));
                //list.Add(new CurrentAccount("Shriya", 20000));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't create object more than 5");
            }
            Console.WriteLine("_______________________________________");
            for (int i=0; i<list.Count; i++)
            {
                list[i].Wdevent += m.Email;
                list[i].Wdevent += m.Mobile;  
            }
           
            list[0].Deposit(100000);
            Console.WriteLine(list[0].ToString());
            Console.WriteLine("_______________________________________");
            try
            {
                list[0].withdraw(500000000000);
            }
            catch(InsufficientBalance ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
           
           
            Console.WriteLine("_______________________________________");
            Console.WriteLine(list[0].ToString());
            Console.WriteLine("_______________________________________");
            Console.WriteLine("Interest applied on balance :"+SavingAccount.Payinterest((SavingAccount)list[0]));
        }
    }
}