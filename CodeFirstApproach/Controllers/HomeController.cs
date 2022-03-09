using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            return View(db.EmployeeModels.ToList());
        }
        public ActionResult Index2()
        {
           var EmpDept = (from emp in db.EmployeeModels
                           join dept in db.Departments
                           on emp.DeptId equals dept.DeptId
                           select new EmpdeptModel {
                               EmpId=emp.EmpId,
                              EmpName=emp.EmpName,
                               EmpSalary=emp.EmpSalary,
                               DepartName =dept.DeptName,

                           }

                         ).ToList();

            return View(EmpDept);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            db.EmployeeModels.Add(emp); //create insert query 
            int i = db.SaveChanges();//Execute Query
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
           EmployeeModel emp= db.EmployeeModels.Find(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            db.Entry(emp).State=EntityState.Modified; //create Update query 
            int i = db.SaveChanges();//Execute Query
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            EmployeeModel emp = db.EmployeeModels.Find(id);
            return View(emp);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            EmployeeModel emp = db.EmployeeModels.Find(id); //create Delete query 
            db.EmployeeModels.Remove(emp);
            int i = db.SaveChanges();//Execute Query
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult HtmlHelperExample()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpName = "Khader";
            emp.status = true;

            ViewBag.NamesofEmployee = new SelectList(db.EmployeeModels, "EmpId", "EmpName");
            return View(emp);
        }

        [HttpGet]
        public ActionResult GetJsonData(int? id)
        {
            var emp = db.EmployeeModels.Where(s => s.EmpId == id);

            return Json(emp,JsonRequestBehavior.AllowGet);
        }


    }
}