namespace Catalog.API.Products.UpdateProduct
{
	public record UpdateProductRequest
	(
		Guid Id,
		string Name,
		string Description,
		string ImageFile,
		decimal Price,
		List<string> Category
	) : ICommand<UpdateProductResult>;

	public record UpdateProductResponse(bool IsSuccess);
	public class UpdateProductEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapPut("/products",
				async (UpdateProductRequest request, ISender sender) =>
				{
					var command = request.Adapt<UpdateProductCommand>();

					var result = await sender.Send(command);

					var response = result.Adapt<UpdateProductResponse>();

					return Results.Ok(response);

				})
				.WithName("UpdateProduct")
				.WithSummary("Update a Product")
				.WithDescription("Update a Product")
				.Produces<UpdateProductResponse>(StatusCodes.Status200OK)
				.ProducesProblem(StatusCodes.Status400BadRequest)
				.ProducesProblem(StatusCodes.Status404NotFound);
		}
	}
}
