namespace Balloons.Features.HighScore
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// View для плашки результатов
    /// </summary>
    public class HighScoreBarView : MonoBehaviour
    {
        [SerializeField]
        protected Text placeText = default;
        [SerializeField]
        protected Text nameText = default;
        [SerializeField]
        protected Text scoreText = default;

        /// <summary>
        /// Обновить View
        /// </summary>
        /// <param name="place"></param>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public virtual void UpdateView(int place, string name, int score)
        {
            placeText.text = place.ToString();
            nameText.text = name;
            scoreText.text = score.ToString();
        }
    }
}