using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public static class MigrationExtensions
    {
        public static async Task ApplyMigrationsAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DiscountContext>();
            await context.Database.MigrateAsync();
        }
    }
}
