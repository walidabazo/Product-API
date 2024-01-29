using AutoMapper;
using Product.Core.Entities;
using Product.Infrastructure.Data;
using Product.Core;
using Product.API.MyHelper;
namespace Product.API.Models
{
    public class Mapping_Products : Profile
    {
        public Mapping_Products() {
            // CreateMap<ProductDto,Products>().ReverseMap();
            CreateMap<Products, ProductDto>()
                .ForMember(d => d.CategoryName, o=>o.MapFrom(s=>s.Category.Name))
                .ForMember(d=>d.ProductPicture, o=> o.MapFrom<ProductUrlResolver>())
                .ReverseMap();

            CreateMap<CreateProductDto,Products>().ReverseMap();
            CreateMap<Products,UpdateProductDto>() .ReverseMap();

        
       
       
        }
    }
}
