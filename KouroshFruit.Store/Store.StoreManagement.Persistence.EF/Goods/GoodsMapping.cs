using Framework.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace Store.StoreManagement.Persistence.EF.Goods
{
    public class GoodsMapping : AggregateRootMapping<Domain.Goods.Goods>
    {
        protected override void MapProperties(EntityTypeBuilder<Domain.Goods.Goods> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Length).HasColumnType(SqlDbType.Int.ToString()).IsRequired();
            builder.Property(p => p.Width).HasColumnType(SqlDbType.Int.ToString()).IsRequired();
            builder.Property(p => p.Weight).HasColumnType(SqlDbType.Decimal.ToString()).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1024).IsRequired(false);
            builder.Property(p => p.NumberOfInventory).HasColumnType(SqlDbType.Int.ToString()).IsRequired();
        }
    }
}