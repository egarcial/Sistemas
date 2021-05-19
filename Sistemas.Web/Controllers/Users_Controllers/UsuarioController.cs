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
    public class UsuarioController : Controller
    {

        private readonly DBContextSistema _context;

        public UsuarioController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/Usuario, estamos traendo todo lo que contenga usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }
        //Get api/para traer solomente un id o una solo usuario
        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            //variable usuario para el findAsync que pedira el id
            var usuario = await _context.Usuarios.FindAsync(id);
            //si usuario retorna vacia

            if (usuario == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return usuario; // si encuentra retorna el valores
        }
        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/Usuario
        [HttpPut("idUsuario")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.idUsuario)
            {
                return BadRequest();// si es diferente no da un badrequest
            }
            _context.Entry(usuario).State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en usuario 
                                                                     vamos a realizar una modificacion , las entidad ya tiene las propiedades
                                                                       o informacion que vamos a guardar*/

            /*el manejo de erro try nos evitará  tener problemas a evitar que si hay error que la api no falle*/
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)//esto lo que hara un rollback a la operacion que se esta realizando
            {
                if (!UsuarioExists(id))
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

        //POST api/usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.idUsuario }, usuario);

        }

        //Delete api Usuario
        [HttpDelete("idUsuaio")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el usuario no sienta que la app no funiona o si esta lento
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }
            //si hay informacion para eliminar entonces removemos de lo que venga de usuario
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                              //no aparazca mas en nuestra BD y en nuestro backend      

            return usuario;
        }
        // metodo para validar si ese usuario ya existe
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(usuario => usuario.idUsuario == id);
        }
    }
}
