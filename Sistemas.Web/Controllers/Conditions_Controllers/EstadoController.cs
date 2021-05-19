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
    public class EstadoControllercs : Controller
    {
        private readonly DBContextSistema _context;

        public EstadoControllercs(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/Estado, estamos traendo todo lo que contenga estado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstado()
        {
            return await _context
                .Estados.ToListAsync();
        }

        //Get api/para traer solomente un id o una solo estado
        [HttpGet("{idEstado}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
            //variable estado para el findAsync que pedira el id
            var estado = await _context
                .Estados.FindAsync(id);

            //si estado retorna vacia
            if (estado == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return estado; // si encuentra retorna el valores
        }

        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/estado
        [HttpPut("idEstado")]
        public async Task<IActionResult> PutEstado(int id, Estado estados)
        {
            if (id != estados.idEstado)
            {
                return BadRequest();// si es diferente no da un badrequest
            }

            _context.Entry(estados)
                .State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en estado 
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
                if (!EstadoExists(id))
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

        //POST api/estado
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(Estado estados)
        {
            _context.Estados
                .Add(estados);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetEstado", new { id = estados.idEstado }, estados);
        }

        //Delete api Estado
        [HttpDelete("idEstado")]
        public async Task<ActionResult<Estado>> DeleteEstado(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el estado no sienta que la app no funiona o si esta lento
            var estado = await _context
                .Estados.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            //si hay informacion para eliminar entonces removemos de lo que venga de estado
            _context.Estados
                .Remove(estado);

            await _context
                .SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                    //no aparazca mas en nuestra BD y en nuestro backend      

            return estado;
        }

        // metodo para validar si ese estado ya existe
        private bool EstadoExists(int id)
        {
            return _context.Estados
                .Any(estado => estado.idEstado == id);
        }
    }
}
