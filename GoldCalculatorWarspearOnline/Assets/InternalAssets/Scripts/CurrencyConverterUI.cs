// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Project: Infinity Dead
//   Contact me: rimuru.dev@gmail.com
//
// **************************************************************** //

using UnityEngine;
using UnityEngine.UI;

namespace Development.RimuruDev.WarspearOnline
{
    public sealed class CurrencyConverterUI : MonoBehaviour
    {
        [SerializeField] private CurrencyType currency;

        private Button button = null;
        private Text resultText = null;
        private InputField userInputField = null;
        private CurrencyConverterController currencyConverterController = null;

        private void Awake()
        {
            button = GetComponentInChildren<Button>();
            userInputField = GetComponentInChildren<InputField>();
            resultText = GetComponentInChildren<ResultTextTag>().GetComponent<Text>();

            currencyConverterController = new(userInputField, resultText, currency, button);
        }

        public void Convertation() => currencyConverterController?.CalculateCurrancyConvertation(currency);
    }
}