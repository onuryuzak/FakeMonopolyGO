using System.Collections;
using MyGame.Game;
using UnityEngine;
using UnityEngine.Events;

namespace MyGame.Core.Services
{
    public class DiceAnimationService : IDiceAnimationService
    {
        private readonly DiceAnimationSettings _settings;

        public DiceAnimationService(DiceAnimationSettings settings)
        {
            _settings = settings;
        }

        public void PlayAnimation(int face, GameObject targetDice, UnityAction onComplete = null)
        {
            if (!ValidateFaceValue(face))
            {
                Debug.LogError("Invalid dice face value.");
                return;
            }

            var coroutineHost = targetDice.GetComponent<MonoBehaviour>();
            if (coroutineHost == null)
            {
                Debug.LogError("Coroutine host (MonoBehaviour) not found on dice object.");
                return;
            }

            coroutineHost.StartCoroutine(AnimateDiceRoll(face - 1, targetDice, onComplete));
        }

        private bool ValidateFaceValue(int face)
        {
            return face >= 1 && face <= 6;
        }

        private IEnumerator AnimateDiceRoll(int faceIndex, GameObject dice, UnityAction onComplete)
        {
            Vector3 initialPosition = dice.transform.position;

            yield return DropDice(initialPosition, dice);

            yield return BounceAndRollDice(initialPosition, faceIndex, dice, onComplete);

            dice.transform.rotation = Quaternion.Euler(_settings.FaceRotations[faceIndex]);

            onComplete?.Invoke();
        }

        private IEnumerator DropDice(Vector3 initialPosition, GameObject dice)
        {
            float elapsedTime = 0f;
            Vector3 dropPoint = initialPosition + Vector3.up * _settings.DropHeight;
            dice.gameObject.SetActive(true);
            Vector3 targetPosition = dropPoint + Vector3.down * _settings.DropHeight +
                                     Vector3.forward * _settings.ForwardDistance;

            while (elapsedTime < _settings.DropDuration)
            {
                dice.transform.position = Vector3.Lerp(dropPoint, targetPosition, elapsedTime / _settings.DropDuration);
                dice.transform.Rotate(Vector3.right * 360f * Time.deltaTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            dice.transform.position = targetPosition;
        }

        private IEnumerator BounceAndRollDice(Vector3 initialPosition, int faceIndex, GameObject dice,
            UnityAction onComplete)
        {
            float currentBounceHeight = _settings.BounceHeight;
            Vector3 forwardMove = Vector3.forward * _settings.ForwardDistance / 3;
            Vector3 bounceStart = initialPosition + Vector3.forward * _settings.ForwardDistance;

            for (int i = 0; i < _settings.BounceCount; i++)
            {
                float elapsedTime = 0f;
                Vector3 upPosition = bounceStart + Vector3.up * currentBounceHeight;
                Vector3 downPosition = bounceStart;

                while (elapsedTime < _settings.BounceDuration)
                {
                    float t = elapsedTime / _settings.BounceDuration;
                    dice.transform.position = Vector3.Lerp(downPosition, upPosition, Mathf.Sin(t * Mathf.PI)) +
                                              forwardMove * t;
                    dice.transform.Rotate(Vector3.right * 360f * Time.deltaTime +
                                          Random.insideUnitSphere * _settings.BounceRandomness);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                bounceStart = dice.transform.position;
                currentBounceHeight *= 0.5f;
            }

            float rollElapsedTime = 0f;
            Quaternion initialRotation = dice.transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(_settings.FaceRotations[faceIndex]);

            while (rollElapsedTime < _settings.RollDuration)
            {
                dice.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation,
                    rollElapsedTime / _settings.RollDuration);
                dice.transform.Rotate(Random.insideUnitSphere * 10f);
                rollElapsedTime += Time.deltaTime;
                yield return null;
            }

            dice.transform.rotation = targetRotation;
            yield return new WaitForSeconds(1);
            onComplete?.Invoke();
            dice.transform.localPosition = new Vector3(dice.transform.localPosition.x, 0, 0);
        }
    }
}