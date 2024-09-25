
using Catalog.API.Products.UpdateProduct;

namespace Catalog.API.Products.DeleteProduct
{
	public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
	public record DeleteProductResult(bool IsSuccess);
	public class DeleteProductCommandValidater : AbstractValidator<DeleteProductCommand>
	{
		public DeleteProductCommandValidater()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is required");
		}
	};
	internal class DeleteProductHandler(IDocumentSession session)
		: ICommandHandler<DeleteProductCommand, DeleteProductResult>
	{
		public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
		{
			session.Delete<Product>(command.Id);
			await session.SaveChangesAsync(cancellationToken);
			return new DeleteProductResult(true);
		}
	}
}
