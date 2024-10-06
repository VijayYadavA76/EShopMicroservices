
using Basket.API.Basket.StoreBasket;

namespace Basket.API.Basket.CheckoutBasket
{
	public class CheckoutBasketEndpoint : ICarterModule
	{
		public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckoutDto);
		public record CheckoutBasketResponse(bool IsSucess);
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapPost("/basket/checkout", async (CheckoutBasketRequest request,ISender sender) =>
			{
				var command = request.Adapt<CheckoutBasketCommand>();
				var result = sender.Send(command);
				var response = result.Adapt<CheckoutBasketResponse>();
				return Results.Ok(response);
			})
			.WithName("CheckoutBasket")
			.WithSummary("CheckoutBasket")
			.WithDescription("CheckoutBasket")
			.Produces<StoreBasketResponse>(StatusCodes.Status201Created)
			.ProducesProblem(StatusCodes.Status400BadRequest); ;
		}
	}
}
