using Balloons.Features.Values;
using GameDev.Extensions;
using UnityEngine;

namespace Balloons.Features.GameControllers
{
    /// <summary>
    /// Текстовое View для значения
    /// </summary>
    public class ScoreTextView : AbstractTextView
    {
        [SerializeField]
        protected BaseValueContainer valueContainer = default;

        protected virtual void Start()
        {
            valueContainer.onValueChanged += UpdateView;
            UpdateView();
        }

        protected virtual void OnDestroy() => valueContainer.onValueChanged -= UpdateView;

        /// <summary>
        /// Обновить текстовое значение
        /// </summary>
        public override void UpdateView() => textView.text = valueContainer.CurrentValue.ToString();
    }
}
