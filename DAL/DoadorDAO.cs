using Microsoft.EntityFrameworkCore;
using ProjetoHemobancoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoHemobancoWeb.DAL
{
    public class DoadorDAO
    {
        private readonly Context _context;
        public DoadorDAO(Context context)
        {
            _context = context;
        }
        public bool Cadastrar(Doador doador)
        {
            if (BuscarPorCpf(doador.Cpf) == null)
            {
                _context.Doadores.Add(doador);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public Doador BuscarPorCpf(string cpf) => _context.Doadores.FirstOrDefault(x => x.Cpf == cpf); //método que verifica se existe um doador com esse cpf
        public List<Doador> Listar() => _context.Doadores.ToList();
        public Doador ProcurarPorId(int? id) => _context.Doadores.Find(id);
        public Doador VerificarId(int? id) => _context.Doadores.FirstOrDefault(m => m.Id == id);
        public bool AcharDoadorExistente(int id) => _context.Doadores.Any(e => e.Id == id);
        public void Alterar(Doador doador)
        {
            _context.Doadores.Update(doador);
            _context.SaveChanges();
        }
        public void Remover(Doador doador)
        {
            _context.Doadores.Remove(doador);
            _context.SaveChanges();
        }
        public List<Doacao> FiltrarPorTipoSangue(string tipoSangue) => _context.Doacoes.Where(x => x.Sangue.TipoSangue.Equals(tipoSangue)).Include(d => d.Doador).Include(s => s.Sangue).ToList(); //retorna as doações com esse tipo de sangue
    }
}
