using Framework.Persistence.EF;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sales.SalesManagement.Persistence.EF.Factor
{
    public class FactorItemMapping : EntityMapping<Domain.Factor.FactorItem>
    {
        protected override void MapProperties(EntityTypeBuilder<Domain.Factor.FactorItem> builder)
        {
            builder.Property(p => p.FactorId).IsRequired();
            builder.Property(p => p.ItemId).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
        }
    }
}
