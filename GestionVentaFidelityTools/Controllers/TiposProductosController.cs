using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVentaFidelityTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("permitir")]
    public class TiposProductosController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                using (Models.TestFidelityToolsContext db = new Models.TestFidelityToolsContext())
                {
                    var lista = (from a in db.TiposProductos
                                 select a).ToList();

                    if (lista.Count != 0)
                        return Ok(lista);
                    else
                        return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetDescription(int id)
        {
            try
            {
                using (Models.TestFidelityToolsContext db = new Models.TestFidelityToolsContext())
                {
                    var lista = (from a in db.TiposProductos
                                 where a.Id==id
                                 select a).ToList();

                    if (lista.Count != 0)
                        return Ok(lista);
                    else
                        return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("nombre/{nombre}")]
        public IActionResult GetId(string nombre)
        {
            try
            {
                using (Models.TestFidelityToolsContext db = new Models.TestFidelityToolsContext())
                {
                    var lista = (from a in db.TiposProductos
                                 where a.Nombre == nombre
                                 select a).ToList();

                    if (lista.Count != 0)
                        return Ok(lista);
                        
                    else
                        return NotFound();
                       
                }
            }
            catch
            {
                return BadRequest();
               
            }
        }

    }
}