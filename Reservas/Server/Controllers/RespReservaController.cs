using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservas.BD.Data;
using Reservas.BD.Data.Entidades;

namespace Reservas.Server.Controllers
{
    [ApiController]
    [Route("api/RespReservas")]
    public class RespReservaController : ControllerBase
    {

        private readonly BDContext context;
        public RespReservaController(BDContext bdcontext)
        {
            this.context = bdcontext;
        }
        [HttpGet]
        public async Task<ActionResult<List<RespReserva>>> Get()
        {
            return await context.RespReservas.Include(x=> x.Persona).ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RespReserva>> Get(int id)
        {
            var respReserva = await context.RespReservas.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (respReserva == null)
            {
                return NotFound($"No existe un responsable de reserva de ID={id}");
            }
            return respReserva;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(RespReserva respReserva)
        {
            try
            {
                context.RespReservas.Add(respReserva);
                await context.SaveChangesAsync();
                return respReserva.Id;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] RespReserva respReserva)
        {
            //if (id != respReserva.Id)
            //{
            //    return BadRequest("Datos incorrectos");
            //}

            var respReservaSolicitado = context.RespReservas
                .Where(e => e.Id == id).FirstOrDefault();

            if (respReservaSolicitado == null)
            {
                return NotFound("No se encontró el responsable de reserva a modificar");
            }

            respReservaSolicitado.PersonaId = respReserva.PersonaId;


            try
            {
                context.RespReservas.Update(respReservaSolicitado);
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
            var respReservaSolicitado = context.RespReservas.Where(e => e.Id == id).FirstOrDefault();
            if (respReservaSolicitado == null)
            {
                return NotFound($"No se encontró el responsable de reserva con el id {id}");
            }
            try
            {
                context.RespReservas.Remove(respReservaSolicitado);
                context.SaveChanges();
                return Ok($"El registro de {respReservaSolicitado.Id} se ha eliminado correctamente");
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no pudieron ser eliminados por :{e.Message}");

            }

        }
    }
}

