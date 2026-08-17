namespace Basket.API.Basket.GetBasket
{
    public class GetBasketEndpoints : ICarterModule
    {
        public record GetBasketRequest(string UserName);
        public record GetBasketResponse(ShoppingCart Cart);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (GetBasketRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetBasketQuery>();

                var result = await sender.Send(query);

                return result.Adapt<GetBasketResponse>();
            }).WithName("GetBasket")
            .Produces<GetBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Basket")
            .WithDescription("Get Basket");
        }
    }
}
