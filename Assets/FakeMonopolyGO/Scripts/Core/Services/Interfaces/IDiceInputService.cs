using MyGame.Core.DI;
using MyGame.Game;
using UnityEngine;

namespace MyGame.Core.Services
{
    public interface IDiceInputService
    {
        void Initialize(ServiceContainer serviceContainer, GameObject firstDice,
            GameObject secondDice,Player player);
    }
}