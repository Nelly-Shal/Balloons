using Balloons.Features.Actions;
using UnityEngine;

namespace Balloons.Features.Values
{
    /// <summary>
    /// Изменить текущее значение при клике наобъект
    /// </summary>
    public class OnTargetClickChangeValue : OnTargetClickCallback
    {
        [SerializeField]
        protected int addValue = default;

        [SerializeField]
        protected BaseValueContainer valueContainer = default;

        protected override void UpdateOnTargtCallback() => valueContainer.CurrentValue += addValue;
    }
}