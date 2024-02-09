namespace Balloons.Features.Values
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Обновляет View при достижении целевого значения
    /// </summary>
    public class OnTargetCurrentValueView : OnValueChangeCallback
    {
        [SerializeField, Min(0)]
        protected int targetValue = 0;
        [SerializeField]
        protected List<GameObject> objectsToView = default;
        [SerializeField]
        protected bool status = true;

        protected override void UpdateOnChangedCallback()
        {
            if (valueContainer.CurrentValue == targetValue)
            {
                foreach (GameObject obj in objectsToView)
                {
                    obj.SetActive(status);
                }
            }
        }
    }
}
