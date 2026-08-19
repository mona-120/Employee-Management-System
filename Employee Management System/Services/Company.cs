using Employee_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
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
        public void AddNewEmployee(string name, int departmentId, decimal salary, string? empSkill)
        {
            if(string.IsNullOrWhiteSpace(name) || !Departments.ContainsKey(departmentId) || salary < 0)
            {
                throw new Exception("Invalid process");
            }
            else
            {
                var newEmp = new Employee(empId, name, departmentId, salary);
                OnBoarding.Enqueue(newEmp);
                Console.WriteLine($"Employee {name} Added to Onboarding Queue successfully!");
                Actions($"Added {name} to Onboarding Queue!");
                empId++;
            }
            if (!string.IsNullOrWhiteSpace(empSkill))
            {
                Addskill(empSkill);
            }
        }

        // Add a Department
        public void AddDepartment(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Invalid process");
            }
            else
            {
                Departments.Add(deptId,name);
                Console.WriteLine($"Department {name} Added successfully!");
                Actions($"Added Department {name}!");
                deptId++;
            }
        }

        // Tracking Action History
        public void Actions(string action)
        {
            ActionsHistory.Push(action);
        }

        // Adding skills of an employee to HashSet to Avoid dublications
        public void Addskill(string skill)
        {
          UniqueSkills.Add(skill); 
          Actions($"New Skill '{skill}' added");
        }


        // Process Onboarding Queue
        public void OnboardingProcessing()
        {
            if (OnBoarding.Count > 0)
            {
                var emp = OnBoarding.Peek();
                Console.WriteLine($"Employee Name: {emp.Name}, Id: {emp.Id} ,Department Id: {emp.DepartmentId} Added to the Active Employee List");
                ActionsHistory.Push($"Added employee: {emp.Name} in ActiveEmployees List");
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

            if (string.IsNullOrWhiteSpace(name) && id == null)
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


        // Get Departments Reports
        public void GetDepartmentReports()
        {
            foreach(var deptId in Departments.Keys)
            {
                decimal TotalSalary = 0;
                int empNum = 0;
                foreach (var emp in ActiveEmployees)
                {
                    if(emp.DepartmentId == deptId)
                    {
                        TotalSalary += emp.Salary;
                        empNum++;
                    }
                }
                if(empNum == 0) { Console.WriteLine("This Department doesn't contain employees!"); }
                else
                {
                    Console.WriteLine($"Department Id: {deptId} , Name: {Departments[deptId]}, With Avarage Salary: {TotalSalary / empNum}");
                }
            }
        }


        // number of employees in each department
        public void EmployeeNumber()
        {
            foreach(var dept in Departments)
            {
                int empNum = 0;
                foreach(var emp in ActiveEmployees)
                {
                    if (emp.DepartmentId == dept.Key)
                    {
                        empNum++;
                    }
                }
                Console.WriteLine($"Department: {dept.Value} ,with Id: {dept.Key} has {empNum} employees");
            }
        }


        // Display Action History
        public void DisplayActionHistory()
        {
            if(ActionsHistory.Count == 0)
            {
                Console.WriteLine("No Actions to display");
            }
            foreach(var action in ActionsHistory)
            {
                Console.WriteLine(action);
            }
        }


        // Display Unique Skills
        public void DisplayUniqueSkills()
        {
            if(UniqueSkills.Count == 0)
            {
                Console.WriteLine("No Skills to display");
            }
            foreach(var sk in UniqueSkills)
            {
                Console.WriteLine(sk);
            }
        }


        // Seeding Data
        public void DataSeeding()
        {
            // Add Department
            AddDepartment("Backend");
            AddDepartment("HR");
            AddDepartment("Frontend");


            // Add employee in Onboarding List
            AddNewEmployee("Mohamed", 1, 15000,"C#");
            AddNewEmployee("Ahmed", 2, 10000, "Java");


            // Add Skills
            UniqueSkills.Add("SQL");
            UniqueSkills.Add("C#");

        }
    }
}
