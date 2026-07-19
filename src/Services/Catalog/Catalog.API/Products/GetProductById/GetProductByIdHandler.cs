namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Pruduct);
    internal class GetProductByIdHandler(IDocumentSession session, ILogger<GetProductByIdHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetProductByIdQuery for Id: {Id}", query);

            var product = await session.LoadAsync<Product>(query.id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException();
            }

            return new GetProductByIdResult(product);
        }
    }
}
