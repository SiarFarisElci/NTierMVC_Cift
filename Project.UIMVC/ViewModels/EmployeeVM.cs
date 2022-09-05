using Project.ENTITES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UIMVC.ViewModels
{
    public class EmployeeVM
    {
        public List<Employee>  Employees { get; set; }

        public Employee  Employee { get; set; }
    }
}