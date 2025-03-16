using System;
using System.IO;
using System.Xml.Serialization;
using Game.Scripts.LevelEnterParams;
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

        private int _textAssetsCount;
        private int _index;

        private readonly DialogManager _dialogManager;
        private readonly EndingDialogManager _endingManager;
        private readonly LevelEnterParamsObject _enterParams;

        public TextAssetsManager(EndingDialogManager endingManager, LevelEnterParamsObject enterParams)
        {
            _dialogManager = new DialogManager();
            _endingManager = endingManager;
            _enterParams = enterParams;
            
            _textAssetsCount = _enterParams.defaultTextAssets.Count + 1;
            _dialogManager.GetNextStoryRequest = RunNextStory;
        }

        public void StartFromFirstStory()
        {
            _index = 0;
            _endingManager.ResetCoefficient();
            
            RunNextStory();
        }

        private void RunNextStory()
        {
            Story story;
            
            if (_index < _textAssetsCount - 1)
            {
                story = Deserialize(_enterParams.defaultTextAssets[_index]);
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

        public void RegisterChoiceResult(DialogMood moodType)
        {
            _endingManager.RegisterChoiceResult(moodType);
            _dialogManager.RegisterChoiceResult(moodType);
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