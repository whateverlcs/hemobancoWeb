using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoHemobancoWeb.DAL;
using ProjetoHemobancoWeb.Models;

namespace ProjetoHemobancoWeb.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly EstoqueDAO _estoqueDAO;

        public EstoqueController(EstoqueDAO estoqueDAO)
        {
            _estoqueDAO = estoqueDAO;
        }

        public IActionResult Index()
        {
            return View(_estoqueDAO.Listar());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Funcionario,Sangue,Quantidade,UnidadeMedida,QuantidadeLitros,AlteradoEm,Id,CriadoEm")] Estoque estoque, string Funcionario, string TipoSangue)
        {
            if (ModelState.IsValid)
            {
                Sangue sangue = new Sangue
                {
                    TipoSangue = TipoSangue
                };
                estoque.Sangue = sangue;
                estoque.QuantidadeLitros = (Convert.ToInt32(estoque.Quantidade) * 450) / 1000f;
                if (_estoqueDAO.BuscarPorNome(Funcionario) != null)
                {
                    Funcionario func = _estoqueDAO.BuscarPorNome(Funcionario);
                    estoque.Funcionario = func;
                    _estoqueDAO.Cadastrar(estoque);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Funcionário não encontrado!");
            }
            ViewBag.NomeFunc = Funcionario;
            ViewBag.TipoSangue = TipoSangue;
            return View(estoque);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = _estoqueDAO.VerificarId(id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var estoque = _estoqueDAO.ProcurarPorId(id);
            _estoqueDAO.Remover(estoque);
            return RedirectToAction(nameof(Index));
        }

        private bool EstoqueExists(int id)
        {
            return _estoqueDAO.AcharEstoqueExistente(id);
        }
    }
}
