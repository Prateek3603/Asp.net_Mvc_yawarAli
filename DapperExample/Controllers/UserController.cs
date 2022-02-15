using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DapperExample.Models;

namespace DapperExample.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");
        //public ActionResult Index()
        //{
        //    var Employees=con.Query<EmployeeModel>("select *  FROM [Employee].[dbo].[employeeDetails]").ToList();
        //    return View(Employees);
        //}

        public ActionResult Index()
        {
            var Employees = con.Query<EmployeeModel>("[dbo].[sp_employee]",commandType:CommandType.StoredProcedure).ToList();
            return View(Employees);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            var param = new DynamicParameters();
            param.Add("@EmpName",emp.EmpName);
            param.Add("@EmpSalary",emp.EmpSalary);
            int result = con.Execute("sp_InsertEmployee",param:param, commandType: CommandType.StoredProcedure);
            return RedirectToAction("index");
        }
    }
}