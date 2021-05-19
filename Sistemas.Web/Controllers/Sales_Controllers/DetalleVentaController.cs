using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas.Datos;
using Sistemas.Entidades.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Sales_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : Controller
    {
        private readonly DBContextSistema _context;

        public DetalleVentaController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/Detalle venta, estamos traendo todo lo que contenga detalle de venta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleVenta>>> GetDetalleVenta()
        {
            return await _context.DetalleVentas.ToListAsync();
        }
        //Get api/para traer solomente un id o una solo detalla de venta
        [HttpGet("{idDetalleVenta}")]
        public async Task<ActionResult<DetalleVenta>> GetDetalleVenta(int id)
        {
            //variable detventa para el findAsync que pedira el id
            var detVenta = await _context.DetalleVentas.FindAsync(id);
            //si detalle venta retorna vacia

            if (detVenta == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return detVenta; // si encuentra retorna el valores
        }
        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/Detalle venta
        [HttpPut("idDetalleVenta")]
        public async Task<IActionResult> PutDetalleVenta(int id, DetalleVenta detVenta)
        {
            if (id != detVenta.idDetalleVenta)
            {
                return BadRequest();// si es diferente no da un badrequest
            }
            _context.Entry(detVenta).State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en detalle venta 
                                                                     vamos a realizar una modificacion , las entidad ya tiene las propiedades
                                                                       o informacion que vamos a guardar*/

            /*el manejo de erro try nos evitará  tener problemas a evitar que si hay error que la api no falle*/
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)//esto lo que hara un rollback a la operacion que se esta realizando
            {
                if (!DetalleVentaExists(id))
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

        //POST api/Detalle Venta
        [HttpPost]
        public async Task<ActionResult<DetalleVenta>> PostDetalleVenta(DetalleVenta detVenta)
        {
            _context.DetalleVentas.Add(detVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleVenta", new { id = detVenta.idDetalleVenta }, detVenta);

        }

        //Delete api Detalle venta
        [HttpDelete("idDetalleVenta")]
        public async Task<ActionResult<DetalleVenta>> DeleteDetalleVenta(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el detalle venta no sienta que la app no funiona o si esta lento
            var detVenta = await _context.DetalleVentas.FindAsync(id);

            if (detVenta == null)
            {
                return NotFound();
            }
            //si hay informacion para eliminar entonces removemos de lo que venga de detalle venta
            _context.DetalleVentas.Remove(detVenta);
            await _context.SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                              //no aparazca mas en nuestra BD y en nuestro backend      

            return detVenta;
        }
        // metodo para validar si ese detalle venta ya existe
        private bool DetalleVentaExists(int id)
        {
            return _context.DetalleVentas.Any(detVenta => detVenta.idDetalleVenta == id);
        }
    }
}
