using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Account
{
    public class Message
    {
        public void Email(double amt, string name, double balance)
        {
            Console.WriteLine("Email : Amount withdrawn:{0} Newbal:{1} Name:{2}", amt, balance,name);
        }
        public void Mobile(double amt, string name, double balance)
        {
            Console.WriteLine("Message : Amount withdrawn:{0} Newbal:{1} Name:{2}", amt, balance,name);
        }
    }
}
