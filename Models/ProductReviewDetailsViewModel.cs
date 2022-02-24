using System;

namespace DevReviews.API.Models
{
    public class ProductReviewDetailsViewModel
    {
        // Não precisa de construtor pôs iremos usar autoMapper
        public int Id { get; private set; }
        public string Author { get; private set; }
        public int Rating { get; private set; }
        public string Comments { get; private set; }
        public DateTime CreateAt { get; private set; }

    }
}
