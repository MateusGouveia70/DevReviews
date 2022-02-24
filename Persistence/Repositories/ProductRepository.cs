using DevReviews.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevReviews.API.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DevReviewsDbContext _dbContext;
        public ProductRepository(DevReviewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await SaveChangesAync();
        }

        public async Task AddReviewAsync(ProductReview review)
        {
            await _dbContext.Reviews.AddAsync(review);
            await SaveChangesAync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductReview> GetReviewByIdAsync(int id)
        {
            return await _dbContext.Reviews.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await SaveChangesAync();
        }

        public async Task SaveChangesAync()
        {
            await _dbContext.SaveChangesAsync();
        }

       
    }
}
