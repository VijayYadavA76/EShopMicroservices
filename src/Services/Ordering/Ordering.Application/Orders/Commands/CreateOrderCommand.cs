using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands
{
	public record CreateOrderCommand(OrderDto Order) 
		: ICommand<CreateOrderResult>;
	public record CreateOrderResult(Guid Id);

	public class CreateOrderCommandValidater : AbstractValidator<CreateOrderCommand>
	{
		public CreateOrderCommandValidater()
		{
			RuleFor(o => o.Order.OrderName).NotEmpty().WithMessage("OrderName is required");
			RuleFor(o => o.Order.CustomerId).NotNull().WithMessage("CustomerId is not null");
			RuleFor(o => o.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
		}
	}
}
