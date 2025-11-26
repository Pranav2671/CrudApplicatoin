using CrudApplicatoin.Data;
using CrudApplicatoin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplicatoin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext _context;
        public EmployeeController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Employees.ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (Employee model)
        {
            if (ModelState.IsValid) {
                var emp = new Employee()
                {
                    Name = model.Name,
                    City = model.City,
                    State = model.State,
                    Salary = model.Salary

                };

                _context.Employees.Add(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty feild cant submitted";
                return View(model);
            }

        }

        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.Id == id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.Id == id);

            var result = new Employee()
            {
                Name = emp.Name,
                City = emp.City,
                State = emp.State,
                Salary = emp.Salary
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                Id = model.Id,
                Name = model.Name,
                City = model.City,
                State = model.State,
                Salary = model.Salary
            };

            _context.Employees.Update(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
