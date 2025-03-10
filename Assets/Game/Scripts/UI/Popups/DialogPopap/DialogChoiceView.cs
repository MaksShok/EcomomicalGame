using System;
using Game.Scripts.DialogMechanics;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.DialogPopap
{
    public class DialogChoiceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _positiveTextField;
        [SerializeField] private TextMeshProUGUI _negativeTextField;
        [SerializeField] private Button _negativeButton;
        [SerializeField] private Button _positiveButton;

        private DialogViewModel _viewModel;

        private CompositeDisposable _compositeDisposable = new CompositeDisposable();
        
        public void Init(DialogViewModel viewModel)
        {
            _viewModel = viewModel;
            
            _compositeDisposable.Add(_viewModel.PositiveChoiceText
                .Subscribe(text => _positiveTextField.text = text));
            _compositeDisposable.Add(_viewModel.NegativeChoiceText
                .Subscribe(text => _negativeTextField.text = text));
        }

        public void BuildChoiceView()
        {
            _negativeButton.onClick.AddListener(NegativeButtonClicked);
            _positiveButton.onClick.AddListener(PositiveButtonClicked);
            
            gameObject.SetActive(true);
        }

        public void DestroyChoiceView()
        {
            _positiveTextField.text = String.Empty;
            _negativeTextField.text = String.Empty;
            
            _negativeButton.onClick.RemoveListener(NegativeButtonClicked);
            _positiveButton.onClick.RemoveListener(PositiveButtonClicked);
            
            gameObject.SetActive(false);
        }

        private void NegativeButtonClicked()
        {
            _viewModel.ChoiceIsMade(DialogMood.Negative);
            _viewModel.NextDialog();
        }

        private void PositiveButtonClicked()
        {
            _viewModel.ChoiceIsMade(DialogMood.Positive);
            _viewModel.NextDialog();
        }

        public void OnUnBindViewModel()
        {
            _compositeDisposable.Dispose();
        }
    }
}