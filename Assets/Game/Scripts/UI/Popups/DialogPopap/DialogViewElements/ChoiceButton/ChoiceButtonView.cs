using R3;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.DialogPopap.DialogViewElements.ChoiceButton
{
    public class ChoiceButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private Button _button;
        [SerializeField] private Color _notAvailableButtonColor;

        private Subject<ChoiceButtonViewModel> _madeChoice = new();
        private ChoiceButtonViewModel _viewModel;
        
        public Observable<ChoiceButtonViewModel> Bind(ChoiceButtonViewModel viewModel)
        {
            _viewModel = viewModel;
            
            if (_viewModel.IsAvailable)
            {
                _buttonText.text = _viewModel.ChoiceText;
                _button.image.color = _viewModel.Color;
                _button.onClick.AddListener(ChoiceButtonClicked);
            }
            else
            {
                _buttonText.text = "ВЫБОР НЕ ДОСТУПЕН:  " + _viewModel.ChoiceText;
                _button.image.color = _notAvailableButtonColor;
            }

            Observable<ChoiceButtonViewModel> obs = _madeChoice;
            return obs;
        }

        private void ChoiceButtonClicked()
        {
            _madeChoice.OnNext(_viewModel);
        }
    }
}