using Project.ENTITES.Enums;
using Project.ENTITES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITES.LogEntites
{
    public class DataLog : BaseEntity
    {
        public string UserName { get; set; }

        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string Information { get; set; }
        public Keyword Description { get; set; }

        //public int UserID { get; set; }
        //Relational Properties

        //public virtual LogAppUser  User { get; set; }
    }
}
