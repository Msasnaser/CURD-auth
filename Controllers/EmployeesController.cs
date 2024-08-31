using CURD.Data;
using CURD.Models;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace CURD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();

            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }
        //بعد ما نضغط على اضافة بالفورم رح يتنفذ  
         
        [HttpPost]
        public IActionResult Create (Employee emp)
        {
            _context.Employees.Add(emp);
           _context.SaveChanges();
           //عشان يرجع للاندكس اللي هو الاصل عشان اعرض الداتا  
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var employees = _context.Employees.Find(id);

            return View(employees);
        }
        //رح يستقبل الداتا الجديدة اللي جاي من الفورم بعد التعديل
        public IActionResult Edit(Employee emp)
        {
            var employee = _context.Employees.Find(emp.Id);
            if (employee != null)
            {
                employee.Name = emp.Name;
                employee.Email = emp.Email;  
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
