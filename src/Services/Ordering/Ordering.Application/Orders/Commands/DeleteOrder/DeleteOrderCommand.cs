namespace Ordering.Application.Orders.Commands.DeleteOrder
{
	public record DeleteOrderCommand(Guid OrderId) : ICommand<DeleteOrderResult>;
	public record DeleteOrderResult(bool IsSuccess);

	public class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
	{
		public DeleteOrderValidator()
		{
			RuleFor(o => o.OrderId).NotNull().WithMessage("OrderId is required");
		}
	}
}
