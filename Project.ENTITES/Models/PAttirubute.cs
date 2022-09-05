using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITES.Models
{
    public class PAttirubute : BaseEntity
    {
        public string AttributeName { get; set; } 
        public string Description { get; set; }

        //RelationalPorperties

        public virtual List<ProductAttribute>  ProductAttributes { get; set; }
    }
}
