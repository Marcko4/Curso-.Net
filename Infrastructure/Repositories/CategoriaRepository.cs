using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Repositories;

public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(TiendaContext context) : base(context)
    {

    }
}
