using System;
using System.Collections.Generic;

namespace DevReviews.API.Models
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(int id, string title, string description, decimal price, DateTime createdAt, List<ProductReviewViewModel> reviews)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            CreatedAt = createdAt;
            Reviews = reviews;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public List<ProductReviewViewModel> Reviews { get; private set; }
    }


    public class ProductReviewViewModel
    {
        public ProductReviewViewModel(int id, string author, int rating, string comments, DateTime createAt)
        {
            Id = id;
            Author = author;
            Rating = rating;
            Comments = comments;
            CreateAt = createAt;
        }

        public int Id { get; private set; }
        public string Author { get; private set; }
        public int Rating { get; private set; }
        public string Comments { get; private set; }
        public DateTime CreateAt { get; private set; }


    }
}
