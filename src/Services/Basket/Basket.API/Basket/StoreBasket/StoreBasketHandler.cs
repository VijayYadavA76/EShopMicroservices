using Discount.Grpc;
using static Discount.Grpc.Discount;

namespace Basket.API.Basket.StoreBasket
{
	public record StoreBasketCommand(ShoppingCart Cart) 
		: ICommand<StoreBasketResult>;

	public record StoreBasketResult(string UserName);
	public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
	{
		public StoreBasketCommandValidator()
		{
			RuleFor(x => x.Cart).NotNull().WithMessage("Cart should not be null");
			RuleFor(x => x.Cart.UserName).NotNull().WithMessage("UserName is required");
		}
	};

	public class StoreBasketCommandHandler
		(IBasketRepository repository, DiscountClient discount)
		: ICommandHandler<StoreBasketCommand, StoreBasketResult>
	{
		public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
		{
            // deduct discount price from amount
            await DeductDiscount(command.Cart, cancellationToken);
			// Store basket in database
			await repository.StoreBasket(command.Cart, cancellationToken);

			return new StoreBasketResult(command.Cart.UserName);
		}
		private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
		{
			// communicate with Discount.Grpc and calculate the latest prices of the products
			foreach (var item in cart.Items)
			{
				var coupon = await discount.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
				item.Price -= coupon.Amount;
			}
		}
	}
}
