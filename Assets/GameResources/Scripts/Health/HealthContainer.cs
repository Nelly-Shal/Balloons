using Balloons.Features.Values;
using UnityEngine;

namespace Balloons.Features.Health
{
    /// <summary>
    /// Контейнер со значением здоровья
    /// </summary>
    [CreateAssetMenu(fileName = "HealthContainer", menuName = "Balloons/Health/HealthContainer")]
    public class HealthContainer : BaseValueContainer
    {
        /// <summary>
        /// Максимальное значение для здоровья
        /// </summary>
        public int MaxValue
        {
            get => maxValue;
            set
            {
                if (value != maxValue)
                {
                    maxValue = value;
                }
            }
        }

        [SerializeField]
        protected int maxValue = 3;

        [SerializeField]
        protected int defaulValue = 3;

        /// <summary>
        /// Сбросить текущее значение
        /// </summary>
        public override void ResetValue()
        {
            currentValue = defaulValue;
            maxValue = defaulValue;
        }
    }
}
