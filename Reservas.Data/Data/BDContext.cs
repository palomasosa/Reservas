using Microsoft.EntityFrameworkCore;
using Reservas.BD.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.BD.Data
{
    public class BDContext : DbContext
    {
        public DbSet<Huesped> Huespedes { get; set; }
        public DbSet<RespReserva> RespReservas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public BDContext(DbContextOptions options) : base(options)
        {

        }
    }
}
