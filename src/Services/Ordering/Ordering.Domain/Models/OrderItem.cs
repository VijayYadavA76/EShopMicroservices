namespace Ordering.Domain.Models
{
	public class OrderItem : Entity<OrderItemId>
	{
		internal OrderItem(OrderId orderId, ProductId productId, decimal quantity, int price ) 
		{ 
			Id = OrderItemId.Of(Guid.NewGuid());
			OrderId = orderId.Value;
			ProductId = productId.Value;
			Price = price;
			Quantity = quantity;
		}
		public Guid OrderId { get; private set; } = default!;
		public Guid ProductId { get; private set; } = default!;
		public int Price { get; private set; } = default!;
		public decimal Quantity { get; private set; } = default!;
	}
}
