using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JP2.Data;
using JP2.Models;
using Microsoft.AspNetCore.Authorization;

namespace JP2.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public ApplicationController(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        // GET: Application
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Application.Include(a => a.Job).Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Application/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Application == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .Include(a => a.Job)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: Application/Create
        public IActionResult Create()
        {
            ViewData["JobId"] = new SelectList(_context.Set<Job>(), "Id", "JobDescription");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "UserEmail");
            return View();
        }

        // POST: Application/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationDate,JobTitle,JobId,UserId")] Application application)
        {
            if (ModelState.IsValid)
            {
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobId"] = new SelectList(_context.Set<Job>(), "Id", "JobDescription", application.JobId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "UserEmail", application.UserId);
            return View(application);
        }

        // GET: Application/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Application == null)
            {
                return NotFound();
            }

            var application = await _context.Application.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.Set<Job>(), "Id", "JobDescription", application.JobId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "UserEmail", application.UserId);
            return View(application);
        }

        // POST: Application/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationDate,JobTitle,JobId,UserId")] Application application)
        {
            if (id != application.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobId"] = new SelectList(_context.Set<Job>(), "Id", "JobDescription", application.JobId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "UserEmail", application.UserId);
            return View(application);
        }

        // GET: Application/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Application == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .Include(a => a.Job)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Application/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Application == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Application'  is null.");
            }
            var application = await _context.Application.FindAsync(id);
            if (application != null)
            {
                _context.Application.Remove(application);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(int id)
        {
          return (_context.Application?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
