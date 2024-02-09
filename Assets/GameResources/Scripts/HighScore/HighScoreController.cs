namespace Balloons.Features.HighScore
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Данные для результатов
    /// </summary>
    [Serializable]
    public class HighScoreData
    {
        public int Score = default;
        public string Name = default;
    }

    /// <summary>
    /// Контролер результатов
    /// </summary>
    public class HighScoreController : MonoBehaviour
    {
        [SerializeField]
        protected HighScoreSaveLoadController highScoreSaveLoadController = default;
        [SerializeField]
        protected HighScoreTableView highScoreTable = default;

        protected List<HighScoreData> highScoreDataList = new List<HighScoreData>();

        /// <summary>
        /// Создать талицу результатов
        /// </summary>
        public virtual void CreateTable()
        {
            if (highScoreDataList == null)
            {
                highScoreDataList = highScoreSaveLoadController.LoadHighScores();
            }

            if (highScoreDataList != null)
            {
                SortHighScoreList();

                foreach (HighScoreData data in highScoreDataList)
                {
                    CreateHighScoreEntry(data);
                }
            }
        }

        protected virtual void CreateHighScoreEntry(HighScoreData highScoreData) => highScoreTable.CreateHighScoreEntry(highScoreData);

        /// <summary>
        /// Добавить новый результат
        /// </summary>
        /// <param name="score"></param>
        /// <param name="newName"></param>
        public virtual void AddHighScoreEntry(int score, string newName)
        {
            HighScoreData highScoreData = new HighScoreData { Score = score, Name = newName };

            highScoreDataList = highScoreSaveLoadController.LoadHighScores();
            if (highScoreDataList == null)
            {
                highScoreDataList = new List<HighScoreData>();
            }

            highScoreDataList.Add(highScoreData);
            highScoreSaveLoadController.SaveHighScores(highScoreDataList);
        }

        protected virtual void SortHighScoreList()
        {
            for (int i = 0; i < highScoreDataList.Count; i++)
            {
                for (int j = i + 1; j < highScoreDataList.Count; j++)
                {
                    if (highScoreDataList[j].Score > highScoreDataList[i].Score)
                    {
                        HighScoreData data = highScoreDataList[i];
                        highScoreDataList[i] = highScoreDataList[j];
                        highScoreDataList[j] = data;
                    }
                }
            }
        }

        /// <summary>
        /// Сбросить результаты
        /// </summary>
        public virtual void ResetHighScoreData()
        {
            highScoreSaveLoadController.SaveHighScores(null);
            highScoreTable.ResetView();
        }
    }
}
