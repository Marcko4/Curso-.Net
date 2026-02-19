using API.Dtos;
using AutoMapper;
using Core.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        //mapeos entre las clases entidades y las clases Dtos
        public MappingProfiles()
        {
            CreateMap<Producto, ProductoDto>()
                .ReverseMap(); // es lo mismo que decir, ProductoDto a Producto

            CreateMap<Categoria, CategoriaDto>()
                .ReverseMap();  

            CreateMap<Marca, MarcaDto>() 
                .ReverseMap();

            CreateMap<Producto, ProductoListDto>()
                .ForMember(dest => dest.Marca, origen => origen.MapFrom(origen => origen.Marca.Nombre))

                // “Cuando conviertas Producto a ProductoDto,
                //en la propiedad Marca del DTO pon el Nombre de la Marca del Producto”.

                .ForMember(dest => dest.Categoria, origen => origen.MapFrom(origen => origen.Categoria.Nombre))
                .ReverseMap()

                // “Cuando conviertas Producto a ProductoDto,
                //en la propiedad Categoria del DTO pon el Nombre de la Categoria del Producto”.


                .ForMember(origen => origen.Categoria, dest => dest.Ignore())
                .ForMember(origen => origen.Marca, dest => dest.Ignore());
            // esto evita la inicializacion de estas dos entidades
            // por que no hay de pasar de productolistdto a categoria ni a marca
            // esto evita que EF manda errores a la hora de agregar un nuevo elemento.

            CreateMap<Producto, ProductoAppUpdateDto>()            
                .ReverseMap()

                .ForMember(origen => origen.Categoria, dest => dest.Ignore())
                .ForMember(origen => origen.Marca, dest => dest.Ignore());

        }



    }
}
