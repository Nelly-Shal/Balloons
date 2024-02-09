using System;
using GameDev.Extensions.SaveLoad;
using System.Collections.Generic;

namespace Balloons.Features.HighScore
{
    /// <summary>
    /// Контролер загрузкии сохранения результатов
    /// </summary>
    public class HighScoreSaveLoadController : SaveLoadDataController<HighScores>
    {
        protected const string SAVE_LOAD_STRING = "HighScoreString";

        /// <summary>
        /// Сохранить результаты
        /// </summary>
        /// <param name="highScoreDataList"></param>
        public virtual void SaveHighScores(List<HighScoreData> highScoreDataList)
        {
            HighScores highScores = new HighScores { highScoreDataList = highScoreDataList };
            SaveData(SAVE_LOAD_STRING, highScores);
        }

        /// <summary>
        /// Загрузить результаты
        /// </summary>
        /// <param name="highScoreDataList"></param>
        public virtual List<HighScoreData> LoadHighScores()
        {
            HighScores highScores = new HighScores();
            highScores = LoadData(SAVE_LOAD_STRING);
            if (highScores != null)
            {
                return highScores.highScoreDataList;
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Данные для результатов
    /// </summary>
    [Serializable]
    public class HighScores
    {
        /// <summary>
        /// Список результатов
        /// </summary>
        public List<HighScoreData> highScoreDataList = new List<HighScoreData>();
    }
}