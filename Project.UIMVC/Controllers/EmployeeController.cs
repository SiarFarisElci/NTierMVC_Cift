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
    public class EmployeeController : Controller
    {

        EmployeeRepository _eRep;

        public EmployeeController()
        {
            _eRep = new EmployeeRepository();   
        }

        // GET: Employee
        public ActionResult ListEmployee()
        {

            EmployeeVM evm = new EmployeeVM
            {
                Employees = _eRep.GetActives()
            };

            return View(evm);
        }

        public ActionResult UpdateListEmployee()
        {
            EmployeeVM evm = new EmployeeVM
            {
                Employees = _eRep.GetUpdates()
            };
            return View(evm);
        }

        public ActionResult DeleteListEmployee()
        {
            EmployeeVM evm = new EmployeeVM
            {
                Employees = _eRep.GetDeleted()
            };
            return View(evm);

        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            _eRep.Add(employee);
            return RedirectToAction("ListEmployee");
        }


        public ActionResult DeleteEmployee(int id)
        {
            _eRep.Delete(_eRep.Find(id));
            return RedirectToAction("ListEmployee");
        }



        public ActionResult UpdateEmployee(int id)
        {
            EmployeeVM evm = new EmployeeVM
            {
                Employee = _eRep.Find(id)
            };
            return View(evm);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            _eRep.Update(employee);
            return RedirectToAction("ListEmployee");
        }

    }
}