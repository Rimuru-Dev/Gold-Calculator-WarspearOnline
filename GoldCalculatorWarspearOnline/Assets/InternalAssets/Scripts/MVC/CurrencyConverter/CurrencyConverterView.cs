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
    public sealed class CurrencyConverterView : MonoBehaviour
    {
        [SerializeField] private CurrencyType currency;
        public CurrencyConverterController CurrencyConverterController { get; private set; }

        private void Awake()
        {
            Button button = GetComponentInChildren<Button>();
            InputField userInputField = GetComponentInChildren<InputField>();
            Text resultText = GetComponentInChildren<ResultTextTag>().GetComponent<Text>();

            CurrencyConverterController = new(userInputField, resultText, currency, button);
        }
    }
}