using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gadara2.Models;
using Gadara2.Models.Entities;

namespace Gadara2.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly Appdbcontext _context;

        public ProjectsController(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var projects = await _context.Projects.Include(x=>x.taskks).ThenInclude(x=>x.User).FirstOrDefaultAsync(m => m.ProjectsId == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Projects projects)
        {
            _context.Projects.Add(projects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }
            return View(projects);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectsId,Title,Description,Startdate,Enddate")] Projects projects)
        {
            if (id != projects.ProjectsId)
            {
                return NotFound();
            }
            _context.Update(projects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects
                .FirstOrDefaultAsync(m => m.ProjectsId == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var projects = await _context.Projects.FindAsync(id);
            if (projects != null)
            {
                _context.Projects.Remove(projects);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
