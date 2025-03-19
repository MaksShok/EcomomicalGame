using System;
using System.Collections.Generic;
using Game.Scripts.DialogDataParams;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Popups.DialogPopap.DialogViewElements
{
    public class DialogImageView : MonoBehaviour
    {
        [SerializeField] 
        private Image _dialogImage;

        private DialogViewModel _viewModel;
        private IDisposable _spriteSubscription;

        public void Init(DialogViewModel viewModel)
        {
            _viewModel = viewModel;
            _spriteSubscription = _viewModel.Sprite.Subscribe(sprite => SetImage(sprite));
        }

        public void SetImage(Sprite sprite)
        {
            _dialogImage.sprite = sprite;
        }

        public void BuildImageView()
        {
            gameObject.SetActive(true);
        }

        public void DestroyImageView()
        {
            gameObject.SetActive(false);
        }

        public void OnUnBindViewModel()
        {
            _spriteSubscription.Dispose();
        }
    }
}