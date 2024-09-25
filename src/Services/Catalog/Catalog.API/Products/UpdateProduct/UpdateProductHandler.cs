
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.UpdateProduct
{
	public record UpdateProductCommand
	(
		Guid Id,
		string Name,
		string Description,
		string ImageFile,
		decimal Price,
		List<string> Category
	) : ICommand<UpdateProductResult>;

	public record UpdateProductResult(bool IsSuccess);

	public class UpdateProductCommandValidater : AbstractValidator<UpdateProductCommand>
	{
		public UpdateProductCommandValidater()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is required");
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required")
				.Length(2,150).WithMessage("Name Length must be between 2 to 150 charaters");
			RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
			RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
		}
	};
	internal class UpdateProductHandler(IDocumentSession session, ILogger<UpdateProductHandler> logger)
		: ICommandHandler<UpdateProductCommand, UpdateProductResult>
	{
		public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
		{
			logger.LogInformation("UpdateProductHandler.Handle called with {@Command}", command);
			var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
			if (product is null)
			{
				throw new ProductNotFoundException(command.Id);
			}
			product.Name = command.Name;
			product.Description = command.Description;
			product.ImageFile = command.ImageFile;
			product.Price = command.Price;
			product.Category = command.Category;

			session.Update(product);
			session.SaveChanges();
			return new UpdateProductResult(true);
		}
	}
}
