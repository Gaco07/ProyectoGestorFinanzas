using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorPersonal.Areas.Identity.Data;
using GestorPersonal.Models;

namespace GestorPersonal.Controllers
{
    public class InformesController : Controller
    {
        private readonly GGContext _context;

        public InformesController(GGContext context)
        {
            _context = context;
        }

        // GET: Informes
        public async Task<IActionResult> Index()
        {
            var currentUser = User?.Identity?.Name;

            return _context.Informe != null ?
                          View(_context.Informe.Include(c => c.Gasto).ToList().Where(informe => informe.Gasto.UsuarioId == currentUser)) :
                          Problem("Entity set 'GGContext.Gasto'  is null.");
        }

        //GET: Informes/Details/5
        public async void Details(int? id)
        {
            //if (id == null || _context.Informe == null)
            //{
            //    return NotFound();
            //}

            //var informe = await _context.Informe
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (informe == null)
            //{
            //    return NotFound();
            //}

            //return View(informe);
        }

        //GET: Informes/Create
        public void Create()
        {
            //return View();
        }

        //POST: Informes/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

       [HttpPost]
        [ValidateAntiForgeryToken]
        public async void Create([Bind("Id,UsuarioId")] Informe informe)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(informe);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["IdUsuario"] = new SelectList(_context.Usuario, "Id", "Id", informe.UsuarioId);
            //return View(informe);
        }

        //GET: Informes/Edit/5
        public async void Edit(int? id)
        {
            //if (id == null || _context.Informe == null)
            //{
            //    return NotFound();
            //}

            //var informe = await _context.Informe.FindAsync(id);
            //if (informe == null)
            //{
            //    return NotFound();
            //}
            //return View(informe);
        }

        //POST: Informes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async void Edit(int id, [Bind("Id,IdUsuario,IdGasto")] Informe informe)
        {
            //if (id != informe.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(informe);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!InformeExists(informe.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(informe);
        }

        //GET: Informes/Delete/5
        public async void Delete(int? id)
        {
            //if (id == null || _context.Informe == null)
            //{
            //    return NotFound();
            //}

            //var informe = await _context.Informe
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (informe == null)
            //{
            //    return NotFound();
            //}

            //return View(informe);
        }

        //POST: Informes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Informe == null)
            {
                return Problem("Entity set 'GGContext.Informe'  is null.");
            }
            var informe = await _context.Informe.FindAsync(id);
            if (informe != null)
            {
                _context.Informe.Remove(informe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void InformeExists(int id)
        {
            //return (_context.Informe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
