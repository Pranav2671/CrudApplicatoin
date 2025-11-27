using CrudApplicatoin.Data;
using CrudApplicatoin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CrudApplicatoin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext _context;

        public EmployeeController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Employee/Index
        public async Task<IActionResult> Index()
        {
            var result = await _context.Employees.ToListAsync();
            return View(result);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public async Task<IActionResult> Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    Name = model.Name,
                    City = model.City,
                    State = model.State,
                    Salary = model.Salary
                };

                await _context.Employees.AddAsync(emp);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            TempData["error"] = "Empty field can't be submitted";
            return View(model);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (emp == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (emp == null)
            {
                return NotFound();
            }

            var result = new Employee()
            {
                Id = emp.Id,
                Name = emp.Name,
                City = emp.City,
                State = emp.State,
                Salary = emp.Salary
            };

            return View(result);
        }

        // POST: Employee/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Employee model)
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
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
