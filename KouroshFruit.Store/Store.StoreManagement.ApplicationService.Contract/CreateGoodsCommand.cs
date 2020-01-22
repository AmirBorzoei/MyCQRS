using Framework.Core.CommandHandling;

namespace Store.StoreManagement.ApplicationService.Contract
{
    public class CreateGoodsCommand : Command
    {
        public CreateGoodsCommand(string title, int length, int width, double weight, string description, int numberOfInventory)
        {
            Title = title;
            Length = length;
            Width = width;
            Weight = weight;
            Description = description;
            NumberOfInventory = numberOfInventory;
        }

        public string Title { get; private set; }

        public int Length { get; private set; }

        public int Width { get; private set; }

        public double Weight { get; private set; }

        public string Description { get; private set; }

        public int NumberOfInventory { get; private set; }
    }
}