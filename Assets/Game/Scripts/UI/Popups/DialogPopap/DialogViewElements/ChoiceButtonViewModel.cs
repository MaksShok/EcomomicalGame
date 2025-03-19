using Game.Scripts.DialogMechanics;
using UnityEngine;

namespace Game.Scripts.UI.Popups.DialogPopap.DialogViewElements
{
    public class ChoiceButtonViewModel
    {
        public string ChoiceText;
        public Color Color;
        public DialogMood MoodType;

        public ChoiceButtonViewModel(Choice choice)
        {
            ChoiceText = choice.Text;
            MoodType = choice.Mood;
            if (MoodType == DialogMood.Negative)
            {
                Color = GetColorForRGB(233, 80, 58); // красный
            }
            else if (MoodType == DialogMood.Positive)
            {
                Color = GetColorForRGB(133, 233, 78); // зеленый
            }
            else if (MoodType != DialogMood.None)
            {
                Color = GetColorForRGB(255, 255, 153); // Светлый нейтральный
            }
        }

        private Color GetColorForRGB(float r, float g, float b)
        {
            return new Color(r / 255, g / 255, b / 255);
        }
    }
}