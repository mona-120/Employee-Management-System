using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Services
{
    public class Company
    {
        List<string> ActiveEmployees = new List<string>();
        Dictionary<int,string> Departments = new Dictionary<int,string>();
        Queue<string> OnBoarding = new Queue<string>();
        Stack<string> ActionHistory = new Stack<string>();
        HashSet<string> UniqueSkills = new HashSet<string>();
    }
}
