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
    public class DireccionController : Controller
    {
        private readonly DBContextSistema _context;

        public DireccionController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/direccion, estamos traendo todo lo que contenga direccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direccion>>> GetDireccion()
        {
            return await _context
                .Direcciones.ToListAsync();
        }

        //Get api/para traer solomente un id o una solo direccion
        [HttpGet("{idDireccion}")]
        public async Task<ActionResult<Direccion>> GetDireccion(int id)
        {
            //variable direcicon para el findAsync que pedira el id
            var direccion = await _context
                .Direcciones.FindAsync(id);

            //si direccion retorna vacia
            if (direccion == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return direccion; // si encuentra retorna el valores
        }

        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/direccion
        [HttpPut("idDireccion")]
        public async Task<IActionResult> PutDireccion(int id, Direccion direccion)
        {
            if (id != direccion.idDireccion)
            {
                return BadRequest();// si es diferente no da un badrequest
            }

            _context.Entry(direccion)
                .State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en direciones 
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
                if (!DireccionExists(id))
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

        //POST api/Direcciones
        [HttpPost]
        public async Task<ActionResult<Direccion>> PostDireccion(Direccion direccion)
        {
            _context.Direcciones
                .Add(direccion);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetDireccion", new { id = direccion.idDireccion }, direccion);
        }

        //Delete api Direcciones
        [HttpDelete("idDireccion")]
        public async Task<ActionResult<Direccion>> DeleteDireccion(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el direcciones no sienta que la app no funiona o si esta lento
            var direccion = await _context
                .Direcciones.FindAsync(id);

            if (direccion == null)
            {
                return NotFound();
            }

            //si hay informacion para eliminar entonces removemos de lo que venga de direcciones
            _context.Direcciones
                .Remove(direccion);

            await _context
                .SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                    //no aparazca mas en nuestra BD y en nuestro backend      

            return direccion;
        }

        // metodo para validar si ese direciones ya existe
        private bool DireccionExists(int id)
        {
            return _context.Direcciones
                .Any(direccion => direccion.idDireccion == id);
        }
    }
}
