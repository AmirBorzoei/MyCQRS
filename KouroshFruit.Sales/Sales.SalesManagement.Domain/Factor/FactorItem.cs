using Framework.Core.Domain;
using System;

namespace Sales.SalesManagement.Domain.Factor
{
    public class FactorItem : Entity
    {
        private FactorItem(Guid factorId, Guid itemId, int quantity)
        {
            CreatedBy = "";
            LastChangedBy = "";

            SetFactorId(factorId);
            SetItemId(itemId);
            SetQuantity(quantity);
        }

        public Guid FactorId { get; private set; }

        public Guid ItemId { get; private set; }

        public int Quantity { get; private set; }

        public void SetFactorId(Guid factorId)
        {
            FactorId = factorId;
        }

        private void SetItemId(Guid itemId)
        {
            ItemId = itemId;
        }

        private void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public static FactorItem CreateFactorItem(Guid factorId, Guid itemId, int quantity)
        {
            var factorItem = new FactorItem(factorId, itemId, quantity);
            return factorItem;
        }
    }
}