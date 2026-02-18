
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id); // obtiene una entidad por identificador
        Task<IEnumerable<T>> GetAllAsync(); // obtiene todos los recursos
        IEnumerable<T> Find(Expression<Func<T, bool>> expression); // regresa un conjunto de registros
                                                                   // dependiendo de la expresion LINQ que se utilice 
        void Add(T entity); // agrega un elemento al contexto
        void AddRange(IEnumerable<T> entities); //agrega una lista de entidades al contexto
        void Update(T entity); // actualiza una entidad al contexto
        void Remove(T entity); // elimina un registro al contexto
        void RemoveRange(IEnumerable<T> entities); // elimina una lista de entidades al contexto
    }

}
