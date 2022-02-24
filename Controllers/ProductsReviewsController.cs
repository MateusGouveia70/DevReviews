using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence;
using DevReviews.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/product/{productId}/[controller]")]
    public class ProductsReviewsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductsReviewsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/product/1/productsreviews/6
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productReview = await _repository.GetReviewByIdAsync(id);
                

            if (productReview == null) return NotFound();

            var productDetails = _mapper.Map<ProductReviewDetailsViewModel>(productReview);
            
            return Ok(productDetails);
        }

        //Post api/product/1/productreviews
        [HttpPost]
        public async Task<IActionResult> Post(int productId, AddProductReviewInputModel model)
        {
            var productReview = new ProductReview(model.Author, model.Rating, model.Comments, productId);

            await _repository.AddReviewAsync(productReview);

            return CreatedAtAction(nameof(GetById), new {id = productReview.Id, productId = productId}, model);

        }

    }
}
