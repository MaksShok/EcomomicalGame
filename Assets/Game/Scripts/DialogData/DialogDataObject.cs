using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.DialogData
{
    [CreateAssetMenu(fileName = "DialogDataObject", menuName = "ScriptableObject/" + "DialogDataObject")]
    public class DialogDataObject : ScriptableObject
    {
        [SerializeField] public List<TextAsset> defaultTextAssets;
        //[SerializeField] public TextAsset negativeEndingTextAsset;
        //[SerializeField] public TextAsset positiveEndingTextAsset;
        
        [SerializeField] private List<EndingData> endingDataList;

        public Dictionary<string, TextAsset> EndingsDict
        {
            get
            {
                if (_endingsDict == null)
                    FillEndingsDict();
                return _endingsDict;
            }
            private set { }
        }

        private Dictionary<string, TextAsset> _endingsDict;

        [SerializeField] private List<SpriteIndicator> spriteIndicators;

        public Dictionary<string, Sprite> SpritesDict {
            get {
                if (_spritesDict == null)
                    FillDict();
                return _spritesDict;
            } 
            private set { }
        }

        private Dictionary<string, Sprite> _spritesDict;

        private void FillDict()
        {
            _spritesDict = new Dictionary<string, Sprite>();
            foreach (SpriteIndicator indicator in spriteIndicators)
            {
                string key = indicator.SpriteId;
                Sprite sprite = indicator.Sprite;
                
                _spritesDict.Add(key, sprite);
            }
        }
        private void FillEndingsDict()
        {
            _endingsDict = new Dictionary<string, TextAsset>();
            foreach (EndingData endingData in endingDataList)
            {
                _endingsDict.Add(endingData.Key, endingData.TextAsset);
            }
        }
    }
}