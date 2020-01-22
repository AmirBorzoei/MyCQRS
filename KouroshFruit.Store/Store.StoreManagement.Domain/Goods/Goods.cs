using Framework.Core.Domain;
using Framework.Core.Event;
using Store.StoreManagement.Domain.Contract.Goods;
using Store.StoreManagement.Domain.Goods.Exceptions;

namespace Store.StoreManagement.Domain.Goods
{
    public class Goods : AggregateRoot
    {
        private Goods(string title, int length, int width, double weight, string description, int numberOfInventory)
        {
            SetTitle(title);
            SetLength(length);
            SetWidth(width);
            SetWeight(weight);
            SetDescription(description);
            SetNumberOfInventory(numberOfInventory);
        }

        public string Title { get; private set; }

        public int Length { get; private set; }

        public int Width { get; private set; }

        public double Weight { get; private set; }

        public string Description { get; private set; }

        public int NumberOfInventory { get; private set; }

        public void Export(int quantity)
        {
            if (NumberOfInventory < quantity)
            {
                throw new InvalidGoodsExportQuantity();
            }

            var newNumberOfInventory = NumberOfInventory - quantity;
            SetNumberOfInventory(newNumberOfInventory);
        }

        private void SetTitle(string title)
        {
            Title = title;
        }

        private void SetLength(int length)
        {
            Length = length;
        }

        private void SetWidth(int width)
        {
            Width = width;
        }

        private void SetWeight(double weight)
        {
            Weight = weight;
        }

        private void SetDescription(string description)
        {
            Description = description;
        }

        private void SetNumberOfInventory(int numberOfInventory)
        {
            NumberOfInventory = numberOfInventory;
        }

        public class GoodsFactory
        {
            private readonly IEventBus eventBus;

            public GoodsFactory(IEventBus eventBus)
            {
                this.eventBus = eventBus;
            }

            public Goods CreateGoods(string title, int length, int width, double weight, string description, int numberOfInventory)
            {
                var goods = new Goods(title, length, width, weight, description, numberOfInventory);

                eventBus.Publish(new GoodsCreatedEvent(goods.Id, goods.Title));

                return goods;
            }
        }
    }
}