using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Repositories;

public class MarcaRepository : GenericRepository<Marca>, IMarcaRepository
{
       public MarcaRepository(TiendaContext context) : base(context)
    {

    }
}
