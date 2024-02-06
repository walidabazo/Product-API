using AutoMapper;
using Product.Core.Entities;
using Product.Infrastructure.Data;

namespace Product.API.Models
{
    //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

    public class MappingCategory: Profile
    {
        public MappingCategory() { 
        CreateMap<CategoryDto,Category>().ReverseMap();
            CreateMap<ListCategoryDto, Category>().ReverseMap();
        }
    }
}
