using System;
using System.Collections.Generic;
using Game.Scripts.UI.Popups.DialogPopap.DialogViewElements.ChoiceButton;
using R3;
using UnityEngine;

namespace Game.Scripts.UI.Popups.DialogPopap.DialogViewElements
{
    public class DialogChoiceView : MonoBehaviour
    {
        [SerializeField] private ChoiceButtonView _buttonPrefab;
        [SerializeField] private Transform _rootTransform;
        
        private List<ChoiceButtonView> _instantiatedButtonsList = new();
        private DialogViewModel _viewModel;
        
        public void Init(DialogViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void BuildChoiceView()
        {
            foreach (ChoiceButtonViewModel viewModel in _viewModel.ChoiceModelsList)
            {
                ChoiceButtonView choiceButtonView = Instantiate(_buttonPrefab, _rootTransform);
                choiceButtonView.Bind(viewModel).Subscribe(model
                    => TransferChoiceResult(model));
                
                _instantiatedButtonsList.Add(choiceButtonView);
            }

            gameObject.SetActive(true);
        }

        public void DestroyChoiceView()
        {
            foreach (ChoiceButtonView buttonView in _instantiatedButtonsList)
            {
                Destroy(buttonView.gameObject);
            }
            
            _instantiatedButtonsList.Clear();
            gameObject.SetActive(false);
        }
        
        private void TransferChoiceResult(ChoiceButtonViewModel choiceButtonViewModel)
        {
            _viewModel.ChoiceIsMade(choiceButtonViewModel);
        }

        public void OnUnBindViewModel()
        {
            foreach (ChoiceButtonView buttonView in _instantiatedButtonsList)
            {
                Destroy(buttonView.gameObject);
            }
            
            _instantiatedButtonsList.Clear();
        }
    }
}