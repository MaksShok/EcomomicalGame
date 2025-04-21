using System;
using Game.Scripts.DialogData;
using Game.Scripts.UI.Popups.DialogFinishPopup;
using UnityEngine;

namespace Game.Scripts.DialogMechanics.EndManagers
{
    public abstract class EndingManager
    {
        public event Action StoriesEnd;
        
        protected DialogDataObject DialogData;
        protected LevelFinishViewModelAbstract LevelFinishViewModel;
        protected bool IsVictory;

        public abstract TextAsset GetDefineEnding(string endKey = default);
        
        public void InitDialogData(DialogDataObject dialogData) 
            => DialogData = dialogData;
        
        public virtual void End()
        {
            if (IsVictory)
                Debug.Log("Victory");
            else
                Debug.Log("looze");
            
            StoriesEnd?.Invoke();
        }

        public void StopDialog()
        {
            StoriesEnd?.Invoke();
            StoriesEnd = null;
            LevelFinishViewModel?.CloseRequest();
        }

        protected virtual void OnStoriesEnd()
        {
            StoriesEnd?.Invoke();
        }
    }
}