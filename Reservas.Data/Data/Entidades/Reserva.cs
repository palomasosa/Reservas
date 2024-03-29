﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.BD.Data.Entidades
{
    [Index(nameof(Id), Name = "ReservaID_UQ", IsUnique = true)]
    public class Reserva : EntityBase
    {
        public int horarioCheckIn { get; set; }
        public int horarioCheckOut { get; set; }
        public int totalPasajeros { get; set; }
        public DateTime fechaEntrada { get; set; }
        public DateTime fechaSalida { get; set; }
        public int totalNoches { get; set; }
        public DateTime fechaDeposito { get; set; }
        public int montoDeposito { get; set; }
        public int saldoRestante { get; set; }
        public int precioTotal { get; set; }

        //N
        public int HuespedId { get; set; }
        public int RespReservaId { get; set; }
        public Huesped Huesped { get; set; }
        public RespReserva RespReserva { get; set; }
        public int AlojamientoId { get; set; }
        public Alojamiento Alojamiento { get; set; }
    }
}

