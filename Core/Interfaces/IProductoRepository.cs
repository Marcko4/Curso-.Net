using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
       Task <IEnumerable<Producto>> GetProductosMasCaros(int cantidad);
    }
}
