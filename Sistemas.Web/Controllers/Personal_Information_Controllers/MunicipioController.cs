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
    public class MunicipioController : Controller
    {
        private readonly DBContextSistema _context;

        public MunicipioController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/ Muncipio, estamos traendo todo lo que contenga municipio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Municipio>>> GetMunicipio()
        {
            return await _context
                .Municipios.ToListAsync();
        }

        //Get api/para traer solomente un id o una solo municipio
        [HttpGet("{idMunicipio}")]
        public async Task<ActionResult<Municipio>> GetMunicipio(int id)
        {
            //variable municipio para el findAsync que pedira el id
            var municipio = await _context
                .Municipios.FindAsync(id);

            //si municipio retorna vacia
            if (municipio == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return municipio; // si encuentra retorna el valores
        }

        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/Municipio
        [HttpPut("idMunicipio")]
        public async Task<IActionResult> PutMunicipio(int id, Municipio municipio)
        {
            if (id != municipio.idMunicipio)
            {
                return BadRequest();// si es diferente no da un badrequest
            }

            _context.Entry(municipio)
                .State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en municipio 
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
                if (!MunicipioExists(id))
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

        //POST api/Municipio
        [HttpPost]
        public async Task<ActionResult<Municipio>> PostMunicipio(Municipio municipio)
        {
            _context.Municipios
                .Add(municipio);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetMunicipio", new { id = municipio.idMunicipio }, municipio);
        }

        //Delete api Municipio
        [HttpDelete("idMunicipio")]
        public async Task<ActionResult<Municipio>> DeleteMunicipio(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el municipio no sienta que la app no funiona o si esta lento
            var municipio = await _context
                .Municipios.FindAsync(id);

            if (municipio == null)
            {
                return NotFound();
            }

            //si hay informacion para eliminar entonces removemos de lo que venga de municipio
            _context.Municipios
                .Remove(municipio);

            await _context
                .SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                    //no aparazca mas en nuestra BD y en nuestro backend      

            return municipio;
        }

        // metodo para validar si ese municipio ya existe
        private bool MunicipioExists(int id)
        {
            return _context.Municipios
                .Any(municipio => municipio.idMunicipio == id);
        }
    }
}
