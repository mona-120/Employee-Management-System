using Employee_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Employee_Management_System.Services
{
    public class Company
    {
        List<Employee> ActiveEmployees = new List<Employee>();
        Dictionary<int,string> Departments = new Dictionary<int,string>();
        Queue<Employee> OnBoarding = new Queue<Employee>();
        Stack<string> ActionsHistory = new Stack<string>();
        HashSet<string> UniqueSkills = new HashSet<string>();

        int empId = 1;
        int deptId = 1;


        // Add new Employee to Onboarding Queue
        public void AddNewEmployee(string name, int departmentId, decimal salary)
        {
            if(string.IsNullOrWhiteSpace(name) || !Departments.ContainsKey(departmentId) || salary < 0)
            {
                throw new Exception("Invalid addition");
            }
            else
            {
                var newEmp = new Employee(empId, name, departmentId, salary);
                OnBoarding.Enqueue(newEmp);
                Console.WriteLine($"Employee {name} Added to Onboarding Queue successfully!");
                Actions($"Added {name} to Onboarding Queue!");
                empId++;
            }           
        }

        // Add a Department
        public void AddDepartment(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Invalid addition");
            }
            else
            {
                Departments.Add(deptId,name);
                Console.WriteLine($"Department {name} Added successfully!");
                Actions($"Added Department {name}!");
                deptId++;
            }
        }

        // Action History
        public void Actions(string action)
        {
            ActionsHistory.Push(action);
        }
    }
}
