namespace Balloons.Features.Health
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// View для здоровья
    /// </summary>
    public class HealthView : MonoBehaviour
    {
        [SerializeField]
        protected GameObject healthPrefab = default;
        [SerializeField]
        protected HealthContainer healthContainer = default;
        [SerializeField]
        protected List<GameObject> healthObjectsView = new List<GameObject>();

        protected GameObject newHealthObj = default;

        protected virtual void Awake() => healthContainer.onValueChanged += UpdateView;

        protected virtual void OnDestroy() => healthContainer.onValueChanged -= UpdateView;

        protected virtual void UpdateView()
        {
            if (healthContainer.CurrentValue <= healthObjectsView.Count)
            {
                for (int i = 0; i < healthObjectsView.Count; i++)
                {
                    healthObjectsView[i].SetActive(i < healthContainer.CurrentValue);
                }
            }
            else
            {
                newHealthObj = Instantiate(healthPrefab, transform.position, transform.rotation, transform);
                healthObjectsView.Add(newHealthObj.transform.GetChild(0).gameObject);
                healthContainer.MaxValue++;
            }
        }
    }
}