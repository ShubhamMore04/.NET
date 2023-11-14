using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_BA_BOB
{
    internal class CurrentAccount : Account
    {
        public CurrentAccount(string name, double balance) : base(name, balance) 
        { 
        }

        public override void withdraw(double amt)
        {
            if (Balance-amt > 0)
            {
                Balance -= amt;
                OnEvent(amt, Balance);
            }
            else
            {
                throw new MyException("Enter Correct Amount");
            }
        }
    }
}
