using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence;
using DevReviews.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET api/productscontroller
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();

            //var productsViewModel = _dbContext.Products
            //    .Select(p => new ProductViewModel(p.Id, p.Title, p.Price))
            //    .ToList();

            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(productsViewModel);
        }

        // GET api/productscontroller/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repository.GetByIdAsync(id);
                

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
        public async Task<IActionResult> Post(AddProductInputModel model)
        {
            var product = new Product(model.Title, model.Description, model.Price);

            await _repository.AddAsync(product);
           
            return CreatedAtAction(nameof(GetById), new {id = product.Id }, model);
        }

        // PUT api/productscontroller/1
        [HttpPut()]
        public async Task<IActionResult> Put(int id, UpdateProductInputModel model)
        {

            var product = await _repository.GetByIdAsync(id);

            if (product == null) return NotFound();

            product.UpdateProduct(model.Description, model.Price);

            await _repository.UpdateAsync(product);

            //_dbContext.Products.Update(product); neste caso não precisa pôs o objeto já está sendo rastreado pelo contexto de dados
            //_dbContext.Entry(product).State = EntityState.Modified;

            return NoContent();
            
        }
    }
}
