using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
	public class DiscountContext : DbContext
	{
		public DbSet<Coupon> Coupons { get; set; } = default!;
		public DiscountContext(DbContextOptions<DiscountContext> options) 
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Coupon>().HasData(
					new Coupon 
					{	
						Id = 1 ,
						ProductName = "Apple MacBook Air",
						Description = "Special discount on the sleek Apple MacBook Air, featuring a Retina display and M1 chip. Don’t miss this chance to save!",
						Amount = 150
					},
					new Coupon 
					{ 
						Id = 2 ,
						ProductName = "Samsung Galaxy S21",
						Description = "Grab the Samsung Galaxy S21 at a discounted price! Enjoy top-tier features and performance while saving money.",
						Amount = 100
					},
					new Coupon 
					{ 
						Id = 3 ,
						ProductName = "LG UltraGear 27GN950-B",
						Description = "Take advantage of this discount on the LG UltraGear 27GN950-B, a premium 4K gaming monitor. Elevate your setup for less!",
						Amount = 120
					},
					new Coupon 
					{ 
						Id = 4 ,
						ProductName = "Sony WH-1000XM4",
						Description = "Get the Sony WH-1000XM4 headphones at a special discount! Experience unmatched sound quality and noise cancellation.",
						Amount = 70
					}
				);
		}
	}
}
