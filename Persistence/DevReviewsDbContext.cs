using DevReviews.API.Entities;
using System.Collections.Generic;

namespace DevReviews.API.Persistence
{
    public class DevReviewsDbContext
    {
        public DevReviewsDbContext()
        {
            Products = new List<Product>();


            Reviews = new List<ProductReview>();
        }


        public List<Product> Products { get; set; }
        public List<ProductReview> Reviews { get; set; }
    }
}
