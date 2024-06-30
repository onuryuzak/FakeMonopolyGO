using MyGame.Core.DI;
using UnityEngine;

namespace MyGame.Core.Services
{
    public interface IDiceInputService
    {
        void Initialize(ServiceContainer serviceContainer, GameObject firstDice,
            GameObject secondDice);
    }
}