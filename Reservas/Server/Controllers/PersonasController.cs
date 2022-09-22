using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservas.BD.Data;
using Reservas.BD.Data.Entidades;

namespace Reservas.Server.Controllers
{
    [ApiController]
    [Route("api/Personas")]

    public class PersonasController : ControllerBase
    {
        private readonly BDContext context;
        public PersonasController(BDContext bdcontext)
        {
            this.context = bdcontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get(){
            return await context.Personas.ToListAsync();
         }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Persona>> Get(int id) {
            var persona = await context.Personas.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (persona == null)
            {
                return NotFound($"No existe una persona de Id= {id}");
            }
            return Ok(persona); 
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Persona persona)
        {
            try
            {
                context.Personas.Add(persona);
                await context.SaveChangesAsync();
                return persona.Id;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Persona persona)
        {
            var personaSolicitada = context.Personas
                .Where(x => x.Id == id).FirstOrDefault();
            if (personaSolicitada == null)
            {
                return NotFound("No se encontró la persona a modificar");
            }
            personaSolicitada.Telefono = persona.Telefono; 
            personaSolicitada.Apellido = persona.Apellido;
            personaSolicitada.Mail = persona.Mail;

            try
            {
                context.Personas.Update(personaSolicitada);
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
            var personaSolicitada = context.Personas.Where(x => x.Id == id).FirstOrDefault();
            if (personaSolicitada == null)
            {
                return NotFound($"No se encontró la persona de Id {id}");
            }
            try
            {
                context.Personas.Remove(personaSolicitada);
                context.SaveChanges();
                return Ok($"El registro de {personaSolicitada.Nombre} se ha eliminado correctamente");
            }
            catch (Exception e)
            {

                return BadRequest($"Los datos no pudieron ser eliminados por: {e.Message}");
            }
        }

    }
}
