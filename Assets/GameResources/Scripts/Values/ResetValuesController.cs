namespace Balloons.Features.Values
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Сброс значений в контейнерах
    /// </summary>
    public class ResetValuesController : MonoBehaviour
    {
        [SerializeField]
        protected List<BaseValueContainer> valueContainers = new List<BaseValueContainer>();

        protected void Awake()
        {
            foreach (BaseValueContainer container in valueContainers)
            {
                container.ResetValue();
            }
        }
    }
}