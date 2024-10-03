namespace Ordering.Infrastructure.Data.Extentions
{
	public static class InitialData
	{
		public static IEnumerable<Customer> Customers => new List<Customer>
		{
			Customer.Create(CustomerId.Of(new Guid("3f991f64-0d13-412f-ad1e-7b207be71e35")),"Vijay","vijay@intelegencia.com"),
			Customer.Create(CustomerId.Of(new Guid("4b437fdc-3a2d-4b1c-9b2a-91a22310f154")),"Ram","ram@intelegencia.com")
		};

		public static IEnumerable<Product> Products => new List<Product>
		{
			Product.Create(ProductId.Of(new Guid("0192283f-52b9-432e-9483-9a5bf5b5ca07")),"LG UltraGear 27GN950-B",799.99M),
			Product.Create(ProductId.Of(new Guid("e7f3a4d7-68a4-4c5b-8fbd-9c5e1ec19478")),"Samsung Galaxy S21",799.99M),
			Product.Create(ProductId.Of(new Guid("b63b5e23-3e74-4c8a-b7ae-cb3a9a6f68a7")),"Sony WH-1000XM4",349.99M),
			Product.Create(ProductId.Of(new Guid("19c647c0-b65d-4d0c-a4a8-bd64e90a00f4")),"Apple MacBook Air",999.99M),
			Product.Create(ProductId.Of(new Guid("1d73e43b-1a8f-4c34-9ef7-2b1e10a34e76")),"Dell XPS 13",1_199.99M),
		};
		public static IEnumerable<Order> OrdersWithItems
		{
			get
			{
				var address1 = Address.Of("Vijay", "Yadav", "vijay@intelegencia.com", "Azamgarh", "India", "Uttar Pradesh", "276126");
				var address2 = Address.Of("Ram", "Singh", "ram@intelegencia.com", "73 wallstreet", "USA", "California", "276126");

				var payment1 = Payment.Of("Vijay", "534523457654", "27/10", "342", 1);
				var payment2 = Payment.Of("Ram", "564723857352", "26/09", "224", 2);

				var order1 = Order.Create
					(
						OrderId.Of(new Guid("4d664ccc-59ff-448e-bac8-e41a2e5f4bdd")),
						CustomerId.Of(new Guid("3f991f64-0d13-412f-ad1e-7b207be71e35")),
						OrderName.Of("ORD_1"),
						shippingAddress: address1,
						billingAddress: address1,
						payment1

					);
				order1.Add(ProductId.Of(new Guid("0192283f-52b9-432e-9483-9a5bf5b5ca07")), 1, 799.99M);
				order1.Add(ProductId.Of(new Guid("e7f3a4d7-68a4-4c5b-8fbd-9c5e1ec19478")), 2, 1_599.98M);

				var order2 = Order.Create
					(
						OrderId.Of(new Guid("a686e03d-1735-4540-acb5-229069df7136")),
						CustomerId.Of(new Guid("4b437fdc-3a2d-4b1c-9b2a-91a22310f154")),
						OrderName.Of("ORD_2"),
						shippingAddress: address2,
						billingAddress: address2,
						payment2

					);
				order2.Add(ProductId.Of(new Guid("b63b5e23-3e74-4c8a-b7ae-cb3a9a6f68a7")), 1, 349.99M);
				order2.Add(ProductId.Of(new Guid("19c647c0-b65d-4d0c-a4a8-bd64e90a00f4")), 1, 999.99M);
				order2.Add(ProductId.Of(new Guid("1d73e43b-1a8f-4c34-9ef7-2b1e10a34e76")), 1, 1_199.99M);

				return [order1,order2];
			}
		}
	}
}
