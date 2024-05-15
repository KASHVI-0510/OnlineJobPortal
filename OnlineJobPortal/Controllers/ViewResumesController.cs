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
    public class ViewResumesController : Controller
    {
        private readonly JobportalContext _context;

        public ViewResumesController(JobportalContext context)
        {
            _context = context;
        }

        // GET: ViewResumes
        public async Task<IActionResult> Index()
        {
              return _context.ViewResumes != null ? 
                          View(await _context.ViewResumes.ToListAsync()) :
                          Problem("Entity set 'JobportalContext.ViewResumes'  is null.");
        }

        // GET: ViewResumes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ViewResumes == null)
            {
                return NotFound();
            }

            var viewResume = await _context.ViewResumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viewResume == null)
            {
                return NotFound();
            }

            return View(viewResume);
        }

        // GET: ViewResumes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ViewResumes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,JobTitle,UserName,UserEmail,MobileNo")] ViewResume viewResume)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewResume);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewResume);
        }

        // GET: ViewResumes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ViewResumes == null)
            {
                return NotFound();
            }

            var viewResume = await _context.ViewResumes.FindAsync(id);
            if (viewResume == null)
            {
                return NotFound();
            }
            return View(viewResume);
        }

        // POST: ViewResumes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,JobTitle,UserName,UserEmail,MobileNo")] ViewResume viewResume)
        {
            if (id != viewResume.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewResume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViewResumeExists(viewResume.Id))
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
            return View(viewResume);
        }

        // GET: ViewResumes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ViewResumes == null)
            {
                return NotFound();
            }

            var viewResume = await _context.ViewResumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viewResume == null)
            {
                return NotFound();
            }

            return View(viewResume);
        }

        // POST: ViewResumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ViewResumes == null)
            {
                return Problem("Entity set 'JobportalContext.ViewResumes'  is null.");
            }
            var viewResume = await _context.ViewResumes.FindAsync(id);
            if (viewResume != null)
            {
                _context.ViewResumes.Remove(viewResume);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViewResumeExists(int id)
        {
          return (_context.ViewResumes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
