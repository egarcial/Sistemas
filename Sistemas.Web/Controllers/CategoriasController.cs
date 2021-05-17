using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas.Datos;
using Sistemas.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers
{
    /*router y api controller, router va se uso de una api y api se va 
     a los controladores y la api manejara la api controler*/
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly DBContextSistema _context;

        public CategoriasController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/Categorias, estamos traendo todo lo que contenga categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }
        //Get api/para traer solomente un id o una solo categoria 
        [HttpGet("{idCategoria}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            //variable categoria para el findAsync que pedira el id
            var categoria = await _context.Categorias.FindAsync(id);
            //si categoria retorna vacia

            if (categoria == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return categoria; // si encuentra retorna el valores
        }
        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/Categorias
        [HttpPut("idCategoria")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.idCategoria)
            {
                return BadRequest();// si es diferente no da un badrequest
            }
            _context.Entry(categoria).State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en categoria 
                                                                     vamos a realizar una modificacion , las entidad ya tiene las propiedades
                                                                       o informacion que vamos a guardar*/

            /*el manejo de erro try nos evitará  tener problemas a evitar que si hay error que la api no falle*/
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)//esto lo que hara un rollback a la operacion que se esta realizando
            {
                if (!CategoriaExists(id))
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

        //POST api/Categorias
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.idCategoria }, categoria);

        }

        //Delete api categoria
        [HttpDelete("idCategoria")]
        public async Task<ActionResult<Categoria>> DeleteCategoria(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el usuario no sienta que la app no funiona o si esta lento
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }
            //si hay informacion para eliminar entonces removemos de lo que venga de categorias
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                              //no aparazca mas en nuestra BD y en nuestro backend      

            return categoria;
        }
        // metodo para validar si esa categoria ya existe
        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.idCategoria == id);
        }
    }

}
