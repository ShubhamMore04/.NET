using CA_Employee_Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace CA_Employee_Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbService service = new DbService();

            Console.WriteLine("DISPLAY ALL EMPLOYEE LIST -->");
            service.Display();
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine("SHOW EMPLOYEE WITH ID -->");
            List<Employee> sl = service.Customquery(1);
            foreach (Employee s1 in sl)
                Console.WriteLine(s1);
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine("ADD NEW EMPLOYEE -->");
            /*
            Employee e = new Employee() { Name = "Sakshi", Salary = 90000, DepartmentId = 5 };
            service.Adddata(e);
            service.Display();
            */
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine("DELETE EMPLOYEE -->");
            service.Delete(4);
            service.Display();
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine("SHOW EMPLOYEE WHERE SALARY>80000 -->");
            List<Employee> li1 = service.Customquery1();
            foreach (Employee emp in li1)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine("SHOW EMPLOYEE WITH STARTING LETTER -->");
            List<Employee> li2 = service.Customquery2();
            foreach (Employee emp in li2)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("----------------------------------------------------");
        }

    }

}