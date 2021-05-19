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
    public class DocumentoController : Controller
    {
        private readonly DBContextSistema _context;

        public DocumentoController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/Documento, estamos traendo todo lo que contenga docs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documento>>> GetDocumento()
        {
            return await _context
                .Documentos.ToListAsync();
        }

        //Get api/para traer solomente un id o una solo documento
        [HttpGet("{idTipoDocumento}")]
        public async Task<ActionResult<Documento>> GetDocumento(int id)
        {
            //variable documento para el findAsync que pedira el id
            var doc = await _context
                .Documentos.FindAsync(id);

            //si documento retorna vacia
            if (doc == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return doc; // si encuentra retorna el valores
        }

        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/documento
        [HttpPut("idTipoDocumento")]
        public async Task<IActionResult> PutDocumento(int id, Documento documento)
        {
            if (id != documento.idTipoDocumento)
            {
                return BadRequest();// si es diferente no da un badrequest
            }

            _context.Entry(documento)
                .State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en documento 
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
                if (!DocumentoExists(id))
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

        //POST api/documento
        [HttpPost]
        public async Task<ActionResult<Documento>> PostDocumento(Documento documento)
        {
            _context.Documentos
                .Add(documento);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetDocumento", new { id = documento.idTipoDocumento }, documento);
        }

        //Delete api documento
        [HttpDelete("idTipoDocumento")]
        public async Task<ActionResult<Documento>> DeleteDocumento(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el documento no sienta que la app no funiona o si esta lento
            var doc = await _context
                .Documentos.FindAsync(id);

            if (doc == null)
            {
                return NotFound();
            }

            //si hay informacion para eliminar entonces removemos de lo que venga de documento
            _context.Documentos
                .Remove(doc);

            await _context
                .SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                    //no aparazca mas en nuestra BD y en nuestro backend      

            return doc;
        }

        // metodo para validar si ese documento ya existe
        private bool DocumentoExists(int id)
        {
            return _context.Documentos
                .Any(documento => documento.idTipoDocumento == id);
        }
    }
}
