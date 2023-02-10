// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Project: Gold Calculator WarspearOnline
//   Contact me: rimuru.dev@gmail.com
//
// **************************************************************** //

using UnityEngine.UI;

namespace Development.RimuruDev.WarspearOnline
{
    public sealed class CurrencyConverterModel
    {
        public CurrencyType Currency => currency;
        private readonly CurrencyType currency;

        public Text ResultText => resultText;   // TODO: Add a setter to update by event.
        private readonly Text resultText = null;

        public Button Button => button;
        private readonly Button button = null;

        public InputField UserInputField => userInputField;
        private readonly InputField userInputField = null;

        public CurrencyConverterModel(InputField userInputField, Text resultText, CurrencyType currency, Button button)
        {
            this.button = button;
            this.currency = currency;
            this.resultText = resultText;
            this.userInputField = userInputField;
        }
    }
}