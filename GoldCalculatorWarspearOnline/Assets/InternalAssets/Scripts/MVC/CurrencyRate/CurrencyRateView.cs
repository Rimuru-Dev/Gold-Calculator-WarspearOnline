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

            CurrencyRateController = new(currentRateText, applyRateButton, userRateInputField);
        }
    }

    public sealed class CurrencyRateController
    {
        private readonly CurrencyRateModel currencyRateModel = null;

        public CurrencyRateController(Text currentRateText, Button applyRateButton, InputField userRateInputField)
        {
            currencyRateModel = new(currentRateText, applyRateButton, userRateInputField);

            SubscribeToButton();
            InitDeafaultCurrencyRate();
            InitDeafaultCurrencyRateText();
        }

        ~CurrencyRateController() => UnsubscribeToButton();

        public void ApplyNewCurrencyRate()
        {
            // TODO: Added check for 0 and division
            if (double.TryParse(currencyRateModel.UserRateInputField.text, out double result)) // // TODO: ==> Sender
            {
                // Notify about the new value. Pattern: Notify



                currencyRateModel.CurrentRateText.text = $"{result} per 1000 gold";
            }
        }

        private void InitDeafaultCurrencyRate() => currencyRateModel.CurrentRate = 1.7d; // TODO: Add SO Config for game default values.

        private void InitDeafaultCurrencyRateText() => currencyRateModel.CurrentRateText.text = $"{currencyRateModel.CurrentRate}";

        private void SubscribeToButton() => currencyRateModel.ApplyRateButton.onClick.AddListener(delegate { ApplyNewCurrencyRate(); });

        private void UnsubscribeToButton() => currencyRateModel.ApplyRateButton.onClick.RemoveAllListeners();
    }

    public sealed class CurrencyRateModel
    {
        public Text CurrentRateText => currentRateText; // TODO: Add a setter to update by event.
        private readonly Text currentRateText = null;

        public Button ApplyRateButton => applyRateButton;
        private readonly Button applyRateButton = null;

        public InputField UserRateInputField => userRateInputField;
        private readonly InputField userRateInputField = null;

        public double CurrentRate { get => currentRate; set => currentRate = value; } // TODO: Add protection for the property.
        private double currentRate = 0;

        public CurrencyRateModel(Text currentRateText, Button applyRateButton, InputField userRateInputField)
        {
            this.currentRateText = currentRateText;
            this.applyRateButton = applyRateButton;
            this.userRateInputField = userRateInputField;
        }
    }

    public interface INotify
    {

    }
}