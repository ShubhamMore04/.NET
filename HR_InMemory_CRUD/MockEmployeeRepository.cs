using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_InMemory_CRUD
{
    internal class MockEmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "ShubhamM", Salary = 80000, Gender = "Male", Address = "Thane" },
                new Employee() { Id = 2, Name = "Akshay", Salary = 78000, Gender = "Male", Address = "Kolhapur" },
                new Employee() { Id = 3, Name = "ShubhamG", Salary = 77000, Gender = "Male", Address = "Solapur" },
                new Employee() { Id = 4, Name = "Ajinkya", Salary = 82000, Gender = "Male", Address = "C.SambhajiNagar"},
                new Employee() { Id = 5, Name = "Yash", Salary = 77000, Gender = "Male", Address = "Nagpur"},
                new Employee() { Id = 6, Name = "Sushil", Salary = 83000, Gender = "Male", Address = "C.SambhajiNagar"},
            };
        }
        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id)+1;
            _employeeList.Add(employee);
            return employee;

        }

        public Employee Delete(int Id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
            if (employee != null) 
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null) 
            {
                employee.Name = employeeChanges.Name;
                employee.Salary = employeeChanges.Salary;
                employee.Gender = employeeChanges.Gender;
                employee.Address = employeeChanges.Address;
            }
            return employee;
        }
    }
}
