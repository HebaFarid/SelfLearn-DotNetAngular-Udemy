using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.CompanyName).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Location).IsRequired();
            builder.HasOne(p => p.JobCategory).WithMany().HasForeignKey(p => p.JobCategoryId);
        }
    }
}