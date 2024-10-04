
using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders
{
	public class GetOrdersHandler(IApplicationDbContext dbContext)
		: IQueryHandler<GetOrdersQuery, GetOrdersResult>
	{
		public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
		{
			var pageIndex = query.PaginatedRequest.pageIndex;
			var pageSize = query.PaginatedRequest.pageSize;
			var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);
			var orders = 
				await dbContext.Orders
					.Include(o => o.OrderItems)
					.AsNoTracking()
					.Skip(pageIndex * pageSize)
					.Take(pageSize)
					.OrderBy(o => o.OrderName)
					.ToListAsync();
			
			return new GetOrdersResult(
				new PaginatedResult<OrderDto>
					(
						pageIndex: pageIndex,
						pageSize: pageSize,
						count: totalCount ,
						data: orders.ToOrderDtoList()
					));
		}
	}
}
