namespace Balloons.Features.Actions
{
    using System;
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Проверяет количество кликов по объекту с целевым значением
    /// </summary>
    public class ClickAction : MonoBehaviour, IPointerDownHandler
    {
        /// <summary>
        /// Событие о клике
        /// </summary>
        public event Action onClickAction = delegate { };
        /// <summary>
        /// Событие о достижении целевого значения
        /// </summary>
        public event Action onTargetCountClick = delegate { };

        [SerializeField, Min(0)]
        protected int targetCount = 1;

        protected int count = 0;

        protected virtual void OnEnable() => count = 0;

        /// <summary>
        /// Действие при клике на объект
        /// </summary>
        /// <param name="eventData"></param>
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            count++;
            if (targetCount == count)
            {
                onTargetCountClick();
                return;
            }
            onClickAction();
        }
    }
}
