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
        public override string PrefabName => "DialogPopup";
        public ReadOnlyReactiveProperty<string> CurrentDialogText => _currentDialogText;
        public ReadOnlyReactiveProperty<string> CurrentSpeakerName => _currentSpeakerName;
        public ReadOnlyReactiveProperty<bool> ChoiceIsActive => _choiceIsActive;
        public ReadOnlyReactiveProperty<string> PositiveChoiceText => _positiveChoiceText;
        public ReadOnlyReactiveProperty<string> NegativeChoiceText => _negativeChoiceText;

        private ReactiveProperty<string> _currentDialogText = new();
        private ReactiveProperty<string> _currentSpeakerName = new();
        private ReactiveProperty<bool> _choiceIsActive = new(false);
        private ReactiveProperty<string> _positiveChoiceText = new();
        private ReactiveProperty<string> _negativeChoiceText = new();

        private int _dialogIndex = 0;

        private DialogManager _dialogManager;

        public DialogViewModel()
        {
            
        }

        public void InitDialogManager(DialogManager dialogManager)
        {
            _dialogManager = dialogManager;
            _dialogManager.StartDialog();
            
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
            
            _dialogManager.SendChoiceResult(moodType);
        }

        private void BuildDialog(Dialog dialog)
        {
            _currentDialogText.Value = dialog.Text;
            _currentSpeakerName.Value = dialog.SpeakerName;
        }

        private void BuildChoice(Dialog dialog)
        {
            Choice[] choicesInf = dialog.Choices;
            Choice negativeChoice = choicesInf.FirstOrDefault(e => e.Mood == DialogMood.Negative);
            Choice positiveChoice = choicesInf.FirstOrDefault(e => e.Mood == DialogMood.Positive);

            _positiveChoiceText.Value = positiveChoice.Text;
            _negativeChoiceText.Value = negativeChoice.Text;

            _choiceIsActive.Value = true;
        }
    }
}