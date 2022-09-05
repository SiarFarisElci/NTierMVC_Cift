using Project.ENTITES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UIMVC.ViewModels
{
    public class ProductAttributeVM
    {
        public List<ProductAttribute>  ProductAttributes { get; set; }
        public ProductAttribute  ProductAttribute { get; set; }
        public List<PAttirubute>  PAttirubutes { get; set; }

        public PAttirubute  PAttirubute { get; set; }

        public Product  Product { get; set; }
        public List<Product>  Products { get; set; }
    }
}