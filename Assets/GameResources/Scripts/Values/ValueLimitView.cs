namespace Balloons.Features.Values
{
    using UnityEngine;

    /// <summary>
    /// Меняет View в зависимости от значения в контейнере
    /// </summary>
    public class ValueLimitView : OnTargetCurrentValueView
    {
        protected override void UpdateOnChangedCallback()
        {
            foreach (GameObject obj in objectsToView)
            {
                obj.SetActive(valueContainer.CurrentValue < targetValue);
            }
        }
    }
}