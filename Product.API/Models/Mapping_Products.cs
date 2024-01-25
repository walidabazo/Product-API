using AutoMapper;
using Product.Core.Entities;
using Product.Infrastructure.Data;
using Product.Core;
namespace Product.API.Models
{
    public class Mapping_Products : Profile
    {
        public Mapping_Products() {
            // CreateMap<ProductDto,Products>().ReverseMap();
            CreateMap<Products, ProductDto>()
                .ForMember(d => d.CategoryName, o=>o.MapFrom(s=>s.Category.Name)).ReverseMap();
            CreateMap<CreateProductDto,Products>().ReverseMap();
        }
    }
}
