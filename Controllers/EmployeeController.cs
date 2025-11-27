using CrudApplicatoin.Data;
using CrudApplicatoin.Models;
using CrudApplicatoin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CrudApplicatoin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

       
        public async Task<IActionResult> Index()
        {
            var result = await _repo.GetAllAsync();
            return View(result);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Employee model)
        {
            if (!ModelState.IsValid) {

                TempData["error"] = "Invalid from data";
                return View(model);

            }

            await _repo.AddAsync(model);
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {
           var emp = await _repo.GetByIdAsync(id);

            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(Employee model)
        {
            await _repo.UpdateAsync(model);
            return RedirectToAction("Index");
        }

    }
}
