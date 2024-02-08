namespace Balloons.Features.Balloons
{
    using System;
    using System.Collections;
    using UnityEngine;


    /// <summary>
    /// Перемещает объект в заданном направлении
    /// </summary>
    [RequireComponent((typeof(Rigidbody2D)))]
    public class MoveController : MonoBehaviour
    {
        /// <summary>
        /// Скорость движения объекта изменилась
        /// </summary>
        public event Action onSpeedChanged = delegate { };
        /// <summary>
        /// Направление движения объекта изменилось
        /// </summary>
        public event Action onDirectionChanged = delegate { };


        /// <summary>
        /// Скорость движения объекта
        /// </summary>
        public float Speed
        {
            get => speed;
            set
            {
                if (value != speed)
                {
                    speed = value;
                    onSpeedChanged();
                }
            }
        }
        /// <summary>
        /// Нправление движения объекта
        /// </summary>
        public Vector2 Direction
        {
            get => direction;
            set
            {
                if (value != direction)
                {
                    direction = value;
                    onDirectionChanged();
                }
            }
        }

        [SerializeField]
        protected float speed = 3f;

        protected Vector2 direction = new Vector2(0, 1);
        protected Rigidbody2D rb = default;
        protected Coroutine coroutine = default;

        protected virtual void Awake() => rb = GetComponent<Rigidbody2D>();

        protected virtual void OnEnable() => Move();

        /// <summary>
        /// Задать движение объекту
        /// </summary>
        public virtual void Move()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
            coroutine = StartCoroutine(MoveCoroutine());

        }

        protected virtual IEnumerator MoveCoroutine()
        {
            while (isActiveAndEnabled)
            {

                rb.velocity = direction * speed;
                yield return null;
            }
        }
    }
}
