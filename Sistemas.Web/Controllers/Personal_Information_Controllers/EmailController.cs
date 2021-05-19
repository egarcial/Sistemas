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
    public class EmailController : Controller
    {
        private readonly DBContextSistema _context;

        public EmailController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/email, estamos traendo todo lo que contenga email
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmail()
        {
            return await _context
                .Emails.ToListAsync();
        }

        //Get api/para traer solomente un id o una solo email
        [HttpGet("{idEmail}")]
        public async Task<ActionResult<Email>> GetEmail(int id)
        {
            //variable email para el findAsync que pedira el id
            var email = await _context
                .Emails.FindAsync(id);

            //si email retorna vacia
            if (email == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return email; // si encuentra retorna el valores
        }

        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/email
        [HttpPut("idEmail")]
        public async Task<IActionResult> PutEmail(int id, Email email)
        {
            if (id != email.idEmail)
            {
                return BadRequest();// si es diferente no da un badrequest
            }

            _context.Entry(email)
                .State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en email 
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
                if (!EmailExists(id))
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

        //POST api/email
        [HttpPost]
        public async Task<ActionResult<Email>> PostEmail(Email email)
        {
            _context.Emails
                .Add(email);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetEmail", new { id = email.idEmail }, email);
        }

        //Delete api email
        [HttpDelete("idEmail")]
        public async Task<ActionResult<Email>> DeleteEmail(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el email no sienta que la app no funiona o si esta lento
            var email = await _context
                .Emails.FindAsync(id);

            if (email == null)
            {
                return NotFound();
            }

            //si hay informacion para eliminar entonces removemos de lo que venga de perrte de email
            _context.Emails
                .Remove(email);

            await _context
                .SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                    //no aparazca mas en nuestra BD y en nuestro backend      

            return email;
        }

        // metodo para validar si ese email ya existe
        private bool EmailExists(int id)
        {
            return _context.Emails
                .Any(email => email.idEmail== id);
        }
    }
}
