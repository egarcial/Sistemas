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
    public class VentasController : Controller
    {

        private readonly DBContextSistema _context;

        public VentasController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/Venta, estamos traendo todo lo que contenga venta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> GetVenta()
        {
            return await _context.Vts.ToListAsync();
        }
        //Get api/para traer solomente un id o una solo venta
        [HttpGet("{idVenta}")]
        public async Task<ActionResult<Ventas>> GetVenta(int id)
        {
            //variable venta para el findAsync que pedira el id
            var venta = await _context.Vts.FindAsync(id);
            //si venta retorna vacia

            if (venta == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return venta; // si encuentra retorna el valores
        }
        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/Venta
        [HttpPut("idVenta")]
        public async Task<IActionResult> PutVenta(int id, Ventas venta)
        {
            if (id != venta.idVenta)
            {
                return BadRequest();// si es diferente no da un badrequest
            }
            _context.Entry(venta).State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en venta 
                                                                     vamos a realizar una modificacion , las entidad ya tiene las propiedades
                                                                       o informacion que vamos a guardar*/

            /*el manejo de erro try nos evitará  tener problemas a evitar que si hay error que la api no falle*/
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)//esto lo que hara un rollback a la operacion que se esta realizando
            {
                if (!VentaExists(id))
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

        //POST api/venta
        [HttpPost]
        public async Task<ActionResult<Ventas>> PostVenta(Ventas venta)
        {
            _context.Vts.Add(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenta", new { id = venta.idVenta }, venta);

        }

        //Delete api Venta
        [HttpDelete("idVenta")]
        public async Task<ActionResult<Ventas>> DeleteVenta(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el venta no sienta que la app no funiona o si esta lento
            var venta = await _context.Vts.FindAsync(id);

            if (venta == null)
            {
                return NotFound();
            }
            //si hay informacion para eliminar entonces removemos de lo que venga de venta
            _context.Vts.Remove(venta);
            await _context.SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                              //no aparazca mas en nuestra BD y en nuestro backend      

            return venta;
        }
        // metodo para validar si ese venta ya existe
        private bool VentaExists(int id)
        {
            return _context.Vts.Any(venta => venta.idVenta == id);
        }
    }
}
