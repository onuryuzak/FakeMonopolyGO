using UnityEngine;
using UnityEngine.Events;

namespace MyGame.Core.Services
{
    public interface IDiceAnimationService
    {
        void PlayAnimation(int face, GameObject targetDice, UnityAction onComplete = null);
    }
}