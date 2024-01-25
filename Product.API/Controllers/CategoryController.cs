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
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork Uow, IMapper mapper)
        {
            _uow = Uow;
            _mapper= mapper;

        }
        [HttpGet("get-all-category")]
        public async Task<ActionResult> Get()
        {
            var all_category = await _uow.CategoryRepository.GetAllAsync();
            if (all_category != null)
            {
                //var res = all_category.Select(x => new CategoryDto
                //{
                //    id = x.Id,
                //    Name = x.Name,
                //    Description = x.Description,
                //}
                //);
              var res= _mapper.Map< IReadOnlyList<Category>, IReadOnlyList<ListCategoryDto>>(all_category);
                return Ok(res);
            }
               
            return BadRequest("Not Found");
        }
    
        [HttpGet("get-category-by-id/{id}")]
        public async Task<ActionResult> Get(int id)
        { 
        var category = await _uow.CategoryRepository.GetAsync(id);
            if (category == null)
                return BadRequest($"Not found this id = [{id}]");
            //   return Ok(category);
            return Ok(_mapper.Map<Category,ListCategoryDto>(category));
        }

        [HttpPost("add-new-category")]
        public async Task<ActionResult> post(CategoryDto categoryDto  )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = _mapper.Map<Category>(categoryDto);
                    //var new_category = new Category
                    //{
                    //    Name = categoryDto.Name,
                    //    Description = categoryDto.Description
                    //};
                    await _uow.CategoryRepository.AddAsync(res);
                    return Ok(res);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPut("update-exiting-category-by-id/{id}")]
        public async Task<ActionResult> put(int id, CategoryDto categoryDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var exiting_category = await _uow.CategoryRepository.GetAsync(id);
                    if (exiting_category != null)
                    {
                        //exiting_category.Name = categoryDto.Name;
                        //exiting_category.Description = categoryDto.Description;
                        _mapper.Map(categoryDto, exiting_category);
                    }
                    await _uow.CategoryRepository.UpdateAsync(id, exiting_category);
                    return Ok(exiting_category);
                }
                return BadRequest($"Category id [{id}] Not Found");
            }
            catch (Exception ex) 
            {
            return BadRequest(ex.Message ); 
            }



        }


        [HttpDelete("delete-category-by-id/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var exiting_category = await _uow.CategoryRepository.GetAsync(id);
                if (exiting_category != null)
                {
                    await _uow.CategoryRepository.DeleteAsync(id);
                    return Ok($"This Category [{exiting_category.Name}] Is deleted ");
                }
                return BadRequest($"This Category [{exiting_category.Id}] Not Found");
            }
            catch (Exception ex) {
            return BadRequest(ex.Message );
            }
            
        }
    
    }
}
