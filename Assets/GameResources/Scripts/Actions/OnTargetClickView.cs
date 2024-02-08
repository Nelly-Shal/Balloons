namespace Balloons.Features.Actions
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Обновляет View при достижении целевого значения
    /// </summary>
    [RequireComponent(typeof(ClickAction))]
    public class OnTargetClickView : MonoBehaviour
    {
        [SerializeField]
        protected List<GameObject> objectsToView = new List<GameObject>();
        [SerializeField]
        protected List<GameObject> objectsToHide = new List<GameObject>();

        [SerializeField, Min(0)]
        protected float delay = default;

        protected ClickAction clickAction = default;
        protected Coroutine coroutine = default;

        protected virtual void Awake()
        {
            clickAction = GetComponent<ClickAction>();
            clickAction.onTargetCountClick += UpdateView;
        }

        protected virtual void OnEnable() => UpdateListsView(false);

        protected virtual void OnDestroy()
        {
            if (clickAction)
            {
                clickAction.onTargetCountClick -= UpdateView;
            }
        }

        protected virtual void UpdateView()
        {
            UpdateListsView(true);
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
            coroutine = StartCoroutine(WaitDelay());
        }

        protected virtual void UpdateListsView(bool status)
        {
            foreach (GameObject obj in objectsToView)
            {
                obj.SetActive(status);
            }
            foreach (GameObject obj in objectsToHide)
            {
                obj.SetActive(!status);
            }
        }

        protected virtual IEnumerator WaitDelay()
        {
            while (isActiveAndEnabled)
            {
                yield return new WaitForSeconds(delay);
                gameObject.SetActive(false);
            }
        }
    }
}