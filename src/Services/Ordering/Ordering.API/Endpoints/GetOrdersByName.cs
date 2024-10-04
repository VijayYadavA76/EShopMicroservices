﻿using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.API.Endpoints
{
	// public record GetOrdersByNameRequest(string OrderName);

	public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);
	public class GetOrdersByName : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapGet("/orders/{orderName}",
				async (string orderName, ISender sender) =>
				{

					var result = await sender.Send(new GetOrdersByNameQuery(orderName));

					var response = result.Adapt<GetOrdersByNameResponse>();

					return Results.Ok(response);

				})
				.WithName("GetOrdersByNameResponse")
				.WithSummary("Get list of Order By Name")
				.WithDescription("Get list of Order By Name")
				.Produces<GetOrdersByNameResponse>(StatusCodes.Status200OK)
				.ProducesProblem(StatusCodes.Status400BadRequest)
				.ProducesProblem(StatusCodes.Status404NotFound);
		}
	}
}
