using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Mapping
{
    public class BlogMap : IEntityTypeConfiguration<Blogg>
    {
        public void Configure(EntityTypeBuilder<Blogg> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Title).HasMaxLength(100).IsRequired();
            builder.Property(I => I.ShortDesc).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(I => I.ImagePath).HasMaxLength(300);

            builder.HasMany(I => I.Comments).WithOne(I => I.Blogg).HasForeignKey(I => I.BlogId);
            builder.HasMany(I => I.CategoryBlogs).WithOne(I => I.Blogs).HasForeignKey(I => I.BlogId);
        }
    }
}
