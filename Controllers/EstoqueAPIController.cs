using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoHemobancoWeb.DAL;
using ProjetoHemobancoWeb.Models;

namespace ProjetoHemobancoWeb.Controllers
{
    [Route("api/Estoque")]
    [ApiController]
    public class EstoqueAPIController : ControllerBase
    {

        private readonly EstoqueDAO _estoqueDAO;
        public EstoqueAPIController(EstoqueDAO estoqueDAO)
        {
            _estoqueDAO = estoqueDAO;
        }

        //GET: /api/Estoque/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<Estoque> estoque = _estoqueDAO.Listar();
            if (estoque.Count > 0)
            {
                return Ok(estoque);
            }
            return BadRequest(new { msg = "Não existem registros de itens no estoque!" });
        }

        //GET: /api/Estoque/Buscar
        [HttpGet]
        [Route("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            Estoque estoque = _estoqueDAO.VerificarId(id);
            if (estoque != null)
            {
                return Ok(estoque);
            }
            return NotFound(new { msg = "Item no estoque não encontrado!" });
        }

        //POST: /api/Estoque/Cadastrar
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                _estoqueDAO.Cadastrar(estoque);
                return Created("", estoque);
            }
            return BadRequest(ModelState);
        }

    }
}
