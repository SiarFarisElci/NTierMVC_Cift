using Project.ENTITES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UIMVC.ViewModels
{
    public class CategoryVM
    {
        public List<Category>  Categories { get; set; }
        public Category  Category { get; set; }
    }
}