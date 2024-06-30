using MyGame.Core.DI;
using UnityEngine;
using UnityEngine.UI;
using MyGame.Core.Services;
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

        public void Initialize(ServiceContainer serviceContainer, GameObject firstDice, GameObject secondDice)
        {
            _firstDice = firstDice;
            _secondDice = secondDice;
            _diceAnimationService = serviceContainer.Resolve<IDiceAnimationService>();
            _rollButton.onClick.AddListener(OnRollButtonClicked);
        }

        private void OnRollButtonClicked()
        {
            if (!IsValidDiceValue(_dice1InputField.text) || !IsValidDiceValue(_dice2InputField.text))
            {
                return;
            }

            int dice1Value = int.Parse(_dice1InputField.text);
            int dice2Value = int.Parse(_dice2InputField.text);

            _diceAnimationService.PlayAnimation(dice1Value, _firstDice);
            _diceAnimationService.PlayAnimation(dice2Value, _secondDice);
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