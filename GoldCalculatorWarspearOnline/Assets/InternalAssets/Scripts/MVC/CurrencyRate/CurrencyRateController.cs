using UnityEngine.UI;

namespace Development.RimuruDev.WarspearOnline
{
    public sealed class CurrencyRateController
    {
        private readonly CurrencyRateModel currencyRateModel = null;

        public CurrencyRateController(Text currentRateText, Button applyRateButton, InputField userRateInputField, CurrencyConverterView[] currencyConverterView)
        {
            currencyRateModel = new(currentRateText, applyRateButton, userRateInputField, currencyConverterView);

            SubscribeToButton();
        }

        ~CurrencyRateController() => UnsubscribeToButton();

        public void ApplyNewCurrencyRate()
        {
            // TODO: Added check for 0 and division
            if (double.TryParse(currencyRateModel.UserRateInputField.text, out double result))
            {
                // TODO: Add -> Notify about the new value. Pattern: Notify
                for (int i = 0; i < currencyRateModel.CurrencyConverterView.Length; i++)
                    currencyRateModel.CurrencyConverterView[i].CurrencyConverterController.SetRate(result);

                currencyRateModel.CurrentRateText.text = $"{result} per 1000 gold";
            }
        }

        private void SubscribeToButton() => currencyRateModel.ApplyRateButton.onClick.AddListener(delegate { ApplyNewCurrencyRate(); });

        private void UnsubscribeToButton() => currencyRateModel.ApplyRateButton.onClick.RemoveAllListeners();
    }
}