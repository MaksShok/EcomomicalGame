using System;
using UnityEngine;

namespace Game.Scripts.DialogData
{
    [Serializable]
    public class SpriteIndicator
    {
        [SerializeField] public Sprite Sprite;
        [SerializeField] public string SpriteId;
    }
}