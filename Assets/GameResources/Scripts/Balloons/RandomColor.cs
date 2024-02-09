namespace Balloons.Features.Balloons
{
    using UnityEngine;

    /// <summary>
    /// Задает новый цвет
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class RandomColor : MonoBehaviour
    {
        [SerializeField]
        protected bool setColorOnEnable = true;

        protected SpriteRenderer spriteRenderer = default;
        protected Color randomColor = default;

        protected virtual void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

        protected virtual void OnEnable()
        {
            if (setColorOnEnable)
            {
                SetColor();
            }
        }

        /// <summary>
        /// Задать новый цвет
        /// </summary>
        public virtual void SetColor()
        {
            float r = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);

            randomColor = new Color(r, g, b, spriteRenderer.color.a);

            spriteRenderer.color = randomColor;
        }
    }
}