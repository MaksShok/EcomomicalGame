using System;
using System.Collections.Generic;
using Game.Scripts.DialogData;
using Game.Scripts.DialogMechanics;
using Game.Scripts.UI.MVVM;
using Game.Scripts.UI.Popups.DialogPopap.DialogViewElements;
using R3;
using UnityEngine;

namespace Game.Scripts.UI.Popups.DialogPopap
{
    public class DialogViewModel : ViewModel
    {
        public override string PrefabName => "DialogView";
        
        public ChoiceButtonViewModel FirstChoiceModel;
        public ChoiceButtonViewModel SecondChoiceModel;
        
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
        
        public DialogViewModel(TextAssetsManager textAssetsManager)
        {
            _textAssetsManager = textAssetsManager;
            _spritesDict = textAssetsManager.DialogData.SpritesDict;
            _dialogManager = _textAssetsManager.DialogManager;

            _textAssetsManager.StartFromFirstStory();
            
            _compositeDisposable.Add(_dialogManager.Dialog.Subscribe(e => BuildDialog(e)));
        }

        public void NextDialog()
        {
            _dialogManager.UpdateDialog();
        }

        public void ChoiceIsMade(ChoiceMood moodType)
        {
            _choiceIsActive.Value = false;
            _textAssetsManager.RegisterChoiceResult(moodType);
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
            Choice[] choicesInf = dialog.Choices;

            FirstChoiceModel = new ChoiceButtonViewModel(choicesInf[0]);
            SecondChoiceModel = new ChoiceButtonViewModel(choicesInf[1]);

            _choiceIsActive.OnNext(true);
        }

        public override void Dispose()
        {
           _compositeDisposable.Dispose();
        }
    }
}