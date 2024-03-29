﻿// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Project: Gold Calculator WarspearOnline
//   Contact me: rimuru.dev@gmail.com
//
// **************************************************************** //

using System;
using UnityEngine.UI;

namespace Development.RimuruDev.WarspearOnline
{
    public sealed class CurrencyConverterController
    {
        private readonly CurrencyConverterModel currencyModel = null;

        public CurrencyConverterController(InputField userInputField, Text resultText, CurrencyType currency, Button button)
        {
            currencyModel = new(userInputField, resultText, currency, button);

            InitialText();
            SubscribeToButton();
            SetRate(currencyModel.CurrencyRate);
        }

        ~CurrencyConverterController() => UnsubscribeToButton();

        public void CalculateCurrancyConvertation(CurrencyType currency)
        {
            if (double.TryParse(currencyModel.UserInputField.text, out double result))
            {
                switch (currency)
                {
                    case CurrencyType.Rub:
                        currencyModel.ResultText.text = ConvertGoldToRubles(result).ToString("F2");
                        break;
                    case CurrencyType.Gold:
                        currencyModel.ResultText.text = ConvertRublesToGold(result).ToString("F2");
                        break;
                }
            }
        }

        public void SetRate(double rate) => currencyModel.CurrencyRate = rate;

        private void InitialText() => currencyModel.ResultText.text = $"0 {currencyModel.Currency}";

        private void SubscribeToButton() => currencyModel.Button.onClick.AddListener(delegate { CalculateCurrancyConvertation(currencyModel.Currency); });

        private void UnsubscribeToButton() => currencyModel.Button.onClick.RemoveAllListeners();

        private double ConvertGoldToRubles(double gold) => Math.Clamp(gold, 100d, double.MaxValue) * currencyModel.CurrencyRate / 1000d;

        private double ConvertRublesToGold(double rubles) => Math.Clamp(rubles, 1d, double.MaxValue) * 1000d / currencyModel.CurrencyRate;
    }
}