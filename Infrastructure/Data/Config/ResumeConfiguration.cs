using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.MobileNumber).IsRequired();
            builder.Property(p => p.Address).IsRequired();
            builder.Property(p => p.Age).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.Property(p => p.Education).IsRequired();
            builder.Property(p => p.Experience).IsRequired();
            builder.HasOne(p => p.ResumeCategory).WithMany().HasForeignKey(p => p.ResumeCategoryId);
        }
    }
}