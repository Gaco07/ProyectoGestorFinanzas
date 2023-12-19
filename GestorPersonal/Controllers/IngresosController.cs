using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorPersonal.Areas.Identity.Data;
using GestorPersonal.Models;
using Microsoft.AspNetCore.Identity;

namespace GestorPersonal.Controllers
{
    public class IngresosController : Controller
    {
        private readonly GGContext _context;

        public IngresosController(GGContext context)
        {
            _context = context;
        }

        // GET: Ingresos
        public async Task<IActionResult> Index()
        {
            var currentUser = User?.Identity?.Name;

            return _context.Ingreso != null ?
                View(_context.Ingreso.ToList().Where(ingreso => ingreso.UsuarioId == currentUser)) :
                Problem("Entity set 'GGContext.Ingreso'  is null.");
        }

        // GET: Ingresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ingreso == null)
            {
                return NotFound();
            }

            var ingreso = await _context.Ingreso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingreso == null)
            {
                return NotFound();
            }

            return View(ingreso);
        }

        // GET: Ingresos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingresos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Monto,Fecha,UsuarioId")] Ingreso ingreso)
        {
            string currentUserName = User?.Identity?.Name;
            ingreso.UsuarioId = currentUserName;

            if (ModelState.IsValid)
            {
                _context.Add(ingreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", ingreso.UsuarioId);
            return View(ingreso);
        }

        // GET: Ingresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ingreso == null)
            {
                return NotFound();
            }

            var ingreso = await _context.Ingreso.FindAsync(id);
            if (ingreso == null)
            {
                return NotFound();
            }
            return View(ingreso);
        }

        // POST: Ingresos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Monto,Fecha,UsuarioId")] Ingreso ingreso)
        {
            if (id != ingreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngresoExists(ingreso.Id))
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
            return View(ingreso);
        }

        // GET: Ingresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ingreso == null)
            {
                return NotFound();
            }

            var ingreso = await _context.Ingreso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingreso == null)
            {
                return NotFound();
            }

            return View(ingreso);
        }

        // POST: Ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ingreso == null)
            {
                return Problem("Entity set 'GGContext.Ingreso'  is null.");
            }
            var ingreso = await _context.Ingreso.FindAsync(id);
            if (ingreso != null)
            {
                _context.Ingreso.Remove(ingreso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngresoExists(int id)
        {
          return (_context.Ingreso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
