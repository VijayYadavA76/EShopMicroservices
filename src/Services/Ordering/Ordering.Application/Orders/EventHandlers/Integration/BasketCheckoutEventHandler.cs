using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration
{
	public class BasketCheckoutEventHandler
		(ISender sender, ILogger<BasketCheckoutEventHandler> logger)
		: IConsumer<BasketCheckoutEvent>
	{
		public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
		{
			logger.LogInformation("Integraton event handled: {IntegrationEvent}",context.Message.GetType().Name);
			var command = MapToCreateOrderCommand(context.Message);
			await sender.Send(command);
		}

		private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
		{
			// Create full order with incoming event data
			var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress, message.AddressLine, message.Country, message.State, message.ZipCode);
			var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);
			var orderId = Guid.NewGuid();

			var orderDto = new OrderDto(
				Id: orderId,
				CustomerId: message.CustomerId,
				OrderName: message.UserName,
				ShippingAddress: addressDto,
				BillingAddress: addressDto,
				Payment: paymentDto,
				Status: Ordering.Domain.Enums.OrderStatus.Pending,
				OrderItems:
				[
					new OrderItemDto(orderId, new Guid("0192283f-52b9-432e-9483-9a5bf5b5ca07"), 2, 1_599.8M),
					new OrderItemDto(orderId, new Guid("e7f3a4d7-68a4-4c5b-8fbd-9c5e1ec19478"), 1, 799.99M)
				]);

			return new CreateOrderCommand(orderDto);
		}
	}
}
