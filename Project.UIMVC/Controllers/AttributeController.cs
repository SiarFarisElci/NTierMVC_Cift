using Project.BLL.DesingPatterns.GenericRepository.ConcNort;
using Project.UIMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UIMVC.Controllers
{
    public class AttributeController : Controller
    {

        ProductRepository _pRep;
        ProductAttributeRepository _pARep;
        PAttributeRepository _aRep;

        public AttributeController()
        {
            _aRep = new PAttributeRepository();
            _pARep = new ProductAttributeRepository();
            _pRep = new ProductRepository();
        }

        // GET: Attribute
        public ActionResult ListAttribute()
        {
            ProductAttributeVM pavm = new ProductAttributeVM
            {
                ProductAttributes = _pARep.GetActives()
            };
            return View(pavm);
        }
    }
}