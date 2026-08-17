namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketHandler(IDocumentSession session) : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var cart = await session.Query<ShoppingCart>().FirstOrDefaultAsync(sc => sc.UserName == request.UserName, cancellationToken);

            return cart is not null ? new GetBasketResult(cart) : throw new InvalidOperationException("Basket not found");
        }
    }
}
