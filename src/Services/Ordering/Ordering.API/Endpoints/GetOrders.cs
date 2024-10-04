using Ordering.Application.Orders.Queries.GetOrders;

namespace Ordering.API.Endpoints
{
	// public record GetOrdersRequest(PaginatedRequest PaginatedRequest);
	public record GetOrdersResponse(PaginatedResult<OrderDto> PaginatedResult);
	public class GetOrders : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapGet("/orders",
				async ([AsParameters] PaginatedRequest request, ISender sender) =>
				{

					var result = await sender.Send(new GetOrdersQuery(request));

					var response = result.Adapt<GetOrdersResponse>();

					return Results.Ok(response);

				})
				.WithName("GetOrders")
				.WithSummary("Get list of order")
				.WithDescription("Get list of order")
				.Produces<GetOrdersResponse>(StatusCodes.Status200OK)
				.ProducesProblem(StatusCodes.Status400BadRequest)
				.ProducesProblem(StatusCodes.Status404NotFound);
		}
	}
}
