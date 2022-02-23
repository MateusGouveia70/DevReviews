using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DevReviewsDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProductsController(DevReviewsDbContext dbcontext, IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
        }
        // GET api/productscontroller
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _dbContext.Products;

            //var productsViewModel = _dbContext.Products
            //    .Select(p => new ProductViewModel(p.Id, p.Title, p.Price))
            //    .ToList();

            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(productsViewModel);
        }

        // GET api/productscontroller/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // buscar na base, se não encontrar, 404 NotFound
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            //var reviews = product.Reviews
            //    .Select(r => new ProductReviewViewModel(r.Id, r.Author, r.Rating, r.Comments, r.CreateAt))
            //    .ToList();

            //var productDetails = new ProductDetailsViewModel(
            //    product.Id,
            //    product.Title,
            //    product.Description,
            //    product.Price,
            //    product.CreatedAt,
            //    reviews);

            var productDetails = _mapper.Map<ProductDetailsViewModel>(product);

            return Ok(productDetails);
        } 

        // POST api/productscontroller
        [HttpPost]
        public IActionResult Post(AddProductInputModel model)
        {
            // validar dados de entrada se não passar retornar 400 BadRequest
            var product = new Product(model.Title, model.Description, model.Price);
            _dbContext.Products.Add(product);

            return CreatedAtAction(nameof(GetById), new {id = model.Id }, model);
        }

        // PUT api/productscontroller/1
        [HttpPut("{productId}")]
        public IActionResult Put(int id, UpdateProductInputModel model)
        {
            // procurar na base, se não encontrar, 404 NotFound
            // validar dados de entrada, se não passar retornar 400 BadRequest
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null) return NotFound();

            product.UpdateProduct(model.Description, model.Price);
            return NoContent();
            
        }
        
        // DELETE api/productscontroller/1
        [HttpDelete("{productId}")]
        public IActionResult Delete(int id)
        {
            // procurar na base, se não encontrar, 404 NotFound
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product != null)
            {
                _dbContext.Products.Remove(product);
                return NoContent();
            }


            return NotFound(); 
        }
    }
}
