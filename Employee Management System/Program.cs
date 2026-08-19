using Employee_Management_System.Models;
using Employee_Management_System.Services;

namespace Employee_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var company = new Company();
            company.DataSeeding();

            while (true)
            {
                Console.WriteLine("Welcome in Employee System!");
                Console.WriteLine("=================================");
                Console.WriteLine("Please choose the process you need the following: ");
                Console.WriteLine("1. Add new employee to Onboarding queue");
                Console.WriteLine("2. Process the employee in Onboarding queue");
                Console.WriteLine("3. Add new Department");
                Console.WriteLine("4. Add new Skill");
                Console.WriteLine("5. Search for an employee using id or name");
                Console.WriteLine("6. Display employees of specefic Department");
                Console.WriteLine("7. Get Reports of each Department");
                Console.WriteLine("8. Display number of employees for each Department");
                Console.WriteLine("9. Display Actions History");
                Console.WriteLine("10. Display All Unique skills");
                Console.WriteLine("11. Exit");
                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch(choice)
                    {
                        case 1:
                            Console.Write("Enter name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter DepartmentId: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter salary: ");
                            decimal salary = decimal.Parse(Console.ReadLine());
                            Console.Write("If you had a skill ,Enter it: ");
                            string skill = Console.ReadLine();
                            company.AddNewEmployee(name, id, salary, skill);
                            break;
                        case 2:
                            company.OnboardingProcessing();
                            break;
                        case 3:
                            Console.Write("Enter name: ");
                            string Deptname = Console.ReadLine();
                            company.AddDepartment(Deptname);
                            break;
                        case 4:
                            Console.Write("Enter the skill: ");
                            string skill_ = Console.ReadLine();
                            company.Addskill(skill_);
                            break;
                        case 5:
                            Console.Write("Enter name or Id: ");
                            string input = Console.ReadLine();
                            int? id_ = null;
                            string name_ = null;
                            if(int.TryParse(input,out int value))
                            {
                                id_ = value;
                            }
                            else
                            {
                                name_ = input;
                            }
                            company.Search(id_, name_);
                            break;
                        case 6:
                            Console.Write("Enter Dapartment Id: ");
                            int dID = int.Parse(Console.ReadLine());
                            company.DisplayEmployee(dID);
                            break;
                        case 7:
                            company.GetDepartmentReports();
                            break;
                        case 8:
                            company.EmployeeNumber();
                            break;
                        case 9:
                            company.DisplayActionHistory();
                            break;
                        case 10:
                            company.DisplayUniqueSkills();
                            break;
                        case 11:
                            Environment.Exit(0);
                            break;
                    }

                }catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

            }
        }
    }
}
