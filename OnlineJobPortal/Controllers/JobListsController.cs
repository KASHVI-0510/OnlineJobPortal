using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Models;

namespace OnlineJobPortal.Controllers
{
    public class JobListsController : Controller
    {
        private readonly JobportalContext _context;

        public JobListsController(JobportalContext context)
        {
            _context = context;
        }

        // GET: JobLists
        public async Task<IActionResult> Index()
        {
              return _context.JobLists != null ? 
                          View(await _context.JobLists.ToListAsync()) :
                          Problem("Entity set 'JobportalContext.JobLists'  is null.");
        }

        // GET: JobLists/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.JobLists == null)
            {
                return NotFound();
            }

            var jobList = await _context.JobLists
                .FirstOrDefaultAsync(m => m.JobTitle == id);
            if (jobList == null)
            {
                return NotFound();
            }

            return View(jobList);
        }

        // GET: JobLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobTitle,NoOfPost,QualificationReqiured,ExperienceReqiured,Company,Country,State")] JobList jobList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobList);
        }

        // GET: JobLists/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.JobLists == null)
            {
                return NotFound();
            }

            var jobList = await _context.JobLists.FindAsync(id);
            if (jobList == null)
            {
                return NotFound();
            }
            return View(jobList);
        }

        // POST: JobLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("JobTitle,NoOfPost,QualificationReqiured,ExperienceReqiured,Company,Country,State")] JobList jobList)
        {
            if (id != jobList.JobTitle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobListExists(jobList.JobTitle))
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
            return View(jobList);
        }

        // GET: JobLists/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.JobLists == null)
            {
                return NotFound();
            }

            var jobList = await _context.JobLists
                .FirstOrDefaultAsync(m => m.JobTitle == id);
            if (jobList == null)
            {
                return NotFound();
            }

            return View(jobList);
        }

        // POST: JobLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.JobLists == null)
            {
                return Problem("Entity set 'JobportalContext.JobLists'  is null.");
            }
            var jobList = await _context.JobLists.FindAsync(id);
            if (jobList != null)
            {
                _context.JobLists.Remove(jobList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobListExists(string id)
        {
          return (_context.JobLists?.Any(e => e.JobTitle == id)).GetValueOrDefault();
        }
    }
}
