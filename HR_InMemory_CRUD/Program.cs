namespace HR_InMemory_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MockEmployeeRepository db = new MockEmployeeRepository();
            Console.WriteLine("SHOW EMPLOYEE LIST --->");
            Display(db);

            Console.WriteLine("ADD EMPLOYEE --->");
            Employee a = db.Add (new Employee {Name = "Amar", Salary = 84000, Gender = "Male", Address = "Nanded" });
            Console.WriteLine("Record Added: {0} {1} {2} {3} {4}", a.Id, a.Name, a.Salary, a.Gender, a.Address);
            Display(db);

            Console.WriteLine("GET EMPLOYEE WITH ID--->");
            Employee e= db.GetEmployee(2);
            Console.WriteLine("{0} {1} {2} {3} {4}", e.Id, e.Name, e.Salary, e.Gender, e.Address);
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("DELETE EMPLOYEE --->");
            db.Delete(5);
            Display(db);

            Console.WriteLine("UPDATE EMPLOYEE --->");
            Employee m = new Employee {Id = 4, Name = "Rohit", Salary = 76000, Gender = "Male", Address = "Taj" };
            UpdateData(m, db);
        }

        static void Display(MockEmployeeRepository db) 
        {
            foreach(Employee a in db.GetAllEmployee())
                Console.WriteLine("{0} {1} {2} {3} {4}", a.Id, a.Name, a.Salary, a.Gender, a.Address);

            Console.WriteLine("------------------------------------------------");
        }

        static void UpdateData(Employee e, MockEmployeeRepository db)
        {
            db.Update(e);
            Display(db);
        }
    }
}