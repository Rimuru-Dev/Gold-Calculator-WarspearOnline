// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Project: Gold Calculator WarspearOnline
//   Contact me: rimuru.dev@gmail.com
//
// **************************************************************** //

using UnityEngine;
using UnityEngine.UI;

namespace Development.RimuruDev.WarspearOnline
{
    public sealed class CurrencyRateView : MonoBehaviour
    {
        public CurrencyRateController CurrencyRateController { get; private set; }

        private void Awake()
        {
            Button applyRateButton = GetComponentInChildren<Button>();
            InputField userRateInputField = GetComponentInChildren<InputField>();
            Text currentRateText = GetComponentInChildren<ResultTextTag>().GetComponent<Text>();
            CurrencyConverterView[] currencysConverterView = FindObjectsOfType<CurrencyConverterView>(true);

            CurrencyRateController = new(currentRateText, applyRateButton, userRateInputField, currencysConverterView);
        }
    }
}