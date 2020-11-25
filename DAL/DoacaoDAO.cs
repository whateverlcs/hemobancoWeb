using Microsoft.EntityFrameworkCore;
using ProjetoHemobancoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoHemobancoWeb.DAL
{
    public class DoacaoDAO
    {
        private readonly Context _context;
        public DoacaoDAO(Context context)
        {
            _context = context;
        }
        public bool Cadastrar(Doacao doacao)
        {
            _context.Doacoes.Add(doacao);
            _context.SaveChanges();
            return true;
        }
        public Doador BuscarPorNomeDoador(string nome) => _context.Doadores.FirstOrDefault(x => x.Nome == nome); //metodo usado para verificar se existe um doador
        public Doacao BuscarPorDoador(string nome) => _context.Doacoes.FirstOrDefault(x => x.Doador.Nome == nome); //método usado para buscar um doador nas doações para futura exclusão, pois ao excluir um doador, deve se excluir a doação
        public List<Doacao> Listar() => _context.Doacoes.Include(d => d.Sangue).Include(d => d.Doador).ToList(); //listagem de todas as doações
        public Doacao BuscarPorUltimoRegistroDoacao(string nome)
        {
            List<Doacao> lstDoacoes = _context.Doacoes.Include(d => d.Sangue).Include(d => d.Doador).ToList();

            lstDoacoes.FindAll(d => d.Doador.Nome == nome);

            return lstDoacoes.OrderBy(d => d.CriadoEm).LastOrDefault();

            //return _context.Doacoes.OrderByDescending(x => x.Doador.Nome == nome).Take(1).Last(); 

        } //pega o ultimo registro realizado daquele doador em especifico para a validação
        public Doacao UltimoRegistro()
        {
            List<Doacao> lstDoacoes = _context.Doacoes.Include(d => d.Sangue).Include(d => d.Doador).ToList();
            return lstDoacoes.OrderBy(d => d.CriadoEm).LastOrDefault();
        }
        public List<Doacao> BuscarTodasAsDoaçõesPorNome(string nome) => _context.Doacoes.Where(x => x.Doador.Nome.Equals(nome)).ToList(); //verifica se existem doações com esse doador
        public Doacao ProcurarPorId(int? id) => _context.Doacoes.Find(id);
        public Doacao VerificarId(int? id) => _context.Doacoes.FirstOrDefault(m => m.Id == id);
        public bool AcharDoacaoExistente(int id) => _context.Doacoes.Any(e => e.Id == id);
        public void Remover(Doacao doacao)
        {
            _context.Doacoes.Remove(doacao);
            _context.SaveChanges();
        }
    }
}
