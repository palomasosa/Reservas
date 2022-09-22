using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.BD.Data.Entidades
{
    [Index(nameof(PersonaId), Name = "PersonaId_UQ", IsUnique = true)]

    public class RespReserva : EntityBase
    {
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        public List<Reserva> reservas { get; set; }
    }
}
