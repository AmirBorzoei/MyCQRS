﻿using Framework.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace Framework.Persistence.EF
{
    public abstract class EntityMapping<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        protected virtual bool ShouldCreateTable => true;

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsRequired();
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedDate).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired();
            builder.Property(e => e.LastChangedDate).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired(false);
            builder.Property(e => e.CreatedBy).HasMaxLength(256).IsRequired();
            builder.Property(e => e.LastChangedBy).HasMaxLength(256).IsRequired();

            builder.Property(e => e.RowVersion).HasColumnType(SqlDbType.Timestamp.ToString()).IsRequired().IsRowVersion();

            MapProperties(builder);

            if (ShouldCreateTable)
            {
                CreateTable(builder);
            }
        }

        protected abstract void MapProperties(EntityTypeBuilder<T> builder);

        protected virtual void CreateTable(EntityTypeBuilder<T> builder)
        {
            var tableName = typeof(T).Name;
            var schemaName = typeof(T).Namespace?.Split('.')[1];
            builder.ToTable(tableName, schemaName);
        }
    }
}