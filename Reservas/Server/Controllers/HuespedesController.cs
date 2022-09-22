using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservas.BD.Data;
using Reservas.BD.Data.Entidades;

namespace Reservas.Server.Controllers
{
    [ApiController]
    [Route("api/Huespedes")]
    public class HuespedesController : ControllerBase
    {

        private readonly BDContext context;
        public HuespedesController(BDContext bdcontext)
        {
            this.context = bdcontext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Huesped>>> Get()
        {
            return await context.Huespedes.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Huesped>> Get(int id)
        {
            var huesped = await context.Huespedes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (huesped == null)
            {
                return NotFound($"No existe un huésped de ID={id}");
            }
            return huesped;
        }
        [HttpGet("HuespedPorDNI/{DNI}")]
        public async Task<ActionResult<Huesped>> HuespedPorDNI(string DNI)
        {
            var huesped = await context.Huespedes
                .Where(e => e.DNI == DNI)
               //.Include(m => m.)
                .FirstOrDefaultAsync();
            if (huesped == null)
            {
                return NotFound($"No existe un huésped de DNI {DNI}");
            }
            return huesped;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Huesped huesped)
        {
            try
            {
                context.Huespedes.Add(huesped);
                await context.SaveChangesAsync();
                return huesped.Id;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Huesped huesped)
        {
            //if (id != huesped.Id)
            //{
            //    return BadRequest("Datos incorrectos");
            //}

            var huespedSolicitado = context.Huespedes
                .Where(e => e.Id == id).FirstOrDefault();

            if (huespedSolicitado == null)
            {
                return NotFound("No se encontró el huésped a modificar");
            }

            huespedSolicitado.DNI = huesped.DNI;
            huespedSolicitado.Domicilio = huesped.Domicilio;
            huespedSolicitado.Nacionalidad = huesped.Nacionalidad;
            

            try
            {
                context.Huespedes.Update(huespedSolicitado);
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
            var huespedSolicitado = context.Huespedes.Where(e => e.Id == id).FirstOrDefault();
            if (huespedSolicitado == null)
            {
                return NotFound($"No se encontró el huésped con el id {id}");
            }
            try
            {
                context.Huespedes.Remove(huespedSolicitado);
                context.SaveChanges();
                return Ok($"El registro de {huespedSolicitado.Id} se ha eliminado correctamente");
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no pudieron ser eliminados por :{e.Message}");

            }

        }
    }
}

