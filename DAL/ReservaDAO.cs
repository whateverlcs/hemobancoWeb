using Microsoft.EntityFrameworkCore;
using ProjetoHemobancoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoHemobancoWeb.DAL
{
    public class ReservaDAO
    {
        private readonly Context _context;
        public ReservaDAO(Context context)
        {
            _context = context;
        }
        public bool Cadastrar(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
            return true;
        }
        public List<Reserva> Listar() => _context.Reservas.Include(f => f.Funcionario).ToList();
        public Funcionario BuscarPorNome(string nome) => _context.Funcionarios.FirstOrDefault(x => x.Nome == nome);
    }
}
