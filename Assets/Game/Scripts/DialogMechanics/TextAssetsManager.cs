using System;
using System.IO;
using System.Xml.Serialization;
using Game.Scripts.DialogData;
using Game.Scripts.DialogMechanics.EndManagers;
using Game.Scripts.PlayerStatMechanics;
using Game.Scripts.UI.Popups.DialogPopap.DialogViewElements;
using Game.Scripts.UI.Popups.DialogPopap.DialogViewElements.ChoiceButton;
using UnityEngine;

namespace Game.Scripts.DialogMechanics
{
    public class TextAssetsManager
    {
        private int _textAssetsCount;
        private int _index;

        private readonly DialogManager _dialogManager;
        private readonly EndingManager _endingManager;
        private readonly PlayerStatsManager _statsManager;
        private DialogDataObject _dialogData;

        public TextAssetsManager(EndingManager endingManager, PlayerStatsManager statsManager, DialogManager dialogManager)
        {
            _endingManager = endingManager;
            _statsManager = statsManager;
            _dialogManager = dialogManager;

            ChoiceButtonViewModel.PlayerStatsManager = _statsManager;
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
            _statsManager.ResetStats();
            
            RunNextStory();
        }

        public void RegisterChoiceResult(Choice choiceMade)
        {
            if (choiceMade.Consequences != null)
            {
                foreach (Consequence consequence in choiceMade.Consequences)
                {
                    _statsManager.ChangeStat(consequence.Stat, consequence.ValueString);
                }
            }
            
            _dialogManager.RegisterChoiceResult(choiceMade);
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
                story = Deserialize(_endingManager.GetDefineEnding(_dialogManager.EndKey));
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