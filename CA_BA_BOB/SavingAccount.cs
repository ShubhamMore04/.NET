using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_BA_BOB
{
    internal class SavingAccount : Account
    {
        private const double minbal = 1000;
        private const double InterestRate = 0.07;
        private double interest;

        public SavingAccount(string name, double balance) : base(name, balance)
        {
        }

        public override void withdraw(double amt)
        {
            if (Balance-amt > minbal && amt > 0) 
            {
                Balance -= amt;
                OnEvent(amt, Balance);
            }
            else
            {
                throw new MyException("Not Sufficient Balance");
            }
        }

        public static double Payinterest(SavingAccount savingAccount)
        {
            savingAccount.interest = savingAccount.Balance * InterestRate;
            savingAccount.Balance += savingAccount.interest;
            return savingAccount.interest;
        }
    }
}
