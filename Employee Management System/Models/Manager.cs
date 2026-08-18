using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Models
{
    public class Manager : Employee
    {
        List<string> TeamMembers = new List<string>();

        public Manager(int id, string name , int departmentId, decimal salary , List<string> members) 
            : base(id , name , departmentId, salary)
        {
            TeamMembers = members;
        }
    }
}
