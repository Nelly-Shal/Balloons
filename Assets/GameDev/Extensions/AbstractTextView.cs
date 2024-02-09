namespace GameDev.Extensions
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Класс для обновления View текста
    /// </summary>
    [RequireComponent(typeof(Text))]
    public abstract class AbstractTextView : MonoBehaviour
    {
        protected Text textView = default;

        protected virtual void Awake() => textView = GetComponent<Text>();

        /// <summary>
        /// Обновление View текста
        /// </summary>
        public abstract void UpdateView();
    }
}
