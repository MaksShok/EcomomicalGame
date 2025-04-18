using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.DialogPopap.DialogViewElements
{
    public class DialogChoiceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _firstTextField;
        [SerializeField] private TextMeshProUGUI _secondTextField;
        [SerializeField] private Button _firstButton;
        [SerializeField] private Button _secondButton;

        private DialogViewModel _viewModel;
        
        public void Init(DialogViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void BuildChoiceView()
        {
            _firstButton.image.color = _viewModel.FirstChoiceModel.Color;
            _firstTextField.text = _viewModel.FirstChoiceModel.ChoiceText;
            if (_viewModel.FirstChoiceModel.IsAvailable)
                _firstButton.onClick.AddListener(FirstButtonClicked);
            
            _secondButton.image.color = _viewModel.SecondChoiceModel.Color;
            _secondTextField.text = _viewModel.SecondChoiceModel.ChoiceText;
            if (_viewModel.SecondChoiceModel.IsAvailable)
                _secondButton.onClick.AddListener(SecondButtonClicked);

            gameObject.SetActive(true);
        }

        public void DestroyChoiceView()
        {
            _firstButton.onClick.RemoveListener(FirstButtonClicked);
            _secondButton.onClick.RemoveListener(SecondButtonClicked);

            gameObject.SetActive(false);
        }

        private void FirstButtonClicked()
        {
            _viewModel.ChoiceIsMade(_viewModel.FirstChoiceModel);
        }

        private void SecondButtonClicked()
        {
            _viewModel.ChoiceIsMade(_viewModel.SecondChoiceModel);
        }

        public void OnUnBindViewModel()
        {
            _firstButton.onClick.RemoveListener(FirstButtonClicked);
            _secondButton.onClick.RemoveListener(SecondButtonClicked);
        }
    }
}