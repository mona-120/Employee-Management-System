using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
