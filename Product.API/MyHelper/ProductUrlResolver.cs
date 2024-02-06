using AutoMapper;
using AutoMapper.Execution;
using Product.Core.Entities;
using Product.Infrastructure.Data;

namespace Product.API.MyHelper
{
    public class ProductUrlResolver : IValueResolver<Products, ProductDto, string>
    {
        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

        private readonly IConfiguration _configuration;
        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration= configuration;
        }
        public string Resolve(Products source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ProductPicture))
            {
            return _configuration["API_url"]+source.ProductPicture;
            }
            return null;
        }
    }
}
