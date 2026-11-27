using IPReport.EntityFramework.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IPReport.EntityFramework.Extensions;

public static class AppDbContextExtension
{
    public static IServiceCollection AddIPReportDbConfig(this IServiceCollection services, string connectionString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

        services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

        return services;
    }
}
