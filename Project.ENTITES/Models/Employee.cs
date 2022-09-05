using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITES.Models
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? ReportsToID { get; set; }

        //Relational Properties

        public virtual Employee  ReportsTo { get; set; }
        public virtual List<Employee>  Employees { get; set; }
    }
}
