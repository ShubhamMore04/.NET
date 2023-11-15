using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Account
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(string name, double balance) : base(name, balance)
        {
        }

        public override double withdraw(double amt)
        {
            if(amt>0 && amt<Balance)
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
    }
}
