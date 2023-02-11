using UnityEngine.UI;

namespace Development.RimuruDev.WarspearOnline
{
    public sealed class CurrencyRateModel
    {
        public Text CurrentRateText => currentRateText; // TODO: Add a setter to update by event.
        private readonly Text currentRateText = null;

        public Button ApplyRateButton => applyRateButton;
        private readonly Button applyRateButton = null;

        public InputField UserRateInputField => userRateInputField;
        private readonly InputField userRateInputField = null;

        public CurrencyConverterView[] CurrencyConverterView => currencyConverterView;
        private readonly CurrencyConverterView[] currencyConverterView = null;

        public CurrencyRateModel(Text currentRateText, Button applyRateButton, InputField userRateInputField, CurrencyConverterView[] currencyConverterView)
        {
            this.currentRateText = currentRateText;
            this.applyRateButton = applyRateButton;
            this.userRateInputField = userRateInputField;
            this.currencyConverterView = currencyConverterView;
        }
    }
}