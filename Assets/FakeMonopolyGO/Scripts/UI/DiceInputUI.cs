using MyGame.Core.DI;
using UnityEngine;
using UnityEngine.UI;
using MyGame.Core.Services;
using MyGame.Game;
using TMPro;

namespace MyGame.UI
{
    public class DiceInputUI : MonoBehaviour, IDiceInputService
    {
        [SerializeField] private TMP_InputField _dice1InputField;
        [SerializeField] private TMP_InputField _dice2InputField;
        [SerializeField] private Button _rollButton;

        private IDiceAnimationService _diceAnimationService;
        private GameObject _firstDice;
        private GameObject _secondDice;
        private Player _player;

        public void Initialize(ServiceContainer serviceContainer, GameObject firstDice, GameObject secondDice,
            Player player)
        {
            _player = player;
            _firstDice = firstDice;
            _secondDice = secondDice;
            SetGameObjectActivity(false);
            _diceAnimationService = serviceContainer.Resolve<IDiceAnimationService>();
            _rollButton.onClick.AddListener(OnRollButtonClicked);
        }

        private void OnRollButtonClicked()
        {
            if (!IsValidDiceValue(_dice1InputField.text) || !IsValidDiceValue(_dice2InputField.text))
            {
                return;
            }

            var dice1Value = int.Parse(_dice1InputField.text);
            var dice2Value = int.Parse(_dice2InputField.text);
            var totalValue = dice1Value + dice2Value;
            SetGameObjectActivity(true);
            _diceAnimationService.PlayAnimation(dice1Value, _firstDice);
            _diceAnimationService.PlayAnimation(dice2Value, _secondDice, () =>
            {
                SetGameObjectActivity(false);
                _player.Move(totalValue);
            });
        }

        private void SetGameObjectActivity(bool state)
        {
            _firstDice.SetActive(state);
            _secondDice.SetActive(state);
        }

        private bool IsValidDiceValue(string value)
        {
            if (int.TryParse(value, out int intValue))
            {
                return intValue >= 1 && intValue <= 6;
            }

            return false;
        }
    }
}