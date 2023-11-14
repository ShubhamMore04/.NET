using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Q1.Create Console Appplication for Bank Of Baroda.
Create a  abstract class Account having member
a. Id [Let your application generate id, it is readonly]
b.Name[write getter, setter Method, Give Validation Length of  name can not be less then 2 and greater then 15]
c.Balance[write getter, setter, you can not set value  outside class other than child class]
It has two methods
1. public abstract withdraw(double amt);
2. public void Deposit(double amt) { }
This method will increase amount in balance.
Create two child class SavingAccount and CurrentAccount.
In CurrentAccount user can have negative balance.
In SavingAccount minimum balance of 1000 need to maintain. Declare const double  minbala=1000
When use withdraw money they should get SMS and EMAIL about new balance and amount withdrawn.
 When you run application it should display name of bank. 
Create List of Account class and store child Object.
Do transaction and ensure user can not withdraw more then the balance. Also ensure it maintain minimum balance of 1000 in Saving Account.
In SavingAccount write public static double Payinterest(Employee e) this method will return interest amount  and increase the balance  
If data is in-validation then your application should throw exception
Your application should allow you to create only 5 object.
Your application should handle all exception.
Write user Define Exception for insufficient balance[If user try to withdraw more then minbalance in Saving Account] This class will 
print user name and transaction detail in a file.
In Account class Create event. When use withdraw money it should send SMS and E-mail [Complete Publisher subscriber design pattern]
*/

namespace CA_BA_BOB
{
    public delegate void EventWatch(double a, double b);
    public abstract class Account
    {
        private int id;
        private static int getid;
        private string name;
        private double balance;
        public event EventWatch performevent;

        static Account()
        {
            Console.WriteLine("Bank of Baroda");
        }

        public void OnEvent(double a, double b)
        {
            if (performevent != null) 
            {
                performevent(a, b);
            }
        }

        public int Id
        {
            get { return id;}
        }

        public string Name
        {
            get { return name;}

            set 
            {
                if (value.Length > 2 && value.Length < 16)
                    name = value;

                else
                    throw new MyException("Please Enter Valid Name");
            }
        }

        public double Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        public Account(string name, double balance)
        {
            if (id < 6)
            {
                id = ++getid;
            }
            else 
                throw new MyException("Only Five Accounts Aollowed");

            Name = name;
            Balance = balance;
        }

        public abstract void withdraw(double amt);

        public void Deposit(double amt)
        {
            if(amt > 0) 
            {
                balance += amt;
            }
        }

    }  
}
