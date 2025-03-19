using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using R3;
using UnityEngine;

namespace Game.Scripts.DialogMechanics
{
    public class DialogManager
    {
        public ReadOnlyReactiveProperty<Dialog> Dialog => _dialog;

        public Action GetNextStoryRequest
        {
            private get { return _getNextStoryRequest;}
            set { _getNextStoryRequest = value; }
        }

        private Action _getNextStoryRequest;
        
        private Story _story;
        private DialogSegment _dialogSegment;
        private ReactiveProperty<Dialog> _dialog = new();

        private int _segmentId;
        private int _dialogId;
        private int _lastDialogIdInSegment;

        public void StartStory(Story story)
        {
            _dialogId = 0;
            _segmentId = 0;
            
            _story = story;
            _dialogSegment = _story.DialogSegments[0];
            _lastDialogIdInSegment = _dialogSegment.Dialogs.Length - 1;

            UpdateDialog();
        }

        public void UpdateDialog()
        {
            if (_dialogId > _lastDialogIdInSegment)
            {
                GoToNextSegment();
                return;
            }
            
            _dialog.Value = _dialogSegment.Dialogs[_dialogId];
            _dialogId++;
        }

        public void RegisterChoiceResult(DialogMood moodType)
        {
            Choice choiceMade = _dialog.Value.Choices.FirstOrDefault(e => e.Mood == moodType);
            _dialogSegment.NextId = choiceMade.NextSegmentId;
        }

        private void GoToNextSegment()
        {
            if (_dialogSegment.IsEnd)
            {
                GetNextStoryRequest.Invoke();
                return;
            }
            
            _segmentId = _dialogSegment.NextId;
            _dialogSegment = _story.DialogSegments[_segmentId];
                
            _dialogId = 0;
            _lastDialogIdInSegment = _dialogSegment.Dialogs.Length - 1;
            
            UpdateDialog();
        }
    }
}