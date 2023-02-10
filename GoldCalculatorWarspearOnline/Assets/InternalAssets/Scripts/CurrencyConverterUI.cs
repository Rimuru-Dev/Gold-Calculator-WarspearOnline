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
        [SerializeField] private string currency;

        private InputField userInputField = null;
        private Text resultText = null;
        private CurrencyConverterController currencyConverterController = null;

        private void Awake()
        {
            userInputField = GetComponentInChildren<InputField>();
            resultText = GetComponentInChildren<ResultTextTag>().GetComponent<Text>();

            currencyConverterController = new(userInputField, resultText, currency);
        }

        private void Update()
        {
            currencyConverterController.Update();
        }
    }

    public sealed class CurrencyConverterController
    {
        private readonly InputField userInputField = null;
        private readonly Text resultText = null;
        private readonly string currency;

        public CurrencyConverterController(InputField userInputField, Text resultText, string currency)
        {
            this.userInputField = userInputField;
            this.resultText = resultText;
            this.currency = currency;

            InitialText();
        }

        public void Update()
        {

        }

        private void InitialText()
        {
            resultText.text = $"0 {currency}";
        }
    }
}