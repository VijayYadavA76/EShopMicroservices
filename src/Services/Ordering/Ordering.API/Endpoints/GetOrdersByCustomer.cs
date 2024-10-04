﻿
using Ordering.Application.Orders.Queries.GetOrdersByCutomer;

namespace Ordering.API.Endpoints
{
	// public record GetOrdersByCustomerRequest(Guid CustomerId);

	public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);
	public class GetOrdersByCustomer : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapGet("/orders/customer/{customerId}",
				async (Guid customerId, ISender sender) =>
				{

					var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));

					var response = result.Adapt<GetOrdersByCustomerResponse>();

					return Results.Ok(response);

				})
				.WithName("GetOrdersByCustomerResponse")
				.WithSummary("Get list of Order By Customer")
				.WithDescription("Get list of Order By Customer")
				.Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
				.ProducesProblem(StatusCodes.Status400BadRequest)
				.ProducesProblem(StatusCodes.Status404NotFound);
		}
	}
}
