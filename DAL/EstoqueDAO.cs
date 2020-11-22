using Microsoft.EntityFrameworkCore;
using ProjetoHemobancoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoHemobancoWeb.DAL
{
    public class EstoqueDAO
    {
        private readonly Context _context;
        public EstoqueDAO(Context context)
        {
            _context = context;
        }
        public bool Cadastrar(Estoque estoque)
        {
            _context.Estoques.Add(estoque);
            _context.SaveChanges();
            return true;
        }
        public List<Estoque> Listar() => _context.Estoques.Include(s => s.Sangue).Include(f => f.Funcionario).ToList();
        public Funcionario BuscarPorNome(string nome) => _context.Funcionarios.FirstOrDefault(x => x.Nome == nome);
        public Estoque BuscarPorTipoSangue(string tipoSangue) => _context.Estoques.FirstOrDefault(x => x.Sangue.TipoSangue == tipoSangue);
        public void Alterar(Estoque estoque)
        {
            _context.Estoques.Update(estoque);
            _context.SaveChanges();
        }
    }
}
