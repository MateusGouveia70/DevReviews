using DevReviews.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DevReviews.API.Persistence
{
    public class DevReviewsDbContext : DbContext
    {
        public DevReviewsDbContext(DbContextOptions<DevReviewsDbContext> options) : base(options)
        {
         
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("Tb_Product");
                p.HasKey(p => p.Id);

                p.HasMany(p => p.Reviews)
                .WithOne()
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductReview>(pr =>
            {
                pr.ToTable("tb_ProductReview");
                pr.HasKey(p => p.Id);

                pr.Property(pr => pr.Author)
                    .HasMaxLength(50)
                    .IsRequired();
                    //.HasColumnName("author");

            });
        }
    }
}
