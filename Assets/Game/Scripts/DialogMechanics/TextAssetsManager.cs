using System;
using System.IO;
using System.Xml.Serialization;
using Game.Scripts.DialogData;
using UnityEngine;

namespace Game.Scripts.DialogMechanics
{
    public class TextAssetsManager
    {
        public DialogManager DialogManager
        {
            get { return _dialogManager; }
            private set { }
        }
        
        public DialogDataObject DialogData
        {
            get { return _dialogData; }
            private set { }
        }

        private int _textAssetsCount;
        private int _index;

        private DialogDataObject _dialogData;
        private readonly DialogManager _dialogManager;
        private readonly EndingStoryManager _endingManager;

        public TextAssetsManager(EndingStoryManager endingManager)
        {
            _dialogManager = new DialogManager();
            _endingManager = endingManager;
        }

        public void InitDialogData(DialogDataObject dialogData)
        {
            _dialogData = dialogData;
            _endingManager.InitDialogData(_dialogData);
            
            _textAssetsCount = _dialogData.defaultTextAssets.Count + 1;
            _dialogManager.GetNextStoryRequest = RunNextStory;
        }

        public void StartFromFirstStory()
        {
            _index = 0;
            _endingManager.ResetCoefficient();
            
            RunNextStory();
        }

        public void RegisterChoiceResult(ChoiceMood moodType)
        {
            _endingManager.RegisterChoiceResult(moodType);
            _dialogManager.RegisterChoiceResult(moodType);
        }

        private void RunNextStory()
        {
            Story story;
            
            if (_index < _textAssetsCount - 1)
            {
                story = Deserialize(_dialogData.defaultTextAssets[_index]);
            }
            else if (_index == _textAssetsCount - 1)
            {
                story = Deserialize(_endingManager.GetDefineEnding());
            }
            else
            {
                _dialogManager.GetNextStoryRequest = null;
                _endingManager.End();
                return; 
            }
            
            _dialogManager.StartStory(story);
            _index++;
        }

        private Story Deserialize(TextAsset asset)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Story));
            StringReader reader = new StringReader(asset.text);
            Story obj = (Story)xmlSerializer.Deserialize(reader);
            reader.Close();
            return obj;
        }
    }
}