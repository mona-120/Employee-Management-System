using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }

        public Employee(int id, string name, int departmentId , decimal salary)
        {
            Id = id;
            Name = name;
            DepartmentId = departmentId;
            Salary = salary;
        }


    }
}
