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

        // Adding skills to HashSet to Avoid dublications
        public void Addskills(string skill)
        {
            UniqueSkills.Add(skill);
        }

        // Process Onboarding Queue
        public void OnboardingProcessing(HashSet<string> skills)
        {
            if (OnBoarding.Count > 0)
            {
                foreach (var skill in skills)
                {
                    Addskills(skill);
                }

                var emp = OnBoarding.Peek();
                Console.WriteLine($"Employee Name: {emp.Name}, Id: {emp.Id} ,Department Id: {emp.DepartmentId} Added to the Active Employee List");
                ActiveEmployees.Add(emp);
                OnBoarding.Dequeue();
            }
            else
            {
                Console.WriteLine("Onboarding Queue is Empty!");
            }
        }


        // Search for an employee using id or name
        public void Search(int? id , string? name)
        {
            bool found = false;

            if (string.IsNullOrEmpty(name) && id == null)
            {
                Console.WriteLine("Invalid Operatoin, Please enter name or ID");
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                foreach (var emp in ActiveEmployees)
                {
                    if (name == emp.Name)
                    {
                        Console.WriteLine($"Found Employee: {emp.Id} , with Salary: {emp.Salary}");
                        found = true;
                    }
                }
            }
            else
            {
                foreach (var emp in ActiveEmployees)
                {
                    if (id == emp.Id)
                    {
                        Console.WriteLine($"Found Employee: {emp.Name} , with Salary: {emp.Salary}");
                        found = true;
                    }
                }
            }

            if(!found)
            {
                Console.WriteLine("Not Found!");
            }
        }


        // Display Employee of specific Department
        public void DisplayEmployee(int deptId)
        {
            if (!Departments.ContainsKey(deptId))
            {
                Console.WriteLine("This Department isn't Exist, Pleace enter a correct ID!");
            }
            else
            {
                foreach(var emp in ActiveEmployees)
                {
                    if(emp.DepartmentId == deptId)
                    {
                        Console.WriteLine(emp.Name);
                    }
                }
            }
        }
    }
}
