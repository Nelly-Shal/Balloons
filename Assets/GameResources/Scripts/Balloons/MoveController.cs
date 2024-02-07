namespace Balloons.Features.Balloons
{
    using System;
    using System.Collections;
    using UnityEngine;


    /// <summary>
    /// ���������� ������ � �������� �����������
    /// </summary>
    [RequireComponent((typeof(Rigidbody2D)))]
    public class MoveController : MonoBehaviour
    {
        /// <summary>
        /// �������� �������� ������� ����������
        /// </summary>
        public event Action onSpeedChanged = delegate { };
        /// <summary>
        /// ����������� �������� ������� ����������
        /// </summary>
        public event Action onDirectionChanged = delegate { };


        /// <summary>
        /// �������� �������� �������
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
        /// ���������� �������� �������
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


        protected virtual void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            Move();
        }

        /// <summary>
        /// ������ �������� �������
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

        protected IEnumerator MoveCoroutine()
        {
            while (isActiveAndEnabled)
            {

                rb.velocity = direction * speed;
                yield return null;
            }
        }
    }
}
