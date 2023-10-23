using Microsoft.EntityFrameworkCore;
using TaskHTT.DataLayer.EfCode;
using TaskHTT.DataLayer.PgSql.EfCode;

namespace TaskHTT.UI.Extensions
{
    public static class DbServiceExtentions
    {
        public static void ConfigureDbServices(this IServiceCollection services)
        {
            services.AddDbContext<EfCoreContext, PgSqlContext>(options =>
                options.UseNpgsql(AppSettings.Instance.Database.PgSql.ConnectionString));
            //.AddInterceptors(new HintInterceptor()));
            services.AddScoped<DbContext>(x => x.GetService<EfCoreContext>());
        }
    }
}
