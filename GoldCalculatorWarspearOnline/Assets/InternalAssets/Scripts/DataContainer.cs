// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Project: Infinity Dead
//   Contact me: rimuru.dev@gmail.com
//
// **************************************************************** //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace RimuruDev
{
    public sealed class DataContainer : MonoBehaviour
    {
        [Header("Exchange Rate Panel")]
        public InputField exchangeRate;
        public Text currentExchangeRateText;
        [Space]
        public double currentExchangeRateRub;

        [Header("Calculator Panel")]
        public InputField enterNewGoldExchange;
        public InputField enterNewRubExchange;
        [Space]
        public Text goldRubResultText;
        public Text rubGoldResultText;

        private void OnValidate()
        {
            if (currentExchangeRateRub <= 0f)
                currentExchangeRateRub = 1.7d;
        }
    }
}
