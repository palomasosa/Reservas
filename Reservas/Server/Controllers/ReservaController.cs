using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservas.BD.Data;
using Reservas.BD.Data.Entidades;

namespace Reservas.Server.Controllers
{
    [ApiController]
    [Route("api/Reservas")]

    public class ReservaController : ControllerBase
    {
        private readonly BDContext context;
        public ReservaController(BDContext bdcontext)
        {
            this.context = bdcontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reserva>>> Get()
        {
            return await context.Reservas.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Reserva>> Get(int id)
        {
            var reserva = await context.Reservas.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (reserva == null)
            {
                return NotFound($"No existe una reserva de Id= {id}");
            }
            return Ok(reserva);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Reserva reserva)
        {
            try
            {
                context.Reservas.Add(reserva);
                await context.SaveChangesAsync();
                return reserva.Id;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Reserva reserva)
        {
            var reservaSolicitada = context.Reservas
                .Where(x => x.Id == id).FirstOrDefault();
            if (reservaSolicitada == null)
            {
                return NotFound("No se encontró la reserva a modificar");
            }
            reservaSolicitada.fechaDeposito = reserva.fechaDeposito;
            reservaSolicitada.fechaEntrada = reserva.fechaEntrada;
            reservaSolicitada.fechaSalida = reserva.fechaSalida;
            reservaSolicitada.totalPasajeros = reserva.totalPasajeros;
            reservaSolicitada.totalNoches = reserva.totalNoches;
            reservaSolicitada.horarioCheckIn = reserva.horarioCheckIn;
            reservaSolicitada.horarioCheckOut = reserva.horarioCheckOut;
            reservaSolicitada.precioTotal = reserva.precioTotal;
            reservaSolicitada.saldoRestante = reserva.saldoRestante;    
            reservaSolicitada.HuespedId = reserva.HuespedId;    
            reservaSolicitada.RespReservaId = reserva.RespReservaId;
            reservaSolicitada.AlojamientoId = reserva.AlojamientoId;

            try
            {
                context.Reservas.Update(reservaSolicitada);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest("Los datos no se han podido actualizar");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var reservaSolicitada = context.Reservas.Where(x => x.Id == id).FirstOrDefault();
            if (reservaSolicitada == null)
            {
                return NotFound($"No se encontró la reserva de Id {id}");
            }
            try
            {
                context.Reservas.Remove(reservaSolicitada);
                context.SaveChanges();
                return Ok($"El registro de Id {reservaSolicitada.Id} se ha eliminado correctamente");
            }
            catch (Exception e)
            {

                return BadRequest($"Los datos no pudieron ser eliminados" +
                    $" por: {e.Message}");
            }
        }

    }
}
