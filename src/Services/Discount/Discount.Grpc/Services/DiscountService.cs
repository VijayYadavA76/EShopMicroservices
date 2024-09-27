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
			return Task.FromResult(new DiscountReply
			{
				ProductName = "Hello " + request.ProductName
			});
		}
	}
}
