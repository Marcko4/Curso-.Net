using API.Dtos;
using AutoMapper;
using Core.Entities;


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
                .ReverseMap();
        }



    }
}
