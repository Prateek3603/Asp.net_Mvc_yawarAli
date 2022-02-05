﻿using System;
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
            return "My Employee id is "+id;
        }

        public ActionResult Index4()
        {
            return View("Index3");
        }

        public string index5(int? id=null)
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


            ViewBag.Emp =obj;

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
            return View(obj);

        }

    }
}




