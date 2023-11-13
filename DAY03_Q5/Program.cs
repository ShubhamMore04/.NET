/*
DAY03- 5) Create class Employee having memberId, Name, Salary, NetSalary, Dept d
create enum Dept{MKT,ADMIN,ADV}
create method public double paytax(double p){return tax amount and set netsalary(note:netsalary=salary-salary*p%)}
create method display to display name and netsalary and department
when you load application it should print name of company. new Employee(1,"Raj",50000,Dept.MKT)
*/

namespace DAY03_Q5
{
    enum Dept
    {
        MKT, ADMIN, ADV
    }
    class Employee
    {
        int memberID;
        string name;
        double salary;
        Dept d;


        static Employee()
        {

        }

        public Employee(int memberID, string name, double salary, Dept d)
        {
            this.memberID = memberID;   
            this.name = name;   
            this.salary = salary;
        }

        static void paytax(double p)
        {
            double tax
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee(1, "Shubham", 80000);
            Console.WriteLine("Tax Deducted : " +emp.paytax())
        }
    }
}