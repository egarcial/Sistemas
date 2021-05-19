using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas.Datos;
using Sistemas.Entidades.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Documents_Controllers
{
    public class ComprobantesController : Controller
    {
        private readonly DBContextSistema _context;

        public ComprobantesController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/comprbante, estamos traendo todo lo que contenga comprobante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comprobante>>> GetComprobante()
        {
            return await _context
                .Comprobante.ToListAsync();
        }

        //Get api/para traer solomente un id o una solo comprobante
        [HttpGet("{idTipoComprobante}")]
        public async Task<ActionResult<Comprobante>> GetComprobante(int id)
        {
            //variable comprobante para el findAsync que pedira el id
            var comprobante = await _context
                .Comprobante.FindAsync(id);

            //si comprobante retorna vacia
            if (comprobante == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return comprobante; // si encuentra retorna el valores
        }

        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/comprobante
        [HttpPut("idTipoComprobante")]
        public async Task<IActionResult> PutComprobante(int id, Comprobante comprobante)
        {
            if (id != comprobante.idTipoComprobante)
            {
                return BadRequest();// si es diferente no da un badrequest
            }

            _context.Entry(comprobante)
                .State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en comprobante 
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
                if (!ComprobanteExists(id))
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

        //POST api/comprobante
        [HttpPost]
        public async Task<ActionResult<Comprobante>> PostCoprobante(Comprobante comprobante)
        {
            _context.Comprobante
                .Add(comprobante);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetComprobante", new { id = comprobante.idTipoComprobante }, comprobante);
        }

        //Delete api comprobante
        [HttpDelete("idTipoComprobante")]
        public async Task<ActionResult<Comprobante>> DeleteComprobante(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el comprobante no sienta que la app no funiona o si esta lento
            var comprobante = await _context
                .Comprobante.FindAsync(id);

            if (comprobante == null)
            {
                return NotFound();
            }

            //si hay informacion para eliminar entonces removemos de lo que venga de comprobante
            _context.Comprobante
                .Remove(comprobante);

            await _context
                .SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                    //no aparazca mas en nuestra BD y en nuestro backend      

            return comprobante;
        }

        // metodo para validar si ese comprobante ya existe
        private bool ComprobanteExists(int id)
        {
            return _context.Comprobante
                .Any(comprobante => comprobante.idTipoComprobante == id);
        }
    }
}
