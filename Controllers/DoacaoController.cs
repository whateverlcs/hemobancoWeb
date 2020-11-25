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
    public class DoacaoController : Controller
    {
        private readonly DoacaoDAO _doacaoDAO;
        private readonly EstoqueDAO _estoqueDAO;

        public DoacaoController(DoacaoDAO doacaoDAO, EstoqueDAO estoqueDAO)
        {
            _doacaoDAO = doacaoDAO;
            _estoqueDAO = estoqueDAO;
        }

        public IActionResult Index()
        {
            return View(_doacaoDAO.Listar());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Doador,Sangue,QuantidadeSangue,Id,CriadoEm")] Doacao doacao, string Doador, string TipoSangue)
        {
            if (ModelState.IsValid)
            {
                string nome = Doador;
                if (_doacaoDAO.BuscarPorNomeDoador(nome) != null) //vefificação para ver se existe o Doador
                {
                    Doacao mesaDoado = _doacaoDAO.BuscarPorUltimoRegistroDoacao(nome);
                    DateTime mesAtual = DateTime.Now;

                    if (_doacaoDAO.BuscarTodasAsDoaçõesPorNome(nome).Count > 0) //verificação para ver se existem doações com o nome do doador digitado 
                    {

                        if ((mesAtual.Month - mesaDoado.CriadoEm.Month) > 2) //verificação para evitar doações fora do tempo de 2 meses para uma nova doação
                        {
                            if (_estoqueDAO.BuscarPorTipoSangue(TipoSangue) != null)
                            {
                                RealizarDoacao(nome, doacao, TipoSangue);
                                return RedirectToAction(nameof(Index));
                            }
                            else
                            {
                                ModelState.AddModelError("", "Tipo de sangue não existente no estoque!");
                            }
                                
                        }
                        else
                        {
                            ModelState.AddModelError("", "Você já realizou uma doação recentemente, aguarde 2 meses!");
                        }

                    }
                    else
                    {
                        if (_estoqueDAO.BuscarPorTipoSangue(TipoSangue) != null)
                        {
                            RealizarDoacao(nome, doacao, TipoSangue);
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            ModelState.AddModelError("", "Tipo de sangue não existente no estoque!");
                        }
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Doador não encontrado!");
                }
            }
            ViewBag.NomeDoador = Doador;
            ViewBag.TipoSangue = TipoSangue;
            return View(doacao);
        }

        private void RealizarDoacao(string nome, Doacao doacao, string TipoSangue)
        {
            Doador doador = _doacaoDAO.BuscarPorNomeDoador(nome);

            Sangue sangue = new Sangue
            {
                TipoSangue = TipoSangue
            };

            doacao = new Doacao
            {
                Doador = doador,
                Sangue = sangue,
            };

                _doacaoDAO.Cadastrar(doacao);

                DateTime alteracao = DateTime.Now;
                Estoque estoque = _estoqueDAO.BuscarPorTipoSangue(doacao.Sangue.TipoSangue);
                estoque.Quantidade = estoque.Quantidade + 1;
                estoque.QuantidadeLitros = estoque.QuantidadeLitros + 0.45f;
                estoque.AlteradoEm = alteracao;
                _estoqueDAO.Alterar(estoque);
        }

        private bool DoacaoExists(int id)
        {
            return _doacaoDAO.AcharDoacaoExistente(id);
        }
    }
}
