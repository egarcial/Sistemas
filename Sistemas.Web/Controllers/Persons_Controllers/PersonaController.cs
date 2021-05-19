using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas.Datos;
using Sistemas.Entidades.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Persons_Controllers
{
    public class PersonaController : Controller
    {
        private readonly DBContextSistema _context;

        public PersonaController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/Persona, estamos traendo todo lo que contenga persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersona()
        {
            return await _context
                .Personas.ToListAsync();
        }

        //Get api/para traer solomente un id o una solo persona
        [HttpGet("{idPersona}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            //variable persona para el findAsync que pedira el id
            var persona = await _context
                .Personas.FindAsync(id);
            
            //si persona retorna vacia
            if (persona == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return persona; // si encuentra retorna el valores
        }

        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/Persona
        [HttpPut("idPersona")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.idPersona)
            {
                return BadRequest();// si es diferente no da un badrequest
            }

            _context.Entry(persona)
                .State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en persona 
                                                                     vamos a realizar una modificacion , las entidad ya tiene las propiedades
                                                                       o informacion que vamos a guardar*/

            /*el manejo de erro try nos evitará  tener problemas a evitar que si hay error que la api no falle*/
            try
            {
                await _context
                    .SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)//esto lo que hara un rollback a la operacion que se esta realizando
            {
                if (!PersonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;// por si desconocemos el error
                }

            }
            return NoContent();
        }

        //POST api/Persona
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            _context.Personas
                .Add(persona);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetPersona", new { id = persona.idPersona }, persona);
        }

        //Delete api Persona
        [HttpDelete("idPersona")]
        public async Task<ActionResult<Persona>> DeletePersona(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el Persona no sienta que la app no funiona o si esta lento
            var persona = await _context
                .Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            //si hay informacion para eliminar entonces removemos de lo que venga de persona
            _context.Personas
                .Remove(persona);

            await _context
                .SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                              //no aparazca mas en nuestra BD y en nuestro backend      

            return persona;
        }
        
        // metodo para validar si ese persona ya existe
        private bool PersonaExists(int id)
        {
            return _context.Personas
                .Any(persona => persona.idPersona == id);
        }
    }
}
