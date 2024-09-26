﻿namespace Basket.API.Data
{
	public class BasketRepository (IDocumentSession session)
		: IBasketRepository
	{

		public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
		{
			var basket = await session.LoadAsync<ShoppingCart>(userName, cancellationToken);
			return basket ?? throw new BasketNotFoundException(nameof(basket));
		}

		public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
		{
			session.Store(basket);
			await session.SaveChangesAsync(cancellationToken);
			return basket;
		}
		public Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}
	}
}
