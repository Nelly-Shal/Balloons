namespace Balloons.Features.Actions
{
    using UnityEngine;

    /// <summary>
    /// Класс реализующий систему подписок и отписок для ClickAction
    /// </summary>
    [RequireComponent(typeof(ClickAction))]

    public class OnTargetClickCallback : MonoBehaviour
    {
        protected ClickAction clickAction = default;

        protected virtual void Awake()
        {
            clickAction = GetComponent<ClickAction>();
            clickAction.onTargetCountClick += UpdateOnTargtCallback;
            clickAction.onTargetCountClick += UpdateOnClickCallback;
        }

        protected virtual void OnDestroy()
        {
            if (clickAction)
            {
                clickAction.onTargetCountClick -= UpdateOnTargtCallback;
                clickAction.onTargetCountClick -= UpdateOnClickCallback;
            }
        }

        protected virtual void UpdateOnTargtCallback() { }
        protected virtual void UpdateOnClickCallback() { }

    }
}