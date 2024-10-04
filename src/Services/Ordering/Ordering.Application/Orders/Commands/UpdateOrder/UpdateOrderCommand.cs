namespace Ordering.Application.Orders.Commands.UpdateOrder
{
	public record UpdateOrderCommand(OrderDto Order) 
		: ICommand<UpdateOrderResult>;
	public record UpdateOrderResult(bool IsSuccess);

	public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
	{
		public UpdateOrderValidator()
		{
			RuleFor(o => o.Order.OrderName).NotEmpty().WithMessage("OrderName is required");
			RuleFor(o => o.Order.CustomerId).NotNull().WithMessage("CustomerId is not null");
			RuleFor(o => o.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
		}
	}
}
