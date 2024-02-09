namespace Balloons.Features.Values
{
    using UnityEngine;

    /// <summary>
    /// Класс реализующий систему подписок и отписок для BaseValueContainer
    /// </summary>
    public abstract class OnValueChangeCallback : MonoBehaviour
    {
        [SerializeField]
        protected BaseValueContainer valueContainer = default;

        protected virtual void Start() => valueContainer.onValueChanged += UpdateOnChangedCallback;

        protected virtual void OnDestroy() => valueContainer.onValueChanged -= UpdateOnChangedCallback;

        protected abstract void UpdateOnChangedCallback();
    }
}