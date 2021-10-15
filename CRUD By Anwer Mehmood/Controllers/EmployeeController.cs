using CRUD_By_Anwer_Mehmood.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_By_Anwer_Mehmood.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext _db;
        public EmployeeController(EmployeeContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Employees.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
       }
       [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = _db.Employees.Where(a => a.Id == id).FirstOrDefault();
            return View(edit);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var find = _db.Employees.Find(employee.Id);
            if (find != null)
            {
                find.Name = employee.Name;
                find.Position = employee.Position;
                find.Salary = employee.Salary;
                _db.Employees.Update(find);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var del = _db.Employees.Where(d => d.Id == id).FirstOrDefault();
            return View(del);
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {;
            var find = _db.Employees.Find(employee.Id);
            if(find!=null)
            {
                _db.Employees.Remove(find);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

    
}
