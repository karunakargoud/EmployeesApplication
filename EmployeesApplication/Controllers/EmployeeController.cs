using EmployeesApplication.DAL;
using EmployeesApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace EmployeesApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;
        public EmployeeController()
        {
            _context = new EmployeeContext();
        }
        public ActionResult Index()
        {
            //List<Employee> elist = _context.Employees.ToList();
            //return View(elist);
            List<Employee> elist = _context.Employees.Include("Depo").ToList();
            return View(elist);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<Deportment> deportments = _context.Deportments.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (Deportment dept in deportments)
            {
                if (dept.DepotmentId == 101)
                {
                    list.Add(new SelectListItem()
                    {
                        Text = dept.DeportmentName,
                        Value = dept.DepotmentId.ToString(),
                        Selected = true

                    });
                }
                else
                {
                    list.Add(new SelectListItem()
                    {
                        Text = dept.DeportmentName,
                        Value = dept.DepotmentId.ToString()

                    });

                }
            }
            ViewData["DepotmentId"] = list;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
                List<Employee> elist = _context.Employees.Include("Depo").ToList();
                return View("Index", elist);
            }
            else
            {
                return View(emp);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee e = _context.Employees.Find(id);
            List<Deportment> deportments = _context.Deportments.ToList();
            List<SelectListItem>list= new List<SelectListItem>();
            foreach(Deportment dp in deportments)
            {
                if (dp.DepotmentId == e.DepotmentId)
                {
                    list.Add(new SelectListItem()
                    {
                        Text = dp.DeportmentName,
                        Value = dp.DepotmentId.ToString(),
                        Selected=true

                    });
                }
                else
                {
                    list.Add(new SelectListItem()
                    {
                        Text = dp.DeportmentName,
                        Value = dp.DepotmentId.ToString()
                    });

                }
            }
            ViewBag.DepotmentId = list;
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            Employee emp1 = _context.Employees.Find(emp.EmployeeId);
            emp1.EmployeeName = emp.EmployeeName;
            emp1.Salary = emp.Salary;
            emp1.Address = emp.Address;
            emp1.DepotmentId = emp.DepotmentId;
            _context.SaveChanges();
            List<Employee> elist = _context.Employees.Include("Depo").ToList();
            return View("Index", elist);
        }
        public ActionResult Details(int id)
        {
            Employee e = _context.Employees.Include("Depo").First(x => x.EmployeeId == id);
            return View(e);
        }
        public ActionResult Delete(int id)
        {
            Employee e =_context.Employees.Find(id);
            _context.Employees.Remove(e);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}