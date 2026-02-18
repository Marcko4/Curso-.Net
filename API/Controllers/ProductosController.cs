using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : BaseApiController
    {
        private readonly TiendaContext _context;

        public ProductosController(TiendaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
        {
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id) // obtener un producto por su identificador 
        {
            var producto = await _context.Productos.FindAsync(Id); // este metodo permite buscar por id
            return Ok(producto);
        }   

    }
}
