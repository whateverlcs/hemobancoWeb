﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoHemobancoWeb.Models;

namespace ProjetoHemobancoWeb.Controllers
{
    public class DoadorController : Controller
    {
        private readonly Context _context;

        public DoadorController(Context context)
        {
            _context = context;
        }

        // GET: Doador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doadores.ToListAsync());
        }

        // GET: Doador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doador = await _context.Doadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doador == null)
            {
                return NotFound();
            }

            return View(doador);
        }

        // GET: Doador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Cpf,Idade,Email,Endereco,Telefone,Celular,Id,CriadoEm")] Doador doador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doador);
        }

        // GET: Doador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doador = await _context.Doadores.FindAsync(id);
            if (doador == null)
            {
                return NotFound();
            }
            return View(doador);
        }

        // POST: Doador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Cpf,Idade,Email,Endereco,Telefone,Celular,Id,CriadoEm")] Doador doador)
        {
            if (id != doador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoadorExists(doador.Id))
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
            return View(doador);
        }

        // GET: Doador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doador = await _context.Doadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doador == null)
            {
                return NotFound();
            }

            return View(doador);
        }

        // POST: Doador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doador = await _context.Doadores.FindAsync(id);
            _context.Doadores.Remove(doador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoadorExists(int id)
        {
            return _context.Doadores.Any(e => e.Id == id);
        }
    }
}
