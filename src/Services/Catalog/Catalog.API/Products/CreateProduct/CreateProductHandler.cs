﻿namespace Catalog.API.Products.CreateProduct
{
	public record CreateProductCommand
	(
		string Name,
		string Description,
		string ImageFile,
		decimal Price,
		List<string> Category
	) : ICommand<CreateProductResult>;

	public record CreateProductResult(Guid Id);
	public class CreateProductCommandValidater : AbstractValidator<CreateProductCommand>
	{
		public CreateProductCommandValidater()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
			RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
			RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
			RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
		}
	};

	internal class CreateProductCommandHandler
		(IDocumentSession session)
		: ICommandHandler<CreateProductCommand, CreateProductResult>
	{
		public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
		{

			// create Product entity from command object

			var product = new Product
			{
				Name = command.Name,
				Description = command.Description,
				ImageFile = command.ImageFile,
				Price = command.Price,
				Category = command.Category
			};
			// save to database
			session.Store( product );
			await session.SaveChangesAsync(cancellationToken);

			// return CreateProductResult
			return new CreateProductResult(product.Id);
		}
	}
}
