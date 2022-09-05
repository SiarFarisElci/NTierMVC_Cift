using Project.BLL.DesingPatterns.GenericRepository.ConcNort;
using Project.ENTITES.Models;
using Project.UIMVC.CustomTools;
using Project.UIMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UIMVC.Controllers
{
    public class ShoppingController : Controller
    {

        ProductRepository _pRep;

        public ShoppingController()
        {
            _pRep = new ProductRepository();
        }



        // GET: Shopping
        public ActionResult ProductList()
        {
            ShoppingVM svm = new ShoppingVM
            {
                Products = _pRep.GetActives()
            };
            return View(svm);
        }


        public ActionResult AddToCart (int id)
        {

            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;

            Product eklenecek = _pRep.Find(id);

            CartItem ci = new CartItem();

            ci.ProductName = eklenecek.ProductName;
            ci.ID = eklenecek.ID;
            ci.UnitPrice = eklenecek.UnitPrice;
            c.SepeteEkle(ci);

            Session["scart"] = c;
            TempData["mesaj"] = $"{ci.ProductName} isimli urun sepete eklenmiştir";

            return RedirectToAction("ProductList");
        }

        public ActionResult SepetSayfasi()
        {

            if (Session["scart"] != null)
            {
                Cart c = Session["scart"] as Cart;
                ShoppingVM svm = new ShoppingVM
                { Cart = c };
                return View(svm);
            }

            ViewBag.SepetBos = "Sepetinizde urun bulunmamaktadır";
            return View();
        }


        public ActionResult SepettenCikar(int id)
        {
            if (Session["scart"] != null)
            {
                Cart c = Session["scart"] as Cart;
                c.SepettenSil(id);
                if (c.Sepetim.Count == 0) Session.Remove("scart");
                return RedirectToAction("SepetSayfasi");

                
            }

            return RedirectToAction("ProductList");


        }




    }
}