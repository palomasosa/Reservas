using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.BD.Data.Entidades
{
    [Index(nameof(ID), Name = "RespReservaID_UQ", IsUnique = true)]
    public class RespReserva : EntityBase
    {
    }
}
