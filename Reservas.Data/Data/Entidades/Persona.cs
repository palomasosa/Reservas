using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.BD.Data.Entidades
{

    public class Persona : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Telefono { get; set; }
        public string Mail { get; set; }
        public Huesped huesped { get; set; }
        public RespReserva respReserva { get; set; }    

    }
}
