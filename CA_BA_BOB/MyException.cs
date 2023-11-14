using System.Runtime.Serialization;

namespace CA_BA_BOB
{
    public class MyException : ApplicationException
    {
        public string sms;
        public MyException(string sms)
        {
            this.sms = sms;
        }

    }
}