
namespace Catalog.API.Products.GetProductByCategory
{
	public record GetProductByCategoryRequest(int? PageNumber = 1, int? PageSize = 10);
	public record GetProductByCategoryResponse(IEnumerable<Product> Products);
	public class GetProductByCategoryEndpoint : ICarterModule

	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapGet("/products/category/{category}",
				async ([AsParameters] GetProductByCategoryRequest request, string category, ISender sender) =>
				{
					var query = request.Adapt<GetProductByCategoryRequest>();

					var result = await sender.Send(new GetProductByCategoryQuery(category,query.PageNumber,query.PageSize));

					var response = result.Adapt<GetProductByCategoryResponse>();

					return Results.Ok(response);

				})
				.WithName("GetProductByCategory")
				.WithSummary("Get list of Product By Category")
				.WithDescription("Get list of Product By Category")
				.Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
				.ProducesProblem(StatusCodes.Status400BadRequest);
		}
	}
}
