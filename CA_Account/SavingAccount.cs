using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CA_Account
{
    public class SavingAccount : Account
    {
        private const double minbal = 1000;
        public static double intrestrate = 0.4;
        public SavingAccount(string name, double balance) : base(name, balance)
        {
        }

        public override double withdraw(double amt)
        {
            if (amt > 0 && amt < Balance && Balance-amt>minbal)
            {
                Balance = Balance - amt;
                onwithdraw(amt, Name, Balance);
                return Balance;
                

            }
            else
            {
                throw new InsufficientBalance("Insufficient Balance", Name, Balance);
            }
            
        }
        public static double Payinterest(SavingAccount e)
        {
            e.Balance *= intrestrate;
            return e.Balance;
           
            
        }

    }
}
