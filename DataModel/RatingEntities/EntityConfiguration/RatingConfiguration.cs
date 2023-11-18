using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.RatingEntities.EntityConfiguration
{
    class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("tblRating");
            builder.HasKey(x => x.RatingId);

            builder.Property(x => x.RatingId).HasColumnName(@"RatingId").HasColumnType("int");
            builder.Property(x => x.RatingName).HasColumnName(@"Rating").HasColumnType("varchar").IsRequired(false).IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.Factor).HasColumnName(@"Factor").HasColumnType("decimal").IsRequired(false).HasPrecision(3, 2);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("varchar").IsRequired(false).IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).HasColumnName(@"CreatedDate").HasColumnType("smalldatetime").IsRequired(false);
        }
    }
}
