using ProjetoHemobancoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoHemobancoWeb.DAL
{
    public class FuncionarioDAO
    {
        private readonly Context _context;
        public FuncionarioDAO(Context context)
        {
            _context = context;
        }
        public bool Cadastrar(Funcionario funcionario)
        {
            if (BuscarPorCpf(funcionario.Cpf) == null)
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Alterar(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            _context.SaveChanges();
        }
        public void Remover(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
        }
        public Funcionario BuscarPorCpf(string cpf) => _context.Funcionarios.FirstOrDefault(x => x.Cpf == cpf);
        public List<Funcionario> Listar() => _context.Funcionarios.ToList();
        public Funcionario ProcurarPorId(int? id) => _context.Funcionarios.Find(id);
        public Funcionario VerificarId(int? id) => _context.Funcionarios.FirstOrDefault(m => m.Id == id);
        public bool AcharFuncionarioExistente(int id) => _context.Funcionarios.Any(e => e.Id == id);
    }
}
