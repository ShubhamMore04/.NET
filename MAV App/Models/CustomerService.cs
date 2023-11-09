namespace CA_MVC_Customer.Models
{
    public class CustomerService : ICustomer
    {
        public static List<Customer> _customerList;

        public CustomerService() 
        {
            _customerList = new List<Customer>()
            {
                new Customer() {Id = 001, Name = "Shubham", MobileNo = "9326444913", BillAmount = 6000},
                new Customer() {Id = 002, Name = "Akshay", MobileNo = "8498487943", BillAmount = 3000},
                new Customer() {Id = 003, Name = "ShubhamG", MobileNo = "7654646415", BillAmount = 4500},
                new Customer() {Id = 004, Name = "Sushil", MobileNo = "8944161115", BillAmount = 2200},
                new Customer() {Id = 005, Name = "Yash", MobileNo = "9669552636", BillAmount = 7600},
                new Customer() {Id = 006, Name = "Ajnkya", MobileNo = "8545546668", BillAmount = 4900}
            };
        }
        public List<Customer> GetAllCustomers()
        {
            return _customerList;
        }
    }
}
