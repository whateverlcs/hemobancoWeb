using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoHemobancoWeb.DAL;
using ProjetoHemobancoWeb.Models;
using ProjetoHemobancoWeb.Utils;

namespace ProjetoHemobancoWeb.Controllers
{
    [Authorize(Roles = "Administrador,Funcionario")]
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioDAO _funcionarioDAO;

        public FuncionarioController(FuncionarioDAO funcionarioDAO)
        {
            _funcionarioDAO = funcionarioDAO;
        }

        public IActionResult Index()
        {
            return View(_funcionarioDAO.Listar());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,Cpf,Email,Id,CriadoEm")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                if (Validacao.ValidarCpf(funcionario.Cpf))
                {
                    if (_funcionarioDAO.Cadastrar(funcionario))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "Esse funcionário já existe!");
                }
                ModelState.AddModelError("", "Cpf inválido!");
            }
            return View(funcionario);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = _funcionarioDAO.ProcurarPorId(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Nome,Cpf,Email,Id,CriadoEm")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _funcionarioDAO.Alterar(funcionario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
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
            return View(funcionario);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = _funcionarioDAO.VerificarId(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var funcionario = _funcionarioDAO.ProcurarPorId(id);
            _funcionarioDAO.Remover(funcionario);
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _funcionarioDAO.AcharFuncionarioExistente(id);
        }
    }
}
