using Framework.Persistence.EF;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sales.SalesManagement.Persistence.EF.Item
{
    public class ItemMapping : AggregateRootMapping<Domain.Item.Item>
    {
        protected override void MapProperties(EntityTypeBuilder<Domain.Item.Item> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1024).IsRequired(false);
            builder.Property(p => p.GoodsId).IsRequired();
        }
    }
}