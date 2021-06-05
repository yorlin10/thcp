using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thcp.Data;
using thcp.Models;

namespace thcp.Controllers
{
    public class DepartmetnsController : Controller
    {
        private readonly ApplicationDbContext db;

        public DepartmetnsController(ApplicationDbContext db)
        {
            this.db = db;
             
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Departments.ToListAsync());

        }

        // Crear por medio de vista
        public IActionResult Create() 
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<ActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Add(department);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        
        }
    }
}
