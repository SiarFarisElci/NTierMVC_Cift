using Project.ENTITES.Models;
using Project.UIMVC.CustomTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UIMVC.ViewModels
{
    public class ShoppingVM
    {
        public List<Product>  Products { get; set; }
        public Product  Product { get; set; }

        public Cart  Cart { get; set; }
    }
}