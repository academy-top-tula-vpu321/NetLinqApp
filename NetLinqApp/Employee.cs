using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLinqApp
{
    class Employee
    {
        public string Name { set; get; } = "";
        public int Age { set; get; }
        public Company Company { set; get; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

    class Company
    {
        public string Title { set; get; }
    }

    //class Company
    //{
    //    public string Title { set; get; } = "";
    //    public List<Employee> Employees { set; get; } = new();
    //}
}
