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
        [HttpPost]
        public ActionResult SearchEmployee(string EmpName)
        {
            var param = new DynamicParameters();
            param.Add("@EmpName",  EmpName);
            var Employees = con.Query<EmployeeModel>("[dbo].[spr_searchEmployeeByName]", param: param, commandType: CommandType.StoredProcedure).ToList();
            return View("Index",Employees);
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

        public ActionResult Edit(int ? id)
        {
            var param = new DynamicParameters();
            param.Add("@EmpId", id);
            var Employee = con.QueryFirstOrDefault<EmployeeModel>("[dbo].usp_getEmployeesById", param: param, commandType: CommandType.StoredProcedure);

            return View(Employee);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            var param = new DynamicParameters();
            param.Add("@Empid", emp.EmpId);
            param.Add("@EmpName", emp.EmpName);
            param.Add("@EmpSalary", emp.EmpSalary);


            var Employee = con.Execute("[spr_updateEmployeeDetails]", param: param, commandType: CommandType.StoredProcedure);

            return RedirectToAction("index");
        }
    }
}