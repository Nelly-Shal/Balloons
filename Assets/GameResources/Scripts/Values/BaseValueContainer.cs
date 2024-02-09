namespace Balloons.Features.Values
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Базовый контейнер со значениями
    /// </summary>
    [CreateAssetMenu(fileName = "BaseValueContainer", menuName = "Balloons/Values/BaseValueContainer")]

    public class BaseValueContainer : ScriptableObject
    {
        /// <summary>
        /// Значение изменилось
        /// </summary>
        public event Action onValueChanged = delegate { };

        /// <summary>
        /// Id контейнера
        /// </summary>
        public string IdContainer => idContainer;

        /// <summary>
        /// Максимальное значение для здоровья
        /// </summary>
        public int CurrentValue
        {
            get => currentValue;
            set
            {
                if (value != currentValue)
                {
                    currentValue = value;
                    onValueChanged();
                }
            }
        }

        [SerializeField]
        protected string idContainer = default;

        [SerializeField]
        protected int currentValue = default;

        /// <summary>
        /// Сбросить текущее значение
        /// </summary>
        public virtual void ResetValue() => currentValue = 0;
    }
}
