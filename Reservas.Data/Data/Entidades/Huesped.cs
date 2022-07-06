using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.BD.Data.Entidades
{
    [Index(nameof(DNI), Name = "HuespedDNI_UQ", IsUnique = true)]
    public class Huesped : EntityBase
    {
        [Required]
        [MaxLength(8, ErrorMessage = "El DNI no debe superar los 8 caracteres")]
        public int DNI { get; set; }
        public string Nacionalidad { get; set; }
        public string Domicilio { get; set; }
    }
}
