using Core.Entities;
using Core.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public ProductosController(IUnitOfWork unitOfWork)
        {
         _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            var productos = await _unitOfWork.Productos.GetAllAsync();
            return Ok(productos);
                                
            
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id) // obtener un producto por su identificador 
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(Id); // este metodo permite buscar por id
            return Ok(producto); 
        }   

    }
}
