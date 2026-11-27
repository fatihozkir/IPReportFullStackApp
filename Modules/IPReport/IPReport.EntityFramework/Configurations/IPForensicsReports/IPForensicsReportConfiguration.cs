using IPReport.Core.Entities.IPForensicsReports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IPReport.EntityFramework.Configurations.IPForensicsReports
{
    internal sealed class IPForensicsReportConfiguration : IEntityTypeConfiguration<IPForensicsReport>
    {
        public void Configure(EntityTypeBuilder<IPForensicsReport> builder)
        {
            builder.HasIndex(x => new { x.AppUser_FK, x.CreatedDate });
        }
    }
}
