using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaMVC.Context;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Controllers
{
    public class LibrosController : Controller
    {
        private readonly BiblioDatabaseContext _context;

        public LibrosController(BiblioDatabaseContext context)
        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            var biblioDatabaseContext = _context.Libros.Include(l => l.Autor).Include(l => l.Editorial).Include(l => l.Genero);
            return View(await biblioDatabaseContext.ToListAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Editorial)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.IDLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["IDAutor"] = new SelectList(_context.Autores, "IDAutor", "IDAutor");
            ViewData["IDEditorial"] = new SelectList(_context.Editoriales, "IDEditorial", "IDEditorial");
            ViewData["IDGenero"] = new SelectList(_context.Generos, "IDGenero", "IDGenero");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDLibro,Titulo,IDAutor,IDGenero,IDEditorial")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDAutor"] = new SelectList(_context.Autores, "IDAutor", "IDAutor", libro.IDAutor);
            ViewData["IDEditorial"] = new SelectList(_context.Editoriales, "IDEditorial", "IDEditorial", libro.IDEditorial);
            ViewData["IDGenero"] = new SelectList(_context.Generos, "IDGenero", "IDGenero", libro.IDGenero);
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["IDAutor"] = new SelectList(_context.Autores, "IDAutor", "IDAutor", libro.IDAutor);
            ViewData["IDEditorial"] = new SelectList(_context.Editoriales, "IDEditorial", "IDEditorial", libro.IDEditorial);
            ViewData["IDGenero"] = new SelectList(_context.Generos, "IDGenero", "IDGenero", libro.IDGenero);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDLibro,Titulo,IDAutor,IDGenero,IDEditorial")] Libro libro)
        {
            if (id != libro.IDLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.IDLibro))
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
            ViewData["IDAutor"] = new SelectList(_context.Autores, "IDAutor", "IDAutor", libro.IDAutor);
            ViewData["IDEditorial"] = new SelectList(_context.Editoriales, "IDEditorial", "IDEditorial", libro.IDEditorial);
            ViewData["IDGenero"] = new SelectList(_context.Generos, "IDGenero", "IDGenero", libro.IDGenero);
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Editorial)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.IDLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.IDLibro == id);
        }
    }
}
