using UnityEngine;
using UnityEngine.UI;

namespace Development.RimuruDev.WarspearOnline
{
    public sealed class CurrencyRateView : MonoBehaviour
    {
        private Text currentRateText = null;
        private Button applyRateButton = null;
        private InputField userRateInputField = null;
        private CurrencyRateController currencyRateController = null;

        private void Awake()
        {
            applyRateButton = GetComponentInChildren<Button>();
            userRateInputField = GetComponentInChildren<InputField>();
            currentRateText = GetComponentInChildren<ResultTextTag>().GetComponent<Text>();

            currencyRateController = new(currentRateText, applyRateButton, userRateInputField);
        }
    }

    public sealed class CurrencyRateController
    {
        private readonly CurrencyRateModel currencyRateModel = null;

        public CurrencyRateController(Text currentRateText, Button applyRateButton, InputField userRateInputField)
        {
            currencyRateModel = new(currentRateText, applyRateButton, userRateInputField);

            InitDeafaultCurrencyRate();
        }

        private void InitDeafaultCurrencyRate()
        {
            currencyRateModel.CurrentRate = 1.7d;
            currencyRateModel.CurrentRateText.text = $"{currencyRateModel.CurrentRate}";
        }
    }

    public sealed class CurrencyRateModel
    {
        public Text CurrentRateText => currentRateText; // TODO: Add a setter to update by event.
        private readonly Text currentRateText = null;

        public Button ApplyRateButton => applyRateButton;
        private readonly Button applyRateButton = null;

        public InputField UserRateInputField => userRateInputField;
        private readonly InputField userRateInputField = null;

        public double CurrentRate { get => currentRate; set => currentRate = value; }
        private double currentRate = 0;

        public CurrencyRateModel(Text currentRateText, Button applyRateButton, InputField userRateInputField)
        {
            this.currentRateText = currentRateText;
            this.applyRateButton = applyRateButton;
            this.userRateInputField = userRateInputField;
        }
    }
}