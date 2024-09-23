using MediatR;

namespace Catalog.API.Products.CreateProduct
{
	public record CreateProductCommand
	(
		string Name,
		string Description,
		string ImageFile,
		decimal Price,
		List<string> Category
	) : IRequest<CreateProductResult>;

	public record CreateProductResult(Guid Id);

	internal class CreateProductCommandHandler
	{
	}
}
