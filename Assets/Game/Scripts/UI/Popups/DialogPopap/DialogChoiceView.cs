using System;
using Game.Scripts.DialogMechanics;
using Game.Scripts.UI.MVVM;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.DialogPopap
{
    public class DialogChoiceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _firstTextField;
        [SerializeField] private TextMeshProUGUI _secondTextField;
        [SerializeField] private Button _firstButton;
        [SerializeField] private Button _secondButton;

        private DialogViewModel _viewModel;

        private CompositeDisposable _compositeDisposable = new CompositeDisposable();
        
        public void Init(DialogViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void BuildChoiceView()
        {
            _firstButton.image.color = _viewModel.FirstChoiceModel.Color;
            _firstTextField.text = _viewModel.FirstChoiceModel.ChoiceText;
            _firstButton.onClick.AddListener(FirstButtonClicked);

            _secondButton.image.color = _viewModel.SecondChoiceModel.Color;
            _secondTextField.text = _viewModel.SecondChoiceModel.ChoiceText;
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
            _viewModel.ChoiceIsMade(_viewModel.FirstChoiceModel.MoodType);
            _viewModel.NextDialog();
        }

        private void SecondButtonClicked()
        {
            _viewModel.ChoiceIsMade(_viewModel.SecondChoiceModel.MoodType);
            _viewModel.NextDialog();
        }

        public void OnUnBindViewModel()
        {
            _compositeDisposable.Dispose();
        }
    }
}