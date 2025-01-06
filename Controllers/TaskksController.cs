using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gadara2.Models;
using Gadara2.Models.Entities;
using Gadara2.ViewModels;

namespace Gadara2.Controllers
{
    public class TaskksController : Controller
    {
        private readonly Appdbcontext _context;

        public TaskksController(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var appdbcontext = _context.Taskk.Include(t => t.Projects).Include(t => t.User);
            return View(await appdbcontext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskk = await _context.Taskk
                .Include(t => t.Projects)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TaskkId == id);
            if (taskk == null)
            {
                return NotFound();
            }

            return View(taskk);
        }

        // GET: Taskks/Create
        public async Task<IActionResult> Create()
        {
            var users = await _context.Users.ToListAsync();
            var projects = await _context.Projects.ToListAsync();
            Taskviewmodel model = new Taskviewmodel()
            {
                Projects = projects,
                User = users
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create( Taskviewmodel model)
        {
            Taskk taskk = new Taskk();
            taskk.ProjectId = model.ProjectId;
            taskk.UserId = model.UserId;
            taskk.Title = model.Title;
            taskk.Description = model.Description;
            taskk.status = model.status;
            taskk.Deadline = model.Deadline;
            await _context.Taskk.AddAsync(taskk);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Projects");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskk = await _context.Taskk.FindAsync(id);
            if (taskk == null)
            {
                return NotFound();
            }
            var users = await _context.Users.ToListAsync();
            var projects = await _context.Projects.ToListAsync();
            Taskviewmodel model = new Taskviewmodel()
            {
                TaskkId = taskk.TaskkId,
                Projects = projects,
                User = users,
                Title = taskk.Title,
                Description = taskk.Description,
                Deadline = taskk.Deadline,
                status = taskk.status,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Taskviewmodel model)
        {

            var taskk = await _context.Taskk.FirstOrDefaultAsync(m => m.TaskkId == model.TaskkId);
            if (taskk != null)
            {
                taskk.ProjectId = model.ProjectId;
                taskk.UserId = model.UserId;
                taskk.Title = model.Title;
                taskk.Description = model.Description;
                taskk.status = model.status;
                taskk.Deadline = model.Deadline;
                _context.Taskk.Update(taskk);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Projects");
        }

        // GET: Taskks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskk = await _context.Taskk
                .Include(t => t.Projects)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TaskkId == id);
            if (taskk == null)
            {
                return NotFound();
            }
            return View(taskk);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var taskk = await _context.Taskk.FindAsync(id);
            if (taskk != null)
            {
                _context.Taskk.Remove(taskk);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
