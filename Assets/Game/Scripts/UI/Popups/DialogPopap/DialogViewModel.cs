using System;
using System.Collections.Generic;
using Game.Scripts.DialogData;
using Game.Scripts.DialogMechanics;
using Game.Scripts.UI.MVVM;
using Game.Scripts.UI.Popups.DialogPopap.DialogViewElements;
using Game.Scripts.UI.Popups.DialogPopap.DialogViewElements.ChoiceButton;
using R3;
using UnityEngine;

namespace Game.Scripts.UI.Popups.DialogPopap
{
    public class DialogViewModel : ViewModel
    {
        public override string PrefabName => "DialogView";
        
        public List<ChoiceButtonViewModel> ChoiceModelsList = new();
        
        public Observable<string> CurrentDialogText => _currentDialogText;
        public Observable<string> CurrentSpeakerName => _currentSpeakerName;
        public Observable<Sprite> Sprite => _sprite;
        public ReadOnlyReactiveProperty<bool> ChoiceIsActive => _choiceIsActive;

        private ReactiveProperty<string> _currentDialogText = new();
        private ReactiveProperty<string> _currentSpeakerName = new();
        private ReactiveProperty<Sprite> _sprite = new();
        private ReactiveProperty<bool> _choiceIsActive = new(false);
        
        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        private DialogManager _dialogManager;
        private TextAssetsManager _textAssetsManager;
        private Dictionary<string, Sprite> _spritesDict;
        
        public DialogViewModel(TextAssetsManager textAssetsManager, DialogManager dialogManager ,DialogDataObject dialogData)
        {
            _textAssetsManager = textAssetsManager;
            _dialogManager = dialogManager;
            _spritesDict = dialogData.SpritesDict;

            _textAssetsManager.StartFromFirstStory();
            
            _compositeDisposable.Add(_dialogManager.Dialog.Subscribe(e => BuildDialog(e)));
        }

        public void NextDialog()
        {
            _dialogManager.UpdateDialog();
        }

        public void ChoiceIsMade(ChoiceButtonViewModel choiceButtonViewModel)
        {
            _choiceIsActive.OnNext(false);
            _textAssetsManager.RegisterChoiceResult(choiceButtonViewModel.Choice);
            
            NextDialog();
        }

        private void BuildDialog(Dialog dialog)
        {
            _currentDialogText.OnNext(dialog.Text);
            _currentSpeakerName.OnNext(dialog.SpeakerName);
            
            if (dialog.WithChoice)
            {
               BuildChoice(dialog); 
            }
            else
            {
                _choiceIsActive.OnNext(false);
            }
            
            if (dialog.SpriteId != null && 
                _spritesDict.TryGetValue(dialog.SpriteId, out Sprite sprite))
            {
                _sprite.OnNext(sprite); 
            }
        }

        private void BuildChoice(Dialog dialog)
        {
            ChoiceModelsList.Clear();
            
            foreach (Choice choice in dialog.Choices)
            {
                ChoiceModelsList.Add(new ChoiceButtonViewModel(choice));
            }

            _choiceIsActive.OnNext(true);
        }

        public override void Dispose()
        {
           _compositeDisposable.Dispose();
        }
    }
}