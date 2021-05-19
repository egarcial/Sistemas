using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas.Datos;
using Sistemas.Entidades.Purchases;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Purchases_Controllers
{
    public class IngresoController : Controller
    {
        private readonly DBContextSistema _context;

        public IngresoController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/ingreso, estamos traendo todo lo que contenga ingreso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingreso>>> GetIngreso()
        {
            return await _context.Ingresos.ToListAsync();
        }
        //Get api/para traer solomente un id o una solo ingreso
        [HttpGet("{idIngreso}")]
        public async Task<ActionResult<Ingreso>> GetIngreso(int id)
        {
            //variable ingreso para el findAsync que pedira el id
            var ingreso = await _context.Ingresos.FindAsync(id);
            //si ingreso retorna vacia

            if (ingreso == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return ingreso; // si encuentra retorna el valores
        }
        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/Ingreso
        [HttpPut("idIngreso")]
        public async Task<IActionResult> PutIngreso(int id, Ingreso ingreso)
        {
            if (id != ingreso.idIngreso)
            {
                return BadRequest();// si es diferente no da un badrequest
            }
            _context.Entry(ingreso).State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en ingreso 
                                                                     vamos a realizar una modificacion , las entidad ya tiene las propiedades
                                                                       o informacion que vamos a guardar*/

            /*el manejo de erro try nos evitará  tener problemas a evitar que si hay error que la api no falle*/
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)//esto lo que hara un rollback a la operacion que se esta realizando
            {
                if (!IngresoExists(id))
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

        //POST api/Ingreso
        [HttpPost]
        public async Task<ActionResult<Ingreso>> PostIngreso(Ingreso ingreso)
        {
            _context.Ingresos.Add(ingreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngreso", new { id = ingreso.idIngreso }, ingreso);

        }

        //Delete api Ingreso
        [HttpDelete("idIngreso")]
        public async Task<ActionResult<Ingreso>> DeleteIngreso(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el ingreso no sienta que la app no funiona o si esta lento
            var ingreso = await _context.Ingresos.FindAsync(id);

            if (ingreso == null)
            {
                return NotFound();
            }
            //si hay informacion para eliminar entonces removemos de lo que venga de ingreso
            _context.Ingresos.Remove(ingreso);
            await _context.SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                              //no aparazca mas en nuestra BD y en nuestro backend      

            return ingreso;
        }
        // metodo para validar si ese ingreso ya existe
        private bool IngresoExists(int id)
        {
            return _context.Ingresos.Any(ingreso => ingreso.idIngreso == id);
        }
    }
}
