using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.BD.Data.Entidades
{
    [Index(nameof(Id), Name = "AlojamientoID_UQ", IsUnique = true)]
    public class Alojamiento:EntityBase
    {
        public string NombreAlojamiento { get; set; }
        public string DireccionAlojamiento { get; set; }
        public List<Reserva> Reservas { get; set; }
    }
}
