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
        DbSet<Huesped> Huespedes { get; set; }
        DbSet<RespReserva> RespReservas { get; set; }
        DbSet<Reserva> Reservas { get; set; }
        public BDContext(DbContextOptions options) : base(options)
        {

        }
    }
}
