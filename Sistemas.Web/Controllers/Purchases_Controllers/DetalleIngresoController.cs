using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas.Datos;
using Sistemas.Entidades.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Purchases_Controllers
{

    [Route("api/[controller]")]
    [ApiController]
   
        public class DetalleIngresoController : Controller
        {
        private readonly DBContextSistema _context;

        public DetalleIngresoController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/Detalle Ingreso, estamos traendo todo lo que contenga detalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleIngreso>>> GetDetalleIngreso()
        {
            return await _context.DetalleIngresos.ToListAsync();
        }
        //Get api/para traer solomente un id o una solo detalle
        [HttpGet("{idDetalleIngreso}")]
        public async Task<ActionResult<DetalleIngreso>> GetDetalleIngreso(int id)
        {
            //variable detIngreso para el findAsync que pedira el id
            var detIngreso = await _context.DetalleIngresos.FindAsync(id);
            //si Detalle ingreso retorna vacia

            if (detIngreso == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return detIngreso; // si encuentra retorna el valores
        }
        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/Detalle Ingreso
        [HttpPut("idDetalleIngreso")]
        public async Task<IActionResult> PutDetalleIngreso(int id, DetalleIngreso detIngreso)
        {
            if (id != detIngreso.idDetalleIngreso)
            {
                return BadRequest();// si es diferente no da un badrequest
            }
            _context.Entry(detIngreso).State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en detalle ingreso 
                                                                     vamos a realizar una modificacion , las entidad ya tiene las propiedades
                                                                       o informacion que vamos a guardar*/

            /*el manejo de erro try nos evitará  tener problemas a evitar que si hay error que la api no falle*/
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)//esto lo que hara un rollback a la operacion que se esta realizando
            {
                if (!DetalleIngresoExists(id))
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

        //POST api/Detalle Ingreso
        [HttpPost]
        public async Task<ActionResult<DetalleIngreso>> PostDetalleIngreso(DetalleIngreso detIngreso)
        {
            _context.DetalleIngresos.Add(detIngreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleIngreso", new { id = detIngreso.idDetalleIngreso }, detIngreso);

        }

        //Delete api Detalle Ingreso
        [HttpDelete("idDetalleIngreso")]
        public async Task<ActionResult<DetalleIngreso>> DeleteDetalleIngreso(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el detalle ingreso no sienta que la app no funiona o si esta lento
            var detIngreso = await _context.DetalleIngresos.FindAsync(id);

            if (detIngreso == null)
            {
                return NotFound();
            }
            //si hay informacion para eliminar entonces removemos de lo que venga de detalle ingreso
            _context.DetalleIngresos.Remove(detIngreso);
            await _context.SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                              //no aparazca mas en nuestra BD y en nuestro backend      

            return detIngreso;
        }
        // metodo para validar si ese detalle ingreso ya existe
        private bool DetalleIngresoExists(int id)
        {
            return _context.DetalleIngresos.Any(detIngreso => detIngreso.idDetalleIngreso == id);
        }
    }
}
