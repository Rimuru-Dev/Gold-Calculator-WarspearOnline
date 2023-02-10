// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Project: Infinity Dead
//   Contact me: rimuru.dev@gmail.com
//
// **************************************************************** //

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RimuruDev
{

    public sealed class UIHandler : MonoBehaviour
    {
        private DataContainer dataContainer;

        private void Awake()
        {
            if (dataContainer == null)
                dataContainer = GameObject.FindObjectOfType<DataContainer>();
        }

        private void Start()
        {
            dataContainer.currentExchangeRateText.text = $" урс сейчас: 1к голд - {dataContainer.currentExchangeRateRub:N} руб.";
        }

        public void OpenAndClosePanel(GameObject panel) =>
        panel.SetActive(!panel.activeInHierarchy);

        public void WriteNewCource()
        {
            dataContainer.currentExchangeRateRub = GetNewExchangeRate();

            dataContainer.currentExchangeRateText.text = $" урс сейчас: 1к голд - {dataContainer.currentExchangeRateRub:N} руб.";
        }

        private float GetNewExchangeRate() => float.Parse(dataContainer.exchangeRate.text);

        public void CalculateGoldRub()
        {
            if (dataContainer.enterNewGoldExchange.text == "" || dataContainer.enterNewGoldExchange.text == null) Debug.Log("String is empty or null.");

            double result = 0;

            if (double.TryParse(dataContainer.enterNewGoldExchange.text, out double enterUserData))
            {
                result = enterUserData;

                if (enterUserData <= 100)
                    result = enterUserData / 1000 * dataContainer.currentExchangeRateRub;
                else if (enterUserData is > 100 and <= 1000)
                    result = enterUserData / 1000 * dataContainer.currentExchangeRateRub;
                else if (enterUserData is > 1000 and <= 10000)
                    result = enterUserData / 1000 * dataContainer.currentExchangeRateRub;
                else if (enterUserData is > 10000 and <= 100000)
                    result = enterUserData / 1000 * dataContainer.currentExchangeRateRub;
                else if (enterUserData is > 100000 and <= 1000000)
                    result = enterUserData / 1000 * dataContainer.currentExchangeRateRub;
                else if (enterUserData is > 1000000 and <= 10000000)
                    result = enterUserData / 1000 * dataContainer.currentExchangeRateRub;
                else if (enterUserData is > 10000000 and <= 100000000)
                    result = enterUserData / 1000 * dataContainer.currentExchangeRateRub;
                else
                    Debug.Log("Error");

                {
                    //for (int i = 0; i < dataContainer.array.Length - 1; i++)
                    //{
                    //    if (enterUserData <= dataContainer.array[i])
                    //    {
                    //        Debug.Log("IF");
                    //        result /= (checked(dataContainer.array[++i] * dataContainer.currentExchangeRateRub));

                    //        Debug.Log(result);

                    //        dataContainer.goldRubResultText.text = $"{result} руб.";

                    //        //return;
                    //    }
                    //    else if (enterUserData > dataContainer.array[i] && enterUserData <= dataContainer.array[++i])
                    //    {
                    //        Debug.Log("Else IF");
                    //        Debug.Log(result);

                    //        dataContainer.goldRubResultText.text = $"{result} руб.";

                    //       // return;
                    //    }
                    //}
                    //}
                }
            }
            dataContainer.goldRubResultText.text = $"{Math.Round(result, 2)} руб.";
        }

        public void CalculateRubGold()
        {
            if (dataContainer.enterNewRubExchange.text == "" || dataContainer.enterNewRubExchange.text == null) Debug.Log("String is empty or null.");

            double result = 0;

            if (double.TryParse(dataContainer.enterNewRubExchange.text, out double enterUserData))
            {
                result = enterUserData;

                if (enterUserData <= 100)
                    result = enterUserData * 1000 / dataContainer.currentExchangeRateRub;
                else if (enterUserData is > 100 and <= 1000)
                    result = enterUserData * 1000 / dataContainer.currentExchangeRateRub;
                else if (enterUserData is > 1000 and <= 10000)
                    result = enterUserData * 1000 / dataContainer.currentExchangeRateRub;
                else if (enterUserData is > 10000 and <= 100000)
                    result = enterUserData * 1000 / dataContainer.currentExchangeRateRub;
                else if (enterUserData is > 100000 and <= 1000000)
                    result = enterUserData * 1000 / dataContainer.currentExchangeRateRub;
                else if (enterUserData is > 1000000 and <= 10000000)
                    result = enterUserData * 1000 / dataContainer.currentExchangeRateRub;
                else if (enterUserData is > 10000000 and <= 100000000)
                    result = enterUserData * 1000 / dataContainer.currentExchangeRateRub;
                else
                    Debug.Log("Error");
            }
            dataContainer.rubGoldResultText.text = $"{Math.Round(result)} голды.";
        }
    }
}