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
        public static event Action OnStoryEnd;

        public ReadOnlyReactiveProperty<Dialog> Dialog => _dialog;

        private Story _story;
        private DialogSegment _dialogSegment;
        private ReactiveProperty<Dialog> _dialog = new();

        private int _segmentId;
        private int _dialogId;
        private int _lastDialogIdInSegment;
        
        public DialogManager(string pathToDialogFile)
        {
            _story = Deserialize<Story>(pathToDialogFile);
        }

        public void StartDialog()
        {
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

        public void SendChoiceResult(DialogMood moodType)
        {
            Choice choiceMade = _dialog.Value.Choices.FirstOrDefault(e => e.Mood == moodType);
            _dialogSegment.NextId = choiceMade.NextSegmentId;
        }

        private void GoToNextSegment()
        {
            if (_dialogSegment.IsEnd)
            {
                OnStoryEnd?.Invoke();
                return;
            }
            
            _segmentId = _dialogSegment.NextId;
            _dialogSegment = _story.DialogSegments[_segmentId];
                
            _dialogId = 0;
            _lastDialogIdInSegment = _dialogSegment.Dialogs.Length - 1;
            
            UpdateDialog();
        }

        private T Deserialize<T>(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            TextAsset asset = Resources.Load<TextAsset>(path);
            StringReader reader = new StringReader(asset.text);
            T obj = (T)xmlSerializer.Deserialize(reader);
            reader.Close();
            return obj;
        }
    }
}