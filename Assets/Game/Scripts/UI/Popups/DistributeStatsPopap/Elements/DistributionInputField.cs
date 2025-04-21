using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts.UI.Popups.DistributeStatsPopap.Elements
{
    public class DistributionInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;

        private void Start()
        {
            _inputField.onValueChanged.AddListener(ValueChanged);
            _inputField.onEndEdit.AddListener(EndEdit);
        }

        public int GetEnteredValue()
        {
            if (_inputField.text != String.Empty)
            {
                int value = int.Parse(_inputField.text);
                ClearInputField();
                return value;
            }
            else
            {
                return 0;
            }
        }

        private void ValueChanged(string value)
        {
            if (value.Length > 2)
            {
                if (value[0] == '0' || value[0] == '-' || value[0] == '+')
                {
                    _inputField.text = _inputField.text.Substring(1);
                } 
            }
        }

        private void EndEdit(string value)
        {
            if (!IsDigitsOnly(value))
            {
                ClearInputField();
            }
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        public void ClearInputField()
        {
            _inputField.text = String.Empty;
        }
    }
}