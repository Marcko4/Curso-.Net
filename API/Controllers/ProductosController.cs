using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.UnitOfWork;
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
        private readonly IMapper _mapper;

        public ProductosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
         _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoListDto>>> Get()
        {
            var productos = await _unitOfWork.Productos.GetAllAsync();
            return _mapper.Map<List<ProductoListDto>>(productos); //con automapper vas a traer un listado de productos
                                                                  //desde productolistdto          
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductoDto>> Get(int Id) // obtener un producto por su identificador 
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(Id); // este metodo permite buscar por id
            if (producto == null)
                return NotFound();

            return _mapper.Map<ProductoDto>(producto); // retorna mediante automapper, el mapeo de mi clase productodto
                                                       // y el producto que obtuve en la base de datos
        }

        [HttpPost]
        public async Task<ActionResult<ProductoAppUpdateDto>> Post (ProductoAppUpdateDto productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto); // mapeo de entidad producto a productodto
            _unitOfWork.Productos.Add(producto);

            await _unitOfWork.SaveAsync(); 
            if (producto == null)
            {
                return BadRequest();
            }
            productoDto.Id = producto.Id; // al nuevo producto le asigno el nuevo Id

            return CreatedAtAction(nameof(Post), new {id=productoDto.Id}, productoDto);
        }

        //[HttpPut("{Id}")]

        //public async Task <ActionResult<Producto>> Put (int Id,[FromBody] Producto producto)
        //{
        //    if (producto == null) // si el producto es nulo devuelve un 404
        //        return NotFound();

        //    _unitOfWork.Productos.Update(producto); // le paso el contexto unitofwork, busca el producto en la tabla producto y lo actualiza
        //    _unitOfWork.Save(); // guarda el cambio 
        //    return producto; // retorna el producto 
        //}




        //[HttpDelete ("{Id}")]

        //public async Task<IActionResult> Delete (int Id)
        //{
        //    var producto = await _unitOfWork.Productos.GetByIdAsync(Id); //declaro la variable producto, le paso el contexto de la unidad de trabajo
        //    //que busque en Productos (IRepositoryProductos
        //    if (producto ==null)                                            
        //        return NotFound();

        //    _unitOfWork.Productos.Remove(producto);
        //    _unitOfWork.Save();
        //    return NoContent();
        //}

    }
}
