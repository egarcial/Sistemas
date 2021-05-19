using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas.Datos;
using Sistemas.Entidades.Personal_Information;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Personal_Information_Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly DBContextSistema _context;

        public DepartamentoController(DBContextSistema context)
        {
            _context = context;
        }

        //GET api/ Departamento, estamos traendo todo lo que contenga departamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamento()
        {
            return await _context
                .Departamentos.ToListAsync();
        }

        //Get api/para traer solomente un id o una solo departamento
        [HttpGet("{idDepatamento}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            //variable departmento para el findAsync que pedira el id
            var departamento = await _context
                .Departamentos.FindAsync(id);

            //si departamento retorna vacia
            if (departamento == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return departamento; // si encuentra retorna el valores
        }

        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/departamentp
        [HttpPut("idDepartamento")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.idDepatamento)
            {
                return BadRequest();// si es diferente no da un badrequest
            }

            _context.Entry(departamento)
                .State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en departamento 
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
                if (!DepartamentoExists(id))
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

        //POST api/Departamento
        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            _context.Departamentos
                .Add(departamento);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetDepartamento", new { id = departamento.idDepatamento }, departamento);
        }

        //Delete api Departamento
        [HttpDelete("idDepartamento")]
        public async Task<ActionResult<Departamento>> DeleteDepartamento(int id)
        {
            //await es una funcion que permite esperar a la peticion en la web
            //que este responda para que el departamento no sienta que la app no funiona o si esta lento
            var departamento = await _context
                .Departamentos.FindAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            //si hay informacion para eliminar entonces removemos de lo que venga de departmnto
            _context.Departamentos
                .Remove(departamento);

            await _context
                .SaveChangesAsync();//await nos traera a context que dara una update para que ya
                                    //no aparazca mas en nuestra BD y en nuestro backend      

            return departamento;
        }

        // metodo para validar si ese departamento ya existe
        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos
                .Any(departamento => departamento.idDepatamento == id);
        }
    }
}
