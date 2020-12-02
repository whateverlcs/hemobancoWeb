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
    [Route("api/Doacao")]
    [ApiController]
    public class DoacaoAPIController : ControllerBase
    {
        private readonly DoacaoDAO _doacaoDAO;
        public DoacaoAPIController(DoacaoDAO doacaoDAO)
        {
            _doacaoDAO = doacaoDAO;
        }

        //GET: /api/Doacao/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<Doacao> doacoes = _doacaoDAO.Listar();
            if (doacoes.Count > 0)
            {
                return Ok(doacoes);
            }
            return BadRequest(new { msg = "Não existem registros de doações!" });
        }

        //GET: /api/Doacao/Buscar
        [HttpGet]
        [Route("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            Doacao doacao = _doacaoDAO.VerificarId(id);
            if (doacao != null)
            {
                return Ok(doacao);
            }
            return NotFound(new { msg = "Doação não encontrada!" });
        }
    }
}
