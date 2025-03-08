using System;
using System.Security.Cryptography;
using Game.Scripts.DialogMechanics;
using Game.Scripts.UI.Popups.DialogPopap;
using UnityEngine;

namespace Game
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private DialogView _dialogView;
        
        private DialogManager _dialogManager;
        private DialogViewModel _viewModel;
        
        private void Start()
        {
            _dialogManager = new DialogManager("Data/XMLDialogs/TestDialogData");
            _viewModel = new DialogViewModel();
            DialogManager.OnStoryEnd += () => Destroy(_dialogView.gameObject);

            _dialogView.Bind(_viewModel);
            _viewModel.InitDialogManager(_dialogManager);
            
        }
    }
}