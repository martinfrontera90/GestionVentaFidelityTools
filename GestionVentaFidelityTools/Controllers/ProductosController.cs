using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionVentaFidelityTools.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVentaFidelityTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("permitir")]
    public class ProductosController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                using (Models.TestFidelityToolsContext db = new Models.TestFidelityToolsContext())
                {
                    var lista = (from a in db.Productos
                                 select a).ToList();
                    if (lista.Count == 0)
                        return NotFound();
                    else
                        return Ok(lista);
                }
            }
            catch
            {
                return BadRequest();
            }
         
        }

        [HttpGet]
        [Route("activo")]
        public IActionResult GetActiveProducts()
        {
            try
            {
                using (Models.TestFidelityToolsContext db = new Models.TestFidelityToolsContext())
                {
                    var lista = (from a in db.Productos
                                 where a.Estado==true
                                 select a).ToList();
                    if (lista.Count == 0)
                        return NotFound();
                    else
                        return Ok(lista);
                }
            }
            catch
            {
                return BadRequest();
            }

        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                using (Models.TestFidelityToolsContext db = new Models.TestFidelityToolsContext())
                {
                    Productos product = db.Productos.Find(id);

                    if (product != null)
                        return Ok(product);
                    else
                        return NotFound();

                }
            }
            catch
            {
                return BadRequest();
            }
           
        }

        [HttpGet ("getproductstrue")]
        public IActionResult GetStatusTrue()
        {
            try
            {

                using (Models.TestFidelityToolsContext db = new Models.TestFidelityToolsContext())
                {
                    var lista = (from a in db.Productos
                                 where a.Estado == true
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

        [HttpGet("getproductsfalse")]
        public IActionResult GetStatusFalse()
        {
            try
            {
                using (Models.TestFidelityToolsContext db = new Models.TestFidelityToolsContext())
                {
                    var lista = (from a in db.Productos
                                 where a.Estado == false
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

        [HttpPost]

        public IActionResult Create(Productos producto)
        {
            try
            {
                using (Models.TestFidelityToolsContext db = new TestFidelityToolsContext())
                {
                    db.Productos.Add(producto);
                    db.SaveChanges();

                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public IActionResult update(Productos productos)
        {
            try
            {
                using (Models.TestFidelityToolsContext db = new TestFidelityToolsContext())
                {
                    Productos producto = db.Productos.Find(productos.Id);
                    if (producto == null)
                        return NotFound();
                    else
                    {
                        producto.Nombre = productos.Nombre;
                        producto.Precio = productos.Precio;
                        producto.IdTipoProducto = productos.IdTipoProducto;
                        producto.Stock = productos.Stock;
                        producto.Estado = productos.Estado;
                        db.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("estado/{id}")]
        public int update(int id)
        {
            try
            {
                using (Models.TestFidelityToolsContext db = new TestFidelityToolsContext())
                {
                    Productos producto = db.Productos.Find(id);
                    if (producto == null)
                        return 0;
                    else
                    {
                        if (producto.Estado == true)
                            producto.Estado = false;
                        else
                            producto.Estado = true;
                        db.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        [HttpGet]
        [Route("disminuir/{id}/{stock}")]

        public IActionResult updateStock(int id, int stock)
        {
            using(Models.TestFidelityToolsContext db= new TestFidelityToolsContext())
            {
                try
                {
                    Productos product = db.Productos.Find(id);
                    product.Stock = product.Stock - stock;
                    db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
        }
    }
}