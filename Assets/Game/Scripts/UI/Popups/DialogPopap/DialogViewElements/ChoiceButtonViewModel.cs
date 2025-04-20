using Game.Scripts.DialogData;
using Game.Scripts.DialogMechanics;
using Game.Scripts.PlayerStatMechanics;
using UnityEngine;

namespace Game.Scripts.UI.Popups.DialogPopap.DialogViewElements
{
    public class ChoiceButtonViewModel
    {
        public static PlayerStatsManager PlayerStatsManager;

        public Choice Choice;
        public string ChoiceText;
        public Color Color;
        public ChoiceMood MoodType;
        public bool IsAvailable = true;
        
        public ChoiceButtonViewModel(Choice choice)
        {
            Choice = choice;
            ChoiceText = choice.Text;
            MoodType = choice.Mood;
            
            if (Choice.Conditions != null)
                CheckConditions();

            ColorizeButtons();
        }

        private void ColorizeButtons()
        {
            if (MoodType == ChoiceMood.Negative)
            {
                Color = GetColorForRGB(233, 80, 58); // красный
            }
            else if (MoodType == ChoiceMood.Positive)
            {
                Color = GetColorForRGB(133, 233, 78); // зеленый
            }
            // else if (MoodType == ChoiceMood.Refuse)
            // {
            //     Color = GetColorForRGB(255, 107, 26); // оранжевый
            // }
            else if (MoodType != ChoiceMood.None)
            {
                Color = GetColorForRGB(255, 255, 153); // Светлый нейтральный
                //Color = GetColorForRGB(176,162,241); // фиолетовый красивый (хз)
            }
        }

        private Color GetColorForRGB(float r, float g, float b)
        {
            return new Color(r / 255, g / 255, b / 255);
        }

        private void CheckConditions()
        {
            foreach (Condition condition in Choice.Conditions)
            {
                if (!PlayerStatsManager.CheckStat(condition.Stat, condition.MinValue))
                {
                    IsAvailable = false;
                    return;
                }
            }
        }
    }
}