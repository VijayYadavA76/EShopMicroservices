namespace Ordering.Domain.Models
{
	public class OrderItem : Entity<Guid>
	{
		internal OrderItem(Guid orderId, Guid productId, decimal quantity, int price ) 
		{ 
			OrderId = orderId;
			ProductId = productId;
			Price = price;
			Quantity = quantity;
		}
		public Guid OrderId { get; private set; } = default!;
		public Guid ProductId { get; private set; } = default!;
		public int Price { get; private set; } = default!;
		public decimal Quantity { get; private set; } = default!;
	}
}
