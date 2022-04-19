using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Author).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Publisher).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Genre).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
