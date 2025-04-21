using System;
using R3;

namespace Game.Scripts.DialogMechanics
{
    public class DialogManager
    {
        public ReadOnlyReactiveProperty<Dialog> Dialog => _dialog;

        public Action GetNextStoryRequest {
            private get { return _getNextStoryRequest;}
            set { _getNextStoryRequest = value; }
        }

        public string EndKey { get; private set; }

        private Action _getNextStoryRequest;
        private ReactiveProperty<Dialog> _dialog = new();
        private Story _story;
        private DialogSegment _dialogSegment;
        
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

        public void RegisterChoiceResult(Choice choiceMade)
        {
            _dialogSegment.NextId = choiceMade.NextSegmentId;
        }

        private void GoToNextSegment()
        {
            if (_dialogSegment.IsEnd)
            {
                EndKey = _dialogSegment.EndKey;
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