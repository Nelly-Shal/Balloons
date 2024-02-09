
using GameDev.Extensions;
using Balloons.Features.Values;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Balloons.Features.HighScore
{
    /// <summary>
    /// Сохранение результата при нажатии на кнопку
    /// </summary>
    public class HighScoreSaveButtonView : AbstractButtonView
    {
        [SerializeField]
        protected InputField inputField = default;
        [SerializeField]
        protected BaseValueContainer valueContainer = default;
        [SerializeField]
        protected HighScoreController highScoreController = default;

        /// <summary>
        /// Добавить новый результат и загрузить таблицу
        /// </summary>
        public override void OnButtonClick()
        {
            highScoreController.AddHighScoreEntry(valueContainer.CurrentValue, inputField.text);
            highScoreController.CreateTable();
        }
    }
}