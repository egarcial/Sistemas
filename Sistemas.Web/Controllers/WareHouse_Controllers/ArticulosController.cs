using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas.Datos;
using Sistemas.Entidades.WareHouse;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.WareHouse_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : Controller
    {
        private readonly DBContextSistema _context;

        public ArticulosController(DBContextSistema context)
        {
            _context = context;
        }


        //GET api/Articulo, estamos traendo todo lo que contenga articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulo()
        {
            return await _context
                .Articulos.ToListAsync();
        }


        //Get api/para traer solomente un id o una solo articulo
        [HttpGet("{idArticulo}")]
        public async Task<ActionResult<Articulo>> GetArticulo(int id)
        {
            //variable articulo para el findAsync que pedira el id
            var articulo = await _context
                .Articulos.FindAsync(id);

            //si articulo retorna vacia

            if (articulo == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return articulo; // si encuentra retorna el valores
        }


        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/Articulo
        [HttpPut("idArticulo")]
        public async Task<IActionResult> PutArticulo(int id, Articulo articulo)
        {
            if (id != articulo.idArticulo)
            {
                return BadRequest();// si es diferente no da un badrequest
            }

            _context.Entry(articulo)
                .State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en categoria 
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
                if (!ArticuloExists(id))
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


        //POST api/Articulo
        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {
            _context.Articulos
                .Add(articulo);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.idArticulo }, articulo);

        }


        //Delete api Articulo
        [HttpDelete("idArticulo")]
        public async Task<ActionResult<Articulo>> DeleteArticulo(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el usuario no sienta que la app no funiona o si esta lento
            var articulo = await _context
                .Articulos.FindAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            //si hay informacion para eliminar entonces removemos de lo que venga de articulo
            _context.Articulos
                .Remove(articulo);

            await _context
                .SaveChangesAsync();/*await nos traera a context que dara una update para que ya
                                     no aparazca mas en nuestra BD y en nuestro backend  */    

            return articulo;
        }


        // metodo para validar si esa articulo ya existe
        private bool ArticuloExists(int id)
        {
            return _context
                .Articulos.Any(articulo => articulo.idArticulo == id);
        }
    }
}
