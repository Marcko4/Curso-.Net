using Core.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            });

        public static void AddAplicacionServices(this IServiceCollection services) // se añade nuevo metodo de extension
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped<IProductoRepository, ProductoRepository>();
            //services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            //services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}
