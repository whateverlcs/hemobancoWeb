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
    public class DoadorController : Controller
    {
        private readonly DoadorDAO _doadorDAO;
        private readonly DoacaoDAO _doacaoDAO;

        public DoadorController(DoadorDAO doadorDAO, DoacaoDAO doacaoDAO)
        {
            _doadorDAO = doadorDAO;
            _doacaoDAO = doacaoDAO;
        }

        public IActionResult Index()
        {
            return View(_doadorDAO.Listar());
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,Cpf,Idade,Email,Endereco,Telefone,Celular,Id,CriadoEm")] Doador doador)
        {
            if (ModelState.IsValid)
            {
                if (Validacao.ValidarCpf(doador.Cpf))
                {
                    if (_doadorDAO.Cadastrar(doador))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "Esse doador já existe!");
                }
                ModelState.AddModelError("", "Cpf inválido!");
            }
            return View(doador);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doador = _doadorDAO.ProcurarPorId(id);
            if (doador == null)
            {
                return NotFound();
            }
            return View(doador);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Nome,Cpf,Idade,Email,Endereco,Telefone,Celular,Id,CriadoEm")] Doador doador)
        {
            if (id != doador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _doadorDAO.Alterar(doador);
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

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doador = _doadorDAO.VerificarId(id);
            if (doador == null)
            {
                return NotFound();
            }

            return View(doador);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var doador = _doadorDAO.ProcurarPorId(id);
            Doacao doacao = _doacaoDAO.BuscarPorDoador(doador.Nome); //método para buscar a doação realizada por esse usuário para exclusão
            if (doacao != null)
            {
                _doacaoDAO.Remover(doacao);
            }
            _doadorDAO.Remover(doador);
            return RedirectToAction(nameof(Index));
        }

        private bool DoadorExists(int id)
        {
            return _doadorDAO.AcharDoadorExistente(id);
        }
    }
}
