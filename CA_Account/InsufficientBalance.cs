using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CA_Account
{
    public class InsufficientBalance:ApplicationException
    {
        readonly string _accountName;
        public string msg;
        readonly double balance;
        public InsufficientBalance(string msg,string name,double balance) { 
            this._accountName=name;
            this.msg=msg;
            this.balance=balance;
        
        
        }
        public override string Message => msg;
        public override string ToString()
        {
            return ($"Name={_accountName} Balance={balance}");
        }
    }
}
