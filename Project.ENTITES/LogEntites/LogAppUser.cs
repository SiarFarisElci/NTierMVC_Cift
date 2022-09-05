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
    public class LogAppUser : BaseEntity

    {
        public string UserName { get; set; }

        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Sifreleriniz uyusmuyor")]
        public string ConfirmPassword { get; set; }
      
        //Relational Properties

        //public virtual List<DataLog>  DataLogs { get; set; }
    }
}
