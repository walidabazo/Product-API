using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Core.Entities;
using Product.Core.Interface;
using Product.Infrastructure.Data;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork uow, IMapper mapper)
        { 
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet("get-all-products")]
        public async Task<ActionResult> get()
        { 
        var res = await _uow.ProductRepository.GetAllAsync(x => x.Category);
            var result = _mapper.Map<List<ProductDto>>(res);

            return Ok(result);
        }

        [HttpGet("get-product-by-id/{id}")]
        public async Task<ActionResult> get(int id)
        { 
       var res = await _uow.ProductRepository.GetByidAsync(id,x => x.Category);
       var result =_mapper.Map<ProductDto>(res);
       return Ok(result);
        }
        [HttpPost("add-new-product")]
        public async Task<ActionResult> post(CreateProductDto createProductDto)
        { 
        try
            {
                if(ModelState.IsValid) 
                {
                     var res = _mapper.Map<Products>(createProductDto);
                      await _uow.ProductRepository.AddAsync(createProductDto);
                    return Ok(res);
                }
                return BadRequest(createProductDto);

            }
        catch(Exception ex) 
            { 
            return BadRequest(ex.Message);
            }
        }
    }
}
