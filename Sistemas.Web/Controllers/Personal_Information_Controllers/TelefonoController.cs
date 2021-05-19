using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas.Datos;
using Sistemas.Entidades.Personal_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Personal_Information_Controllers
{
    public class TelefonoController : Controller
    {
        private readonly DBContextSistema _context;

        public TelefonoController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/telefono, estamos traendo todo lo que contenga telefono
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefono>>> GetTelefono()
        {
            return await _context
                .Telefonos.ToListAsync();
        }

        //Get api/para traer solomente un id o una solo telefono
        [HttpGet("{idTelefono}")]
        public async Task<ActionResult<Telefono>> GetTelefono(int id)
        {
            //variable telefono para el findAsync que pedira el id
            var telefono = await _context
                .Telefonos.FindAsync(id);

            //si telefono retorna vacia
            if (telefono == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return telefono; // si encuentra retorna el valores
        }

        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/telefono
        [HttpPut("idTelefono")]
        public async Task<IActionResult> PutTelefono(int id, Telefono telefono)
        {
            if (id != telefono.idTelefono)
            {
                return BadRequest();// si es diferente no da un badrequest
            }

            _context.Entry(telefono)
                .State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en telefono 
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
                if (!TelefonoExists(id))
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

        //POST api/telefono
        [HttpPost]
        public async Task<ActionResult<Telefono>> PostTelefono(Telefono telefono)
        {
            _context.Telefonos
                .Add(telefono);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetTelefono", new { id = telefono.idTelefono }, telefono);
        }

        //Delete api telefono
        [HttpDelete("idTelefono")]
        public async Task<ActionResult<Telefono>> DeleteTelefono(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el telefono no sienta que la app no funiona o si esta lento
            var telefono = await _context
                .Telefonos.FindAsync(id);

            if (telefono == null)
            {
                return NotFound();
            }

            //si hay informacion para eliminar entonces removemos de lo que venga de telefono
            _context.Telefonos
                .Remove(telefono);

            await _context
                .SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                    //no aparazca mas en nuestra BD y en nuestro backend      

            return telefono;
        }

        // metodo para validar si ese telefono ya existe
        private bool TelefonoExists(int id)
        {
            return _context.Telefonos
                .Any(telefono => telefono.idTelefono == id);
        }
    }
}
