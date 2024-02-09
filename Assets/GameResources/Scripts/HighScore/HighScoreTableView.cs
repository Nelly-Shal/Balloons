namespace Balloons.Features.HighScore
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// View таблицы результатов
    /// </summary>
    public class HighScoreTableView : MonoBehaviour
    {
        [SerializeField]
        protected HighScoreBarView highscoreBar = default;

        [SerializeField]
        protected List<HighScoreBarView> barList = new List<HighScoreBarView>();

        protected int lastIndex = 1;

        /// <summary>
        /// Создать новый объект и запонить данные
        /// </summary>
        /// <param name="highScoreData"></param>
        public virtual void CreateHighScoreEntry(HighScoreData highScoreData)
        {
            HighScoreBarView newBar = Instantiate(highscoreBar, transform.position, transform.rotation, transform);
            newBar.UpdateView(lastIndex, highScoreData.Name, highScoreData.Score);
            barList.Add(newBar);
            lastIndex++;
        }

        /// <summary>
        /// Сбросить View всех плашек с результатами
        /// </summary>
        public virtual void ResetView()
        {
            foreach (HighScoreBarView bar in barList)
            {
                bar.gameObject.SetActive(false);
            }
        }
    }
}