using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.OccupationEntities.EntityConfiguration
{
    class OccupationConfiguration : IEntityTypeConfiguration<Occupation>
    {
        public void Configure(EntityTypeBuilder<Occupation> builder)
        {
            builder.ToTable("tblOccupation");
            builder.HasKey(x => x.OccupationId);

            builder.Property(x => x.OccupationId).HasColumnName(@"OccupationId").HasColumnType("int");
            builder.Property(x => x.OccupationName).HasColumnName(@"OccupationName").HasColumnType("varchar").IsRequired(false).IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.RatingId).HasColumnName(@"RatingId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("varchar").IsRequired(false).IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).HasColumnName(@"CreatedDate").HasColumnType("smalldatetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Ratings).WithMany(b => b.Occupations).HasForeignKey(c => c.RatingId).OnDelete(DeleteBehavior.SetNull); // FK_tblOccupation_tblRating
        }
    }
}
