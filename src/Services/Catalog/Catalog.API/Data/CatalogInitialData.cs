using Marten.Schema;

namespace Catalog.API.Data
{
	public class CatalogInitialData : IInitialData
	{
		public async Task Populate(IDocumentStore store, CancellationToken cancellation)
		{
			using var session = store.LightweightSession();

			// check if any data exist
			if(await session.Query<Product>().AnyAsync())
			{
				return ;
			}

			// Marten UPSERT will carter for existing records
			session.Store<Product>(PreConfiguredProducts);
			await session.SaveChangesAsync();
		}

		private static IEnumerable<Product> PreConfiguredProducts => new List<Product>
			{
				new()
				{
					Id = new Guid("0192283f-52b9-432e-9483-9a5bf5b5ca07"),
					Name = "LG UltraGear 27GN950-B",
					Description = "The LG UltraGear 27GN950-B is a 27-inch 4K UHD gaming monitor with a 144Hz refresh rate and NVIDIA G-SYNC compatibility, delivering stunning visuals for an immersive gaming experience.",
					ImageFile = "product-1.png",
					Price = 799.99M,
					Category =
					[
						"Monitor",
						"Computers&Accessories"
					]
				},
				new()
				{
					Id = new Guid("e7f3a4d7-68a4-4c5b-8fbd-9c5e1ec19478"),
					Name = "Samsung Galaxy S21",
					Description = "The Samsung Galaxy S21 features a stunning 6.2-inch display, triple-camera system, and a powerful Exynos 2100 processor for seamless multitasking.",
					ImageFile = "product-2.png",
					Price = 799.99M,
					Category =
					[
						"Smart Phone",
						"Electronic&Accessories"
					]
				},

				new()
				{
					Id = new Guid("b63b5e23-3e74-4c8a-b7ae-cb3a9a6f68a7"),
					Name = "Sony WH-1000XM4",
					Description = "Industry-leading noise cancellation, exceptional sound quality, and up to 30 hours of battery life make the Sony WH-1000XM4 the perfect travel companion.",
					ImageFile = "product-3.png",
					Price = 349.99M,
					Category =
					[
						"Headphones",
						"Audio&Accessories"
					]
				},

				new()
				{
					Id = new Guid("19c647c0-b65d-4d0c-a4a8-bd64e90a00f4"),
					Name = "Apple MacBook Air",
					Description = "The MacBook Air is ultra-thin and lightweight, equipped with the M1 chip for powerful performance and incredible battery life of up to 18 hours.",
					ImageFile = "product-4.png",
					Price = 999.99M,
					Category =
					[
						"Laptop",
						"Computers&Accessories"
					]
				},

				new()
				{
					Id = new Guid("1d73e43b-1a8f-4c34-9ef7-2b1e10a34e76"),
					Name = "Dell XPS 13",
					Description = "With its stunning InfinityEdge display and high performance, the Dell XPS 13 is perfect for professionals on the go.",
					ImageFile = "product-5.png",
					Price = 1_199.99M,
					Category =
					[
						"Laptop",
						"Computers&Accessories"
					]
				},

				new()
				{
					Id = new Guid("7b23556a-0f58-4fcb-82d1-d38b249cd3af"),
					Name = "Google Pixel 6",
					Description = "The Google Pixel 6 combines a powerful Google Tensor chip with a stunning 6.4-inch display and a revolutionary camera for stunning photography.",
					ImageFile = "product-6.png",
					Price = 599.99M,
					Category =
					[
						"Smart Phone",
						"Electronic&Accessories"
					]
				},

				new()
				{
					Id = new Guid("8e2f5c15-0f73-404b-b9e6-d6ff0be23d49"),
					Name = "Fitbit Charge 5",
					Description = "The Fitbit Charge 5 offers advanced health metrics, built-in GPS, and a sleek design, making it the ultimate fitness tracker.",
					ImageFile = "product-7.png",
					Price = 179.95M,
					Category =
					[
						"Fitness Tracker",
						"Health&Fitness"
					]
				},

				new()
				{
					Id = new Guid("a5e947bc-5aeb-4fd0-bd0e-f31d48616d72"),
					Name = "Amazon Echo Dot (4th Gen)",
					Description = "Compact and stylish, the Echo Dot features Alexa voice control, making it easy to play music, control smart home devices, and get answers to your questions.",
					ImageFile = "product-8.png",
					Price = 49.99M,
					Category =
					[
						"Smart Speaker",
						"Home&Living"
					]
				},

				new()
				{
					Id = new Guid("37f9a267-b2a4-4a1b-91fc-e1079c6db187"),
					Name = "GoPro HERO9 Black",
					Description = "Capture your adventures in stunning 5K video with the GoPro HERO9 Black, featuring HyperSmooth stabilization and a front-facing display.",
					ImageFile = "product-9.png",
					Price = 399.99M,
					Category =
					[
						"Camera",
						"Photography&Accessories"
					]
				},

				new()
				{
					Id = new Guid("a3d6cfb7-91b1-4474-a8e8-40bdfc4820be"),
					Name = "Apple AirPods Pro",
					Description = "With active noise cancellation and a customizable fit, Apple AirPods Pro deliver immersive sound and seamless connectivity.",
					ImageFile = "product-10.png",
					Price = 249.99M,
					Category =
					[
						"Headphones",
						"Audio&Accessories"
					]
				},

				new()
				{
					Id = new Guid("b0323b7c-ff95-4149-9b9b-f06cb68ff9c8"),
					Name = "Microsoft Surface Pro 7",
					Description = "The Surface Pro 7 is a versatile 2-in-1 laptop with a stunning PixelSense display, Intel Core processor, and ultra-lightweight design.",
					ImageFile = "product-11.png",
					Price = 899.99M,
					Category =
					[
						"Laptop",
						"Computers&Accessories"
					]
				},

				new()
				{
					Id = new Guid("6a0a6f1e-d8d5-4b7c-ae55-d34cbd7b66ed"),
					Name = "Samsung QLED TV",
					Description = "Experience stunning visuals with the Samsung QLED TV, featuring 4K resolution, quantum dot technology, and smart connectivity.",
					ImageFile = "product-12.png",
					Price = 1_299.99M,
					Category =
					[
						"Television",
						"Home&Living"
					]
				},

				new()
				{
					Id = new Guid("5df6e342-c7cf-4949-b6c0-40b36a754a56"),
					Name = "Razer BlackWidow V3",
					Description = "The Razer BlackWidow V3 is a premium mechanical gaming keyboard with customizable RGB lighting and tactile switches for a superior gaming experience.",
					ImageFile = "product-13.png",
					Price = 169.99M,
					Category =
					[
						"Keyboard",
						"Gaming&Accessories"
					]
				},

				new()
				{
					Id = new Guid("2a6705bc-5e91-4e88-9d6d-3d15e0f6c15b"),
					Name = "Nikon D3500",
					Description = "A perfect entry-level DSLR, the Nikon D3500 features a 24.2MP sensor and is great for capturing stunning photos and videos.",
					ImageFile = "product-14.png",
					Price = 499.99M,
					Category =
					[
						"Camera",
						"Photography&Accessories"
					]
				},

				new()
				{
					Id = new Guid("d2f3c7c6-dc47-4c3e-b1f0-fcde7c1c163e"),
					Name = "Apple iPad Air",
					Description = "The Apple iPad Air features a 10.9-inch Liquid Retina display and is powered by the A14 Bionic chip for exceptional performance.",
					ImageFile = "product-15.png",
					Price = 599.00M,
					Category =
					[
						"Tablet",
						"Computers&Accessories"
					]
				}

			};

	}
}
