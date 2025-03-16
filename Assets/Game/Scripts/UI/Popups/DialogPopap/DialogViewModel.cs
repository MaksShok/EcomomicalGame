using System;
using System.Linq;
using System.Runtime.InteropServices;
using Game.Scripts.DialogMechanics;
using Game.Scripts.UI.MVVM;
using R3;
using UnityEngine;

namespace Game.Scripts.UI.Popups.DialogPopap
{
    public class DialogViewModel : ViewModel
    {
        public override string PrefabName => "DialogView";
        public ReadOnlyReactiveProperty<string> CurrentDialogText => _currentDialogText;
        public ReadOnlyReactiveProperty<string> CurrentSpeakerName => _currentSpeakerName;
        public ReadOnlyReactiveProperty<bool> ChoiceIsActive => _choiceIsActive;

        public ChoiceButtonViewModel FirstChoiceModel;
        public ChoiceButtonViewModel SecondChoiceModel;
        
        private ReactiveProperty<string> _currentDialogText = new();
        private ReactiveProperty<string> _currentSpeakerName = new();
        private ReactiveProperty<bool> _choiceIsActive = new(false);
        
        private int _dialogIndex = 0;

        private DialogManager _dialogManager;
        private TextAssetsManager _textAssetsManager;

        // Эту логику нужно перенести в Конструктор наверное
        public void InitTextAssetManager(TextAssetsManager textAssetsManager)
        {
            _textAssetsManager = textAssetsManager;
            _dialogManager = _textAssetsManager.DialogManager;
            
            _textAssetsManager.StartFromFirstStory();
            
            _dialogManager.Dialog.Subscribe(e => BuildDialog(e));
            _dialogManager.Dialog.Where(dialog => dialog.WithChoice)
                .Subscribe(e => BuildChoice(e));
        }

        public void NextDialog()
        {
            _dialogManager.UpdateDialog();
        }

        public void ChoiceIsMade(DialogMood moodType)
        {
            _choiceIsActive.Value = false;
            _textAssetsManager.RegisterChoiceResult(moodType);
        }

        private void BuildDialog(Dialog dialog)
        {
            _currentDialogText.Value = dialog.Text;
            _currentSpeakerName.Value = dialog.SpeakerName;
        }

        private void BuildChoice(Dialog dialog)
        {
            Choice[] choicesInf = dialog.Choices;

            FirstChoiceModel = new ChoiceButtonViewModel(choicesInf[0]);
            SecondChoiceModel = new ChoiceButtonViewModel(choicesInf[1]);

            _choiceIsActive.Value = true;
        }
    }
}