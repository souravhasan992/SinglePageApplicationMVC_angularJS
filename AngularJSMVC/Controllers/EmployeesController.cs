using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngularJSMVC.Data;
using AngularJSMVC.Models;

namespace AngularJSMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private AngularJSMVCContext db = new AngularJSMVCContext();

        // GET: Employees
        public ActionResult Index()
        {
            //var employees = db.Employees.Include(e => e.Gender);
            //return View(employees.ToList());
            return View();
        }

        public JsonResult GetEmployees()
        {
            //var list = new List<VmEmployee>();            
            //var oEmp = new VmEmployee();
            //foreach(var emp in db.Employees)
            //{
            //    oEmp.Id = emp.Id;
            //    oEmp.Name = emp.Name;
            //    oEmp.GenderId = emp.GenderId;                
            //    oEmp.GenderName = emp.Gender.Name;
            //    oEmp.JoiningDate = emp.JoiningDate;
            //    oEmp.Salary = emp.Salary;
            //    list.Add(oEmp);                
            //}
            var list = (from e in db.Employees join g in db.Genders on e.GenderId equals g.Id where e.GenderId == g.Id select new VmEmployee { 
                Id = e.Id,
                Name=e.Name,
                GenderId=e.GenderId,
                GenderName=g.Name,
                JoiningDate=e.JoiningDate,
                Salary=e.Salary            
            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public string InsertEmployee([Bind(Include = "Id,Name,GenderId,JoiningDate,Salary")] Employee employee)
        {
            if (employee != null)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return "Employee Added Successfully";
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }

        public string UpdateEmployee([Bind(Include = "Id,Name,GenderId,JoiningDate,Salary")] Employee employee)
        {
            if (employee != null)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return "Employee Updated Successfully";
            }
            else
            {
                return "Employee Not Updated! Try Again";
            }
        }

        public string DeleteEmployee([Bind(Include = "Id,Name,GenderId,JoiningDate,Salary")] Employee employee)
        {
            if (employee != null)
            {
                Employee anEmployee = db.Employees.Find(employee.Id);
                db.Employees.Remove(anEmployee);
                db.SaveChanges();
                return "Gender Deleted Successfully";
            }
            else
            {
                return "Gender Not Deleted! Try Again";
            }
        }

        public JsonResult GetGenders()
        {
            //var list = new List<VmGender>();
            //var oEmp = new VmGender();
            //foreach (var emp in db.Genders)
            //{
            //    oEmp.GenderId = emp.Id;
            //    oEmp.GenderName = emp.Name;                
            //    list.Add(oEmp);
            //}
            var list = (from g in db.Genders select new VmGender
            {                   
                            GenderId = g.Id,
                            GenderName = g.Name                            
                        }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
