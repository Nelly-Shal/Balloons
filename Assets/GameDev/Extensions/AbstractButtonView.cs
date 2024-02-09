namespace GameDev.Extensions
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Действие по клику на кнопку
    /// </summary>
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButtonView : MonoBehaviour
    {
        protected Button buttonView = default;

        protected virtual void Awake()
        {
            buttonView = GetComponent<Button>();
            buttonView.onClick.AddListener(OnButtonClick);
        }

        protected virtual void OnDestroy() => buttonView.onClick.RemoveListener(OnButtonClick);

        /// <summary>
        /// Действие по нажатию на кнопку
        /// </summary>
        public abstract void OnButtonClick();
    }
}
