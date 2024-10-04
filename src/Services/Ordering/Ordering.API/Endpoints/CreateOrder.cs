﻿using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.API.Endpoints
{
	public class CreateOrder : ICarterModule
	{
		public record CreateOrderRequest(OrderDto Order);
		public record CreateOrderResponse(Guid Id);
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
			{
				var command = request.Adapt<CreateOrderCommand>();

				var result = await sender.Send(command);

				var response = result.Adapt<CreateOrderResult>();

				return Results.Created($"/orders/{response.Id}", response);

			})
			.WithName("CreateOrder")
			.WithSummary("Create Order")
			.WithDescription("Create Order")
			.Produces<CreateOrderResponse>(StatusCodes.Status201Created)
			.ProducesProblem(StatusCodes.Status400BadRequest);
		}
	}
}
