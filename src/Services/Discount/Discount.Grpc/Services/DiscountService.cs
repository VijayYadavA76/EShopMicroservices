using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
	public class DiscountService
		(DiscountContext dbContext,ILogger<DiscountService> logger)
		: Discount.DiscountBase
	{
		public override async Task<DiscountReply> GetDiscount(GetDiscountRequest request, ServerCallContext context)
		{
			var coupon = await dbContext.Coupons
				.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
			if(coupon is null)
			{
				coupon = new Coupon
				{
					ProductName = string.IsNullOrEmpty(request.ProductName) ? "No Product Selected" : request.ProductName,
					Amount = 0,
					Description = "No Discount Available"
				};
			}
			logger.LogInformation("Discount is recevied for Product: {productName}, Amount: {amount}",coupon.ProductName,coupon.Amount);
			var discoutReply = coupon.Adapt<DiscountReply>();
			return discoutReply;
		}
		public async override Task<DiscountReply> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
		{
			var coupon = request.Coupon.Adapt<Coupon>() ??
				throw new RpcException(new Status(StatusCode.InvalidArgument,"Invalid request object."));
			dbContext.Coupons.Add(coupon);
			await dbContext.SaveChangesAsync();
			logger.LogInformation("Discount is successfully created. ProductName : {ProductName}", coupon.ProductName);

			var discountReply = coupon.Adapt<DiscountReply>();

			return discountReply;
		}
		public async override Task<DiscountReply> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
		{
			var coupon = request.Coupon.Adapt<Coupon>() ??
				throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));
			dbContext.Coupons.Update(coupon);
			await dbContext.SaveChangesAsync();
			logger.LogInformation("Discount is successfully updated. ProductName : {ProductName}", coupon.ProductName);

			var discountReply = coupon.Adapt<DiscountReply>();

			return discountReply;
		}
		public async override Task<DeleteDiscountReply> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
		{
			var coupon = await dbContext.Coupons
				.FirstOrDefaultAsync(x => x.ProductName == request.ProductName)
				?? throw new RpcException(
					new Status(StatusCode.NotFound, $"Discount with ProductName : {request.ProductName} not avaliable."));

			dbContext.Coupons.Remove(coupon);
			await dbContext.SaveChangesAsync();

			logger.LogInformation("ProductName: {ProductName}. It's discount is succesfully deleted", coupon.ProductName);

			return new DeleteDiscountReply{IsSuccess = true};
		}
	}
}
