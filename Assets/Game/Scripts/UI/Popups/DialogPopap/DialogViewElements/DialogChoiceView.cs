using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.DialogPopap.DialogViewElements
{
    public class DialogChoiceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _firstTextField;
        [SerializeField] private TextMeshProUGUI _secondTextField;
        [SerializeField] private TextMeshProUGUI _thirdTextField;
        [SerializeField] private Button _firstButton;
        [SerializeField] private Button _secondButton;
        [SerializeField] private Button _thirdButton;

        private DialogViewModel _viewModel;
        
        public void Init(DialogViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void BuildChoiceView()
        {
            ChoiceButtonViewModel firstButtonViewModel = _viewModel.ChoiceModelsArray[0];
            BuildChoiceButton(_firstButton, _firstTextField, firstButtonViewModel, FirstButtonClicked);

            ChoiceButtonViewModel secondButtonViewModel = _viewModel.ChoiceModelsArray[1];
            BuildChoiceButton(_secondButton, _secondTextField, secondButtonViewModel, SecondButtonClicked);

            if (_viewModel.ChoiceModelsArray[2] != null)
            {
                ChoiceButtonViewModel thirdButtonViewModel = _viewModel.ChoiceModelsArray[2];
                BuildChoiceButton(_thirdButton, _thirdTextField, thirdButtonViewModel, ThirdButtonClicked);
            }
            else
            {
                _thirdButton.gameObject.SetActive(false);
            }

            gameObject.SetActive(true);
        }

        public void DestroyChoiceView()
        {
            _firstButton.onClick.RemoveListener(FirstButtonClicked);
            _secondButton.onClick.RemoveListener(SecondButtonClicked);
            _thirdButton.onClick.RemoveListener(ThirdButtonClicked);

            gameObject.SetActive(false);
        }

        private void FirstButtonClicked()
        {
            _viewModel.ChoiceIsMade(_viewModel.ChoiceModelsArray[0]);
        }

        private void SecondButtonClicked()
        {
            _viewModel.ChoiceIsMade(_viewModel.ChoiceModelsArray[1]);
        }

        private void ThirdButtonClicked()
        {
            _viewModel.ChoiceIsMade(_viewModel.ChoiceModelsArray[2]);
        }

        private void BuildChoiceButton(Button button, TextMeshProUGUI text, 
            ChoiceButtonViewModel viewModel, UnityAction onClickAction)
        {
            button.gameObject.SetActive(true);
            button.image.color = viewModel.Color;
            text.text = viewModel.ChoiceText;
            if (viewModel.IsAvailable) 
            {
                button.onClick.AddListener(onClickAction);
            }
            else
            {
                
            }
        }

        public void OnUnBindViewModel()
        {
            _firstButton.onClick.RemoveListener(FirstButtonClicked);
            _secondButton.onClick.RemoveListener(SecondButtonClicked);
            _thirdButton.onClick.RemoveListener(ThirdButtonClicked);
        }
    }
}