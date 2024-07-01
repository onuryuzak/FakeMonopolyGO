using MyGame.Models;

namespace MyGame.Core.Services
{
    public interface IMapGenerationService
    {
        void GenerateMap(GridSlot[] gridSlots);
        GridSlot[] GetGridSlots();
    }
}