using UnityEngine;

namespace RimuruDev
{
    public sealed class CurrencyConverter : MonoBehaviour
    {
        private DataContainer dataContainer;

        private void Awake()
        {
            if (dataContainer == null)
                dataContainer = FindObjectOfType<DataContainer>();

            dataContainer.currentExchangeRateText.text = $"Курс сейчас: 1к голд - {dataContainer.currentExchangeRateRub:N} руб.";
        }

        [SerializeField] private float goldRate = 1.7f;

        public void Convert()
        {
            if (float.TryParse(dataContainer.enterNewGoldExchange.text, out float result))
            {
                dataContainer.goldRubResultText.text = ConvertGoldToRubles(result).ToString("F2") + " руб.";
            }
        }

        float ConvertGoldToRubles(float gold)
        {
            return Mathf.Clamp(gold, 100f, float.MaxValue) * ((float)dataContainer.currentExchangeRateRub) / 1000f;
        }

        float ConvertRublesToGold(float rubles)
        {
            return Mathf.Clamp(rubles, 115f, float.MaxValue) * 1000f / goldRate;
        }
    }
}