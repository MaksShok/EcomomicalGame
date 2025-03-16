using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Game.Scripts.DialogMechanics;
using Game.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.LevelEnterParams
{
    [CreateAssetMenu(fileName = "LevelEnterParamsObject", menuName = "ScriptableObject/" + "LevelEnterParamsObject")]
    public class LevelEnterParamsObject : ScriptableObject
    {
        [SerializeField] public List<TextAsset> defaultTextAssets;
        [SerializeField] public TextAsset negativeEndingTextAsset;
        [SerializeField] public TextAsset positiveEndingTextAsset;
    }
}