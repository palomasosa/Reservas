using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.BD.Data.Entidades
{
    internal class Huesped : EntityBase
    {
        public int DNI { get; set; }
        public string Nacionalidad { get; set; }
        public string Domicilio { get; set; }
    }
}
