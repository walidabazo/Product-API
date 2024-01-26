using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.Errors;
using Product.Infrastructure.Data;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BugController( ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFound() 
        {
            var product = _context.Products.Find(50);
            if(product is null) 
            {
                return NotFound(new BaseCommonResponse(404));
            }
            return Ok(product);
        }

        [HttpGet("Server-error")]
        public ActionResult GetServerError() 
        {
            var product = _context.Products.Find(100);
            product.Name = "";
            return Ok();
        }

        [HttpGet("Bad-Request/{id}")]
        public ActionResult GetNotFoundRequest() 
        
        {
        return Ok();
        }

        [HttpGet("Bad-Request")]
        public ActionResult GetBadRequest()

        {
            return BadRequest();
        }


    }
}
