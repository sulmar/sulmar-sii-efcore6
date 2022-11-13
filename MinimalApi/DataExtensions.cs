using Microsoft.EntityFrameworkCore;

namespace MinimalApi
{
    public static class DataExtensions
    {
        public static WebApplication ApplyMigrations<TDbContext>(this WebApplication app)
            where TDbContext : DbContext
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TDbContext>();
            db.Database.Migrate();
            return app;
        }
    }
}
