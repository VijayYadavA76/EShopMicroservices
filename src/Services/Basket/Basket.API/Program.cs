using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using static Discount.Grpc.Discount;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Application Services
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
	config.RegisterServicesFromAssembly(typeof(Program).Assembly);
	config.AddOpenBehavior(typeof(ValidationBehavior<,>));
	config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

// Data Services
builder.Services.AddMarten(options =>
{
	options.Connection(builder.Configuration.GetConnectionString("Database")!);
	options.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CacheBasketRepository>();
//builder.Services.AddScoped<IBasketRepository>(provider => {
//	var basketRepository = provider.GetRequiredService<BasketRepository>();
//	return new CacheBasketRepository(basketRepository,provider.GetRequiredService<IDistributedCache>());
//});

builder.Services.AddStackExchangeRedisCache(options =>
{
	options.Configuration = builder.Configuration.GetConnectionString("Redis");
	//options.InstanceName = "Basket";
});

// Grpc Services
builder.Services.AddGrpcClient<DiscountClient>(options =>
{
	options.Address = new Uri(builder.Configuration["GrpcSetting:DiscountUrl"]!);
});

// Cross-Cutting Services
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks()
	.AddNpgSql(builder.Configuration.GetConnectionString("Database")!)
	.AddRedis(builder.Configuration.GetConnectionString("Redis")!);

var app = builder.Build();

// Configure the HTTP request pipeline

app.MapCarter();
app.UseExceptionHandler(options => { });
app.UseHealthChecks("/health",
	new HealthCheckOptions
	{
		ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
	});
app.Run();
