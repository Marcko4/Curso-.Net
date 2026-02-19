
using Core.Interfaces;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TiendaContext _context;

        private IProductoRepository _productos;
        private ICategoriaRepository _categorias;
        private IMarcaRepository _marcas;

        public UnitOfWork(TiendaContext context)
        {
            _context = context;

        }

        public ICategoriaRepository Categorias
        {
            get
            {
                if (_categorias == null)
                {
                    _categorias = new CategoriaRepository(_context);

                }
                return _categorias;

            }
        }

        public IMarcaRepository Marcas
        {
            get
            {
                if (_marcas == null)
                {
                    _marcas = new MarcaRepository(_context);

                }
                return _marcas;

            }
        }
        public IProductoRepository Productos
        {
            get
            {
                if (_productos == null)
                {
                    _productos = new ProductoRepository(_context);

                }
                return _productos;

            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
