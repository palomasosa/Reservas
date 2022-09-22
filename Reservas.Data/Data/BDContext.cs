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
        public DbSet<Alojamiento> Alojamientos { get; set; }
        public DbSet<Persona> Personas { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach ( /// Desactiva la eliminacion en cascada de todas las relaciones
                var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

            public BDContext(DbContextOptions options) : base(options)
        {

        }
    }
}
