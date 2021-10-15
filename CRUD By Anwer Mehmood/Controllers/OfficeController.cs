using CRUD_By_Anwer_Mehmood.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_By_Anwer_Mehmood.Controllers
{
    public class OfficeController : Controller
    {
        private EmployeeContext _db;
        public OfficeController(EmployeeContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Offices.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Office office)
        {
            _db.Offices.Add(office);
            _db.SaveChanges();
            return RedirectToAction("Index", "Office");
        }

        public IActionResult Edit(int id)
        {
            var edit = _db.Offices.Where(a => a.Id == id).FirstOrDefault();
            return View(edit);
        }
        [HttpPost]

        public IActionResult Edit(Office office)
        {
            var find = _db.Offices.Find(office.Id);
            if(find != null)
            {
                find.Name = office.Name;
                find.Address = office.Address;
                find.Number = office.Number;
                _db.Offices.Update(find);
                _db.SaveChanges();
                return RedirectToAction("Index1");
            }
            return View();

        }
        public IActionResult Delete(int id)
        {
            var del = _db.Offices.Where(d => d.Id == id).FirstOrDefault();
            return View(del);
        }
        [HttpPost]
        public IActionResult Delete()
        {
            return View();
        }

    }
}
