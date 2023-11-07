using CA_Employee_Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Employee_Entity
{
    internal class DbService
    {
        private static readonly CompanyContext db = new CompanyContext();

        public void Display()
        {
            foreach (var r in db.Employees.ToList<Employee>())
                Console.WriteLine(r);
        }

        public List<Employee> Customquery(int id)
        {
            FormattableString sql = $"SELECT * FROM Employees WHERE DepartmentId ={id} ";
            var employeelist = db.Employees.FromSql(sql).ToList();
            return employeelist;
        }

        public void Adddata(Employee ee)
        {
            db.Add<Employee>(ee);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee e = db.Employees.SingleOrDefault<Employee>((Emp) => Emp.DepartmentId == id);
            if (e != null)
            {
                db.Remove<Employee>(e);
                db.SaveChanges();
            }
        }

        public List<Employee> Customquery1()
        {
            FormattableString sql = $"SELECT * FROM Employees WHERE Salary>80000";
            var emplist = db.Employees.FromSql(sql).ToList();
            return emplist;
        }

        public List<Employee> Customquery2()
        {
            FormattableString sql = $"SELECT * FROM Employees WHERE Name LIKE 'S%'";
            var emplist = db.Employees.FromSql(sql).ToList();
            return emplist;
        }
    }
}
