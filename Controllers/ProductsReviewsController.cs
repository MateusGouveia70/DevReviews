using DevReviews.API.Models;
using DevReviews.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/product/{productId}/[controller]")]
    public class ProductsReviewsController : ControllerBase
    {
        private readonly DevReviewsDbContext _dbContext;
        public ProductsReviewsController(DevReviewsDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        // GET api/product/1/productsreviews/6
        [HttpGet("{id}")]
        public IActionResult GetById(int productId, int id)
        {
            // procurar na base, se não encontrar, 404 NotFound
            return Ok();
        }

        //Post api/product/1/productreviews
        [HttpPost]
        public IActionResult Post(int productId, AddProductReviewInputModel model)
        {
            // procurar na base, se não encontrar, 404 NotFound
            // validar dados de entrada, se não passar retornar 400 BadRequest
            return CreatedAtAction(nameof(GetById), new {id = model.Id, productId = productId}, model);

        }

    }
}
