namespace Core.Interfaces;

public interface IUnitOfWork
{

    //esta clase contiene los siguientes repositorios 
    IProductoRepository Productos {  get; }
    IMarcaRepository Marcas { get; }
    ICategoriaRepository Categorias { get; }
    // metodo save para guardar
    Task <int> SaveAsync();

}
