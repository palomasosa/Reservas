using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.BD.Data.Entidades
{
    internal class Reserva
    {   
        public string NombreAlojamiento { get; set; }  
        public string DireccionAlojamiento { get; set; }
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
    }
}

//Las reservas: Nombre y la dirección del establecimiento en el cual se alojarán los
//huéspedes, horario de check-in y check-out, el total de pasajeros, las fechas
//previstas de entrada y salida, total de noches, la fecha del depósito de la reserva,
//el monto en concepto de seña, el saldo restante a pagar y el precio total de la
//tarifa.