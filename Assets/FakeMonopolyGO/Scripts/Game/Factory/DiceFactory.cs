using MyGame.Core.DI;
using MyGame.Core.Services;
using UnityEngine;

namespace MyGame.Core.Factories
{
    public class DiceFactory
    {
        public GameObject CreateDice(GameObject dicePrefab)
        {
            GameObject diceInstance = Object.Instantiate(dicePrefab);
            return diceInstance;
        }
    }
}