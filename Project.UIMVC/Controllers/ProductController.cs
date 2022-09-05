using Project.BLL.DesingPatterns.GenericRepository.ConcNort;
using Project.ENTITES.Models;
using Project.UIMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UIMVC.Controllers
{
    public class ProductController : Controller
    {

        ProductRepository _pRep;

        CategoryRepository _cRep;


        public ProductController()
        {
            _pRep = new ProductRepository();
            _cRep = new CategoryRepository();
        }



        // GET: Product
        public ActionResult ListProduct()
        {
            ProductVM pvm = new ProductVM
            {
                Products = _pRep.GetActives()

            };
            return View(pvm);
        }

        public ActionResult ListUpdateProduct()
        {
            ProductVM pvm = new ProductVM
            {
                Products = _pRep.GetUpdates()

            };
            return View(pvm);
        }

        public ActionResult ListDeleteProduct()
        {
            ProductVM pvm = new ProductVM
            {
                Products = _pRep.GetDeleted(),

            };
            return View(pvm);
        }

        public ActionResult AddProduct()
        {
            ProductVM pvm = new ProductVM
            {
                Categories = _cRep.GetActives()

            };
            return View(pvm);
        }


        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _pRep.Add(product);
            return RedirectToAction("ListProduct");
        }

        public ActionResult DeleteProduct(int id)
        {
            _pRep.Delete(_pRep.Find(id));
            return RedirectToAction("ListProduct");
        }


        public ActionResult UpdateProduct(int id)
        {
            ProductVM pvm = new ProductVM
            {
                Product = _pRep.Find(id),
                Categories = _cRep.GetActives()
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            _pRep.Update(product);
            return RedirectToAction("ListProduct");
        }
    }
}