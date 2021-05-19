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
    public class TipoPersonaController : Controller
    {
        private readonly DBContextSistema _context;

        public TipoPersonaController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/tipoPersona, estamos traendo todo lo que contenga tipopersona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPersona>>> GetTipoPersona()
        {
            return await _context
                .TipoPersonas.ToListAsync();
        }

        //Get api/para traer solomente un id o una solo tipo persona
        [HttpGet("{idTipoPersona}")]
        public async Task<ActionResult<TipoPersona>> GetTipoPersona(int id)
        {
            //variable tipo persona para el findAsync que pedira el id
            var tPersona = await _context
                .TipoPersonas.FindAsync(id);

            //si tipo persona retorna vacia
            if (tPersona == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return tPersona; // si encuentra retorna el valores
        }

        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/ tipo Persona
        [HttpPut("idTipoPersona")]
        public async Task<IActionResult> PutTipoPersona(int id, TipoPersona tPersona)
        {
            if (id != tPersona.idTipoPersona)
            {
                return BadRequest();// si es diferente no da un badrequest
            }

            _context.Entry(tPersona)
                .State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en tipopersona 
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
                if (!TipoPersonaExists(id))
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

        //POST api/tipo Persona
        [HttpPost]
        public async Task<ActionResult<TipoPersona>> PostTipoPersona(TipoPersona tPersona)
        {
            _context.TipoPersonas
                .Add(tPersona);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetTipoPersona", new { id = tPersona.idTipoPersona }, tPersona);
        }

        //Delete api Persona
        [HttpDelete("idTipoPersona")]
        public async Task<ActionResult<TipoPersona>> DeleteTipoPersona(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el tipo de Persona no sienta que la app no funiona o si esta lento
            var tPersona = await _context
                .TipoPersonas.FindAsync(id);

            if (tPersona == null)
            {
                return NotFound();
            }

            //si hay informacion para eliminar entonces removemos de lo que venga de tipo persona
            _context.TipoPersonas
                .Remove(tPersona);

            await _context
                .SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                    //no aparazca mas en nuestra BD y en nuestro backend      

            return tPersona;
        }

        // metodo para validar si ese tipo persona ya existe
        private bool TipoPersonaExists(int id)
        {
            return _context.TipoPersonas
                .Any(tPersona => tPersona.idTipoPersona == id);
        }
    }
}
