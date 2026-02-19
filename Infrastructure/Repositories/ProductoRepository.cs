using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(TiendaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Producto>> GetProductosMasCaros(int cantidad) =>
        
            await _context.Productos
                .OrderByDescending(p => p.Precio)
                .Take(cantidad)
                .ToListAsync();


        public override async Task<Producto> GetByIdAsync(int id) // añado un override por lo tanto tengo que cambiar el tipo de clase 
            //en mi genericrepository a public virtual async
        {
            return await _context.Productos
                .Include(p=> p.Marca)
                .Include(p=> p.Categoria)
                .FirstOrDefaultAsync(p=> p.Id == id);
        

        }
        public override async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos
                .Include(u => u.Marca)
                .Include(u => u.Categoria)
                .ToListAsync();
        }


    }

        
    }

