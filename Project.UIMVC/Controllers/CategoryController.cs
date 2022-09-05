using Project.BLL.DesingPatterns.GenericRepository.ConcNort;
using Project.ENTITES.Models;
using Project.UIMVC.Filters;
using Project.UIMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UIMVC.Controllers
{
    public class CategoryController : Controller
    {

        CategoryRepository _cRep;

        public CategoryController()
        {
            _cRep = new CategoryRepository();
        }
        // GET: Category

        [ActFilter , ResFilter]
        public ActionResult ListCategory()
        {

            CategoryVM cvm = new CategoryVM
            {
                Categories = _cRep.GetActives()
            };
                return View(cvm);
                
        }

        

        public ActionResult ListUpdateCategory()
        {
            CategoryVM cvm = new CategoryVM
            {
                Categories = _cRep.GetUpdates()
            };
            return View(cvm);
        }

        public ActionResult ListDeleteCategory()
        {
            CategoryVM cvm = new CategoryVM
            {
                Categories = _cRep.GetDeleted()
            };
            return View(cvm);
        }


        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            
            _cRep.Add(category);
            return RedirectToAction("ListCategory");
        }


        public ActionResult DeleteCategory(int id)
        {
            _cRep.Delete(_cRep.Find(id));
            return RedirectToAction("ListCategory");
        }


        public ActionResult UpdateCategory(int id)
        {
            CategoryVM cvm = new CategoryVM
            {
                Category = _cRep.Find(id)
            };
            return View(cvm);
        }

       

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            _cRep.Update(category);
            return RedirectToAction("ListCategory");
        }
    }
}