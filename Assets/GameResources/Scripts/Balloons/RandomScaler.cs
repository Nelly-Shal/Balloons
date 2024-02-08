namespace Balloons.Features.Balloons
{
    using UnityEngine;
    using Random = UnityEngine.Random;

    /// <summary>
    /// Скейлит объект в заданном диапазоне 
    /// </summary>
    public class RandomScaler : MonoBehaviour
    {
        [SerializeField, Min(0)]
        protected float minScale = default;
        [SerializeField, Min(0)]
        protected float maxScale = default;
        [SerializeField]
        protected bool scaleOnEnable = true;

        protected float newScale = default;

        protected virtual void OnEnable()
        {
            if (scaleOnEnable)
            {
                RandomScale();
            }
        }

        /// <summary>
        /// Задать новый размер
        /// </summary>
        public virtual void RandomScale()
        {
            newScale = Random.Range(minScale, maxScale);
            transform.localScale = Vector3.one * newScale;
        }
    }
}