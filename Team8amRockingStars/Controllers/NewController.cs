using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team8amRockingStars.Models;

namespace Team8amRockingStars.Controllers
{
    public class NewController : Controller
    {
        // GET: New Commit Abdul
        public string Index()
        {
            return "Hello";
        }

        [Route("project/Gov")]
        [Route("project/{id}/Private")]
        [Route("New/Index2/{id}")]
        public string Index2(int? id)
        {
            return "My Employee id is " + id;
        }

        public ActionResult Index4()
        {
            return View("Index3");
        }

        public string index5(int? id = null)
        {
            return "My EmpId is" + id;
        }

        public ActionResult SendData()
        {
            ViewBag.Fname = "Madhvi";
            return View();

        }

        public ActionResult SendData2()
        {
            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "Ayoosh";
            obj.EmpSalary = 678965;


            ViewBag.Emp = obj;

            return View();

        }

        public ActionResult GetEmployees()
        {

            List<EmployeeModel> listEmp = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "suchita";
            obj.EmpSalary = 173833;

            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmpId = 2;
            obj1.EmpName = "Madhvi";
            obj1.EmpSalary = 173833;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmpId = 3;
            obj2.EmpName = "Manoj";
            obj2.EmpSalary = 273833;

            listEmp.Add(obj);
            listEmp.Add(obj1);
            listEmp.Add(obj2);


            ViewBag.emp = listEmp;

            return View();

        }

        public ActionResult SendData3()
        {
            String aobj = "asdfasdf";
            string bobj = "asdf";


            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "Ayoosh";
            obj.EmpSalary = 678965;

            // object model=obj;
            return Content("test");

        }


        public ViewResult SendMultipleModel(int? id)
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "suchita";
            obj.EmpSalary = 173833;

            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmpId = 2;
            obj1.EmpName = "Madhvi";
            obj1.EmpSalary = 173833;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmpId = 3;
            obj2.EmpName = "Manoj";
            obj2.EmpSalary = 273833;

            listEmp.Add(obj);
            listEmp.Add(obj1);
            listEmp.Add(obj2);

            List<DepartmentModel> listdept = new List<DepartmentModel>();

            DepartmentModel dept = new Models.DepartmentModel();
            dept.DeptId = 1211;
            dept.DeptName = "Accounts";

            DepartmentModel dept1 = new Models.DepartmentModel();
            dept1.DeptId = 1212;
            dept1.DeptName = "HR";

            listdept.Add(dept);
            listdept.Add(dept1);

            EmpDept empdept = new EmpDept();
            empdept.emp = listEmp;
            empdept.dept = listdept;

            return View(empdept);

        }


        public ActionResult getMePartialView()
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "suchita";
            obj.EmpSalary = 173833;

            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmpId = 2;
            obj1.EmpName = "Madhvi";
            obj1.EmpSalary = 173833;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmpId = 3;
            obj2.EmpName = "Manoj";
            obj2.EmpSalary = 273833;

            listEmp.Add(obj);
            listEmp.Add(obj1);
            listEmp.Add(obj2);



            return View(listEmp);
        }

        public PartialViewResult getMePartialView2()
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "suchita";
            obj.EmpSalary = 173833;

            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmpId = 2;
            obj1.EmpName = "Madhvi";
            obj1.EmpSalary = 173833;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmpId = 3;
            obj2.EmpName = "Manoj";
            obj2.EmpSalary = 273833;

            listEmp.Add(obj);
            listEmp.Add(obj1);
            listEmp.Add(obj2);



            return PartialView("_MyPartialView", listEmp);
        }

        public RedirectResult GetRediretToChina()
        {
            return Redirect("~/new/SendMultipleModel?id=1");
        }

        public RedirectResult GetRediretToChina2()
        {
            return Redirect("http://www.google.com");
        }

        public JsonResult GetEmployeeJson()
        {

            List<EmployeeModel> listEmp = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "suchita";
            obj.EmpSalary = 173833;

            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmpId = 2;
            obj1.EmpName = "Madhvi";
            obj1.EmpSalary = 173833;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmpId = 3;
            obj2.EmpName = "Manoj";
            obj2.EmpSalary = 273833;

            listEmp.Add(obj);
            listEmp.Add(obj1);
            listEmp.Add(obj2);

            return Json(listEmp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmployees2()
        {
            return View();
        }
        public FileResult GetMeFile()
        {
            return File("~/Web.config", "application/xml");
        }

        public FileResult GetMeFile2()
        {
            return File("~/Web.config", "text/plain");
        }

        public FileResult GetMeFile3()
        {
            return File("~/Web.config", "application/xml", "Web.config");
        }
        public FileResult GetMeFile4()
        {
            return File("~/ActionResult.pdf", "application/pdf");
        }

        public ContentResult getContent(int? id)
        {

            if (id == 1)
            {
                return Content("get Result");
            }
            else if (id == 2)
            {
                return Content("<p style='color:red'>get Result</p>");
            }
            else
            {
                return Content("<script>alert('hi guys');</script>");
            }
        }


        public RedirectToRouteResult getmeRoute()
        {
            return RedirectToRoute("Default2");
        }
        public RedirectToRouteResult getmeRoute2()
        {
            return RedirectToAction("GetMeFile4");
        }
        public RedirectToRouteResult getmeRoute3()
        {
            return RedirectToAction("index","Home",new {id=1 });
        }
    }
}

//yawarali17@gmail.com



