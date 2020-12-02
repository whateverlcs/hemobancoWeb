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
        public Estoque ProcurarPorId(int? id) => _context.Estoques.Find(id);
        public Estoque VerificarId(int? id) => _context.Estoques.Include(s => s.Sangue).Include(f => f.Funcionario).FirstOrDefault(m => m.Id == id);
        public bool AcharEstoqueExistente(int id) => _context.Estoques.Any(e => e.Id == id);
        public Funcionario BuscarPorNome(string nome) => _context.Funcionarios.FirstOrDefault(x => x.Nome == nome);
        public Estoque BuscarPorTipoSangue(string tipoSangue) => _context.Estoques.FirstOrDefault(x => x.Sangue.TipoSangue == tipoSangue);
        public Sangue BuscarPorSangue(string tipoSangue) => _context.Sangues.FirstOrDefault(x => x.TipoSangue == tipoSangue);
        public void Alterar(Estoque estoque)
        {
            _context.Estoques.Update(estoque);
            _context.SaveChanges();
        }
        public void Remover(Estoque estoque)
        {
            _context.Estoques.Remove(estoque);
            _context.SaveChanges();
        }
    }
}
