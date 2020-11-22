using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHemobancoWeb.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Sangue> Sangues { get; set; }
        public DbSet<Doador> Doadores { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

    }
}
