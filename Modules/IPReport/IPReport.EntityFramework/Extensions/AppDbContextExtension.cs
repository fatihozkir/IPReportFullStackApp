using IPReport.EntityFramework.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IPReport.EntityFramework.Extensions;

public static class AppDbContextExtension
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddIPReportDbConfig(string connectionString)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

            services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

            return services;
        }
    }
    
}
