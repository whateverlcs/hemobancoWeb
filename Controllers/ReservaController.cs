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

namespace ProjetoHemobancoWeb.Controllers
{
    [Authorize(Roles = "Administrador,Funcionario")]
    public class ReservaController : Controller
    {
        private readonly ReservaDAO _reservaDAO;
        private readonly EstoqueDAO _estoqueDAO;

        public ReservaController(ReservaDAO reservaDAO, EstoqueDAO estoqueDAO)
        {
            _reservaDAO = reservaDAO;
            _estoqueDAO = estoqueDAO;
        }

        public IActionResult Index()
        {
            return View(_reservaDAO.Listar());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Funcionario,TipoSangue,Quantidade,Id,CriadoEm")] Reserva reserva, string Funcionario)
        {
            if (ModelState.IsValid)
            {
                if (_estoqueDAO.BuscarPorTipoSangue(reserva.TipoSangue) != null) //verificação para ver se existe o tipo de sangue no estoque
                {
                    Estoque estoque = _estoqueDAO.BuscarPorTipoSangue(reserva.TipoSangue);
                    if (reserva.Quantidade < estoque.Quantidade) //verificação da quantidade no estoque, para não ficar com saldo negativo no estoque
                    {
                        string nome = Funcionario;
                        if (_reservaDAO.BuscarPorNome(nome) != null)  //verificação para ver se existe o funcionário
                        {
                            Funcionario funcionario = _reservaDAO.BuscarPorNome(nome);
                            reserva.Funcionario = funcionario;

                            _reservaDAO.Cadastrar(reserva);

                            DateTime alteracao = DateTime.Now;
                            estoque.Quantidade = estoque.Quantidade - reserva.Quantidade; //decrementa no estoque a quantidade, de acordo com o sangue digitado
                            estoque.QuantidadeLitros = estoque.QuantidadeLitros - (float)(reserva.Quantidade * 0.45f); //decrementa a quantidade em Litros, de acordo com o sangue digitado
                            estoque.AlteradoEm = alteracao; //atualiza o alteradoEm no estoque com o dia atual, para controle
                            _estoqueDAO.Alterar(estoque);

                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            ModelState.AddModelError("", "Funcionário não encontrado!");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "A quantidade digitada excede ao que se tem no estoque!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tipo de sangue não encontrado!");
                }
            }
            ViewBag.NomeFunc = Funcionario;
            return View(reserva);
        }

        private bool ReservaExists(int id)
        {
            return _reservaDAO.AcharReservaExistente(id);
        }
    }
}
