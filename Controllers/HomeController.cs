using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoHemobancoWeb.DAL;
using ProjetoHemobancoWeb.Models;

namespace ProjetoHemobancoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly EstoqueDAO _estoqueDAO;
        private readonly DoacaoDAO _doacaoDAO;

        public HomeController(EstoqueDAO estoqueDAO, DoacaoDAO doacaoDAO)
        {
            _estoqueDAO = estoqueDAO;
            _doacaoDAO = doacaoDAO;
        }

        public IActionResult Index()
        {
            List<Doacao> doacao = _doacaoDAO.Listar();
            ViewBag.QuantidadeRegistros = doacao.Count();
            Doacao ultimoRegistro = _doacaoDAO.UltimoRegistro();
            ViewBag.Data = ultimoRegistro.CriadoEm.Date.ToString("dd/MM/yyyy");
            ViewBag.Horario = ultimoRegistro.CriadoEm.Hour;
            return View(_estoqueDAO.Listar());
        }
    }
}
