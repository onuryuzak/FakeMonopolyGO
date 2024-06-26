using MyGame.Models;

namespace MyGame.Core.Services
{
    public interface IItemService
    {
        void GenerateItems(GridSlot[] slots);
        int CollectItem(GridSlot slot);
    }
}