using Grpc.Core;

namespace Discount.Grpc.Services
{
	public class DiscountService : Discount.DiscountBase
	{
		private readonly ILogger<DiscountService> _logger;
		public DiscountService(ILogger<DiscountService> logger)
		{
			_logger = logger;
		}

		public override Task<DiscountReply> GetDiscount(GetDiscountRequest request, ServerCallContext context)
		{
			return base.GetDiscount(request, context);
		}
		public override Task<DiscountReply> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
		{
			return base.CreateDiscount(request, context);
		}
		public override Task<DiscountReply> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
		{
			return base.UpdateDiscount(request, context);
		}
		public override Task<DeleteDiscountReply> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
		{
			return base.DeleteDiscount(request, context);
		}
	}
}
