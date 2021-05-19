using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas.Datos;
using Sistemas.Entidades.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Users_Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RolController : Controller
    {
        private readonly DBContextSistema _context;

        public RolController(DBContextSistema context)
        {
            _context = context;
        }


        //GET api/Rol, estamos traendo todo lo que contenga rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRol()
        {
            return await _context
                .Rols.ToListAsync();
        }


        //Get api/para traer solomente un id o una solo rol
        [HttpGet("{idRol}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            //variable rol para el findAsync que pedira el id
            var rol = await _context.Rols.FindAsync(id);
            //si rol retorna vacia

            if (rol == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return rol; // si encuentra retorna el valores
        }


        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/Rol
        [HttpPut("idRol")]
        public async Task<IActionResult> PutRol(int id, Rol rol)
        {
            if (id != rol.idRol)
            {
                return BadRequest();// si es diferente no da un badrequest
            }
            _context.Entry(rol).State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en rol 
                                                              vamos a realizar una modificacion , las entidad ya tiene las propiedades
                                                               o informacion que vamos a guardar*/

            /*el manejo de erro try nos evitará  tener problemas a evitar que si hay error que la api no falle*/
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)//esto lo que hara un rollback a la operacion que se esta realizando
            {
                if (!RolExists(id))
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


        //POST api/Rol
        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol(Rol rol)
        {
            _context.Rols.Add(rol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRol", new { id = rol.idRol }, rol);

        }


        //Delete api Rol
        [HttpDelete("idRol")]
        public async Task<ActionResult<Rol>> DeleteRol(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el usuario no sienta que la app no funiona o si esta lento
            var rol = await _context.Rols.FindAsync(id);

            if (rol == null)
            {
                return NotFound();
            }
            //si hay informacion para eliminar entonces removemos de lo que venga de rol
            _context.
                Rols.Remove(rol);

            await _context
                .SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                              //no aparazca mas en nuestra BD y en nuestro backend      

            return rol;
        }


        // metodo para validar si ese rol ya existe
        private bool RolExists(int id)
        {
            return _context
                .Rols.Any(rol => rol.idRol == id);
        }

    }
}
