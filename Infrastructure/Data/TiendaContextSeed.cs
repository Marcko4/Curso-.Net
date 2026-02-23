using Core.Entities;
using CsvHelper;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Reflection;

namespace Infrastructure.Data;

public class TiendaContextSeed
{
    public static async Task SeedAsync(TiendaContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //lee el cotenido de el archivo marcas.csv y lo convierte a un listado de marca de tipo "entidad marca"
            if (!context.Marcas.Any())
            {

                using (var readerMarcas = new StreamReader(ruta + @"/Data/Csvs/marcas.csv"))
                {
                    using (var csvMarcas = new CsvReader(readerMarcas, CultureInfo.InvariantCulture))
                    {

                        var marcas = csvMarcas.GetRecords<Marca>();
                        context.Marcas.AddRange(marcas); // se agrega el listado de marcas
                        await context.SaveChangesAsync(); // se guarda los cambios 

                    }
                }

            }

            if (!context.Categorias.Any())
            {

                using (var readerCategorias = new StreamReader(ruta + @"/Data/Csvs/categorias.csv"))
                {
                    using (var csvCategorias = new CsvReader(readerCategorias, CultureInfo.InvariantCulture))
                    {

                        var categorias = csvCategorias.GetRecords<Categoria>();
                        context.Categorias.AddRange(categorias); // se agrega el listado de marcas
                        await context.SaveChangesAsync(); // se guarda los cambios 

                    }
                }

            }

            if (!context.Productos.Any())
            {

                using (var readerProductos = new StreamReader(ruta + @"/Data/Csvs/productos.csv"))
                {
                    using (var csvProductos = new CsvReader(readerProductos, CultureInfo.InvariantCulture))
                    {

                        var listadoProductoscvs = csvProductos.GetRecords<Producto>();

                        List<Producto> productos = new List<Producto>();

                        foreach (var item in listadoProductoscvs)
                        {

                            productos.Add(new Producto
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                Precio = item.Precio,
                                FechaCreacion = item.FechaCreacion,
                                CategoriaId = item.CategoriaId,
                                MarcaId = item.MarcaId,

                            });

                        }
                        context.Productos.AddRange(productos);// se agrega el listado de marcas
                        await context.SaveChangesAsync(); // se guarda los productos

                    }
                }

            }
        }

        catch (Exception ex)
        {

            var logger = loggerFactory.CreateLogger<TiendaContextSeed>();
            logger.LogError(ex.Message);
        }

    }

}
