using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.DialogDataParams
{
    [CreateAssetMenu(fileName = "DialogDataObject", menuName = "ScriptableObject/" + "DialogDataObject")]
    public class DialogDataObject : ScriptableObject
    {
        [SerializeField] public List<TextAsset> defaultTextAssets;
        [SerializeField] public TextAsset negativeEndingTextAsset;
        [SerializeField] public TextAsset positiveEndingTextAsset;

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
    }
}