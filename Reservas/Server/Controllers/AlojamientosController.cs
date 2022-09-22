using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservas.BD.Data;
using Reservas.BD.Data.Entidades;

namespace Reservas.Server.Controllers
{
    [ApiController]
    [Route("api/Alojamientos")]

    public class AlojamientosController : ControllerBase
    {
        private readonly BDContext context;
        public AlojamientosController(BDContext bdcontext)
        {
            this.context = bdcontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alojamiento>>> Get()
        {
            return await context.Alojamientos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Alojamiento>> Get(int id)
        {
            var alojamiento = await context.Alojamientos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (alojamiento == null)
            {
                return NotFound($"No existe un alojamiento de Id= {id}");
            }
            return Ok(alojamiento);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Alojamiento alojamiento)
        {
            try
            {
                context.Alojamientos.Add(alojamiento);
                await context.SaveChangesAsync();
                return alojamiento.Id;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Alojamiento alojamiento)
        {
            var alojamientoSolicitada = context.Alojamientos
                .Where(x => x.Id == id).FirstOrDefault();
            if (alojamientoSolicitada == null)
            {
                return NotFound("No se encontró la persona a modificar");
            }
            alojamientoSolicitada.NombreAlojamiento = alojamiento.NombreAlojamiento;
            alojamientoSolicitada.DireccionAlojamiento = alojamiento.DireccionAlojamiento;

            try
            {
                context.Alojamientos.Update(alojamientoSolicitada);
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
            var alojamientoSolicitada = context.Alojamientos.Where(x => x.Id == id).FirstOrDefault();
            if (alojamientoSolicitada == null)
            {
                return NotFound($"No se encontró el alojamiento de Id {id}");
            }
            try
            {
                context.Alojamientos.Remove(alojamientoSolicitada);
                context.SaveChanges();
                return Ok($"El registro de {alojamientoSolicitada.NombreAlojamiento} se ha eliminado correctamente");
            }
            catch (Exception e)
            {

                return BadRequest($"Los datos no pudieron ser eliminados" +
                    $" por: {e.Message}");
            }
        }

    }
}
