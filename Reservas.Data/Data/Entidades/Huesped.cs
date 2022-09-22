using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.BD.Data.Entidades
{

    [Index(nameof(PersonaId), Name = "PersonaId_UQ", IsUnique = true)]

    public class Huesped: EntityBase
    {
        [Required]
        [MaxLength(8, ErrorMessage = "El DNI no debe superar los 8 caracteres")]
        [MinLength(7, ErrorMessage ="El DNI no debe tener menos de 7 caracteres")]
        public string DNI { get; set; }
        public string Nacionalidad { get; set; }
        public string Domicilio { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        public List<Reserva> reservas { get; set; }
    }
}
