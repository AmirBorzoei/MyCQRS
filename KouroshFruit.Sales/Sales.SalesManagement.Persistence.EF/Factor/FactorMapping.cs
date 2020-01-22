using Framework.Persistence.EF;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sales.SalesManagement.Persistence.EF.Factor
{
    public class FactorMapping : AggregateRootMapping<Domain.Factor.Factor>
    {
        protected override void MapProperties(EntityTypeBuilder<Domain.Factor.Factor> builder)
        {
            builder.Property(p => p.IssueDate).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1024).IsRequired(false);
            builder.HasMany(p => p.FactorItems);
        }
    }
}
