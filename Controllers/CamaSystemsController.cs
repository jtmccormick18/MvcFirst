using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcFirst.Models;

namespace MvcFirst.Controllers
{
    public class CamaSystemsController : Controller
    {
        private readonly MvcFirstContext _context;

        public CamaSystemsController(MvcFirstContext context)
        {
            _context = context;
        }

        // GET: CamaSystems
        public async Task<IActionResult> Index()
        {
            return View(await _context.CamaSystem.ToListAsync());
        }

        // GET: CamaSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camaSystem = await _context.CamaSystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camaSystem == null)
            {
                return NotFound();
            }

            return View(camaSystem);
        }

        // GET: CamaSystems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CamaSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PropertyKeyName,OwnerKeyName")] CamaSystem camaSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camaSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(camaSystem);
        }

        // GET: CamaSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camaSystem = await _context.CamaSystem.FindAsync(id);
            if (camaSystem == null)
            {
                return NotFound();
            }
            return View(camaSystem);
        }

        // POST: CamaSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PropertyKeyName,OwnerKeyName")] CamaSystem camaSystem)
        {
            if (id != camaSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camaSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamaSystemExists(camaSystem.Id))
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
            return View(camaSystem);
        }

        // GET: CamaSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camaSystem = await _context.CamaSystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camaSystem == null)
            {
                return NotFound();
            }

            return View(camaSystem);
        }

        // POST: CamaSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camaSystem = await _context.CamaSystem.FindAsync(id);
            _context.CamaSystem.Remove(camaSystem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CamaSystemExists(int id)
        {
            return _context.CamaSystem.Any(e => e.Id == id);
        }
    }
}
