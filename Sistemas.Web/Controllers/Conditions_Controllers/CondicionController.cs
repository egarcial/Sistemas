using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas.Datos;
using Sistemas.Entidades.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Conditions_Controllers
{
    public class CondicionController : Controller
    {
        private readonly DBContextSistema _context;

        public CondicionController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/condicion, estamos traendo todo lo que contenga condicion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condicion>>> GetCondicion()
        {
            return await _context
                .Condiciones.ToListAsync();
        }

        //Get api/para traer solomente un id o una solo condicion
        [HttpGet("{idCondicion}")]
        public async Task<ActionResult<Condicion>> GetCondicion(int id)
        {
            //variable condicion para el findAsync que pedira el id
            var condicion = await _context
                .Condiciones.FindAsync(id);

            //si condicion retorna vacia
            if (condicion == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return condicion; // si encuentra retorna el valores
        }

        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/condicion
        [HttpPut("idCondicion")]
        public async Task<IActionResult> PutCondicion(int id, Condicion condicion)
        {
            if (id != condicion.idCondicion)
            {
                return BadRequest();// si es diferente no da un badrequest
            }

            _context.Entry(condicion)
                .State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en condicion
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
                if (!CondicionExists(id))
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

        //POST api/Condiciones
        [HttpPost]
        public async Task<ActionResult<Condicion>> PostCondicion(Condicion condiciones)
        {
            _context.Condiciones
                .Add(condiciones);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetCondicion", new { id = condiciones.idCondicion }, condiciones);
        }

        //Delete api COndcion
        [HttpDelete("idCondicion")]
        public async Task<ActionResult<Condicion>> DeleteCondicion(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el Condicion no sienta que la app no funiona o si esta lento
            var condicion = await _context
                .Condiciones.FindAsync(id);

            if (condicion == null)
            {
                return NotFound();
            }

            //si hay informacion para eliminar entonces removemos de lo que venga de condicion
            _context.Condiciones
                .Remove(condicion);

            await _context
                .SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                    //no aparazca mas en nuestra BD y en nuestro backend      

            return condicion;
        }

        // metodo para validar si ese condicion ya existe
        private bool CondicionExists(int id)
        {
            return _context.Condiciones
                .Any(condicion => condicion.idCondicion == id);
        }
    }
}
