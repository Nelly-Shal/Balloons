namespace Balloons.Features.ObjectPool
{
    using UnityEngine;

    /// <summary>
    /// Возвращает объекты в пул по триггеру
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public sealed class PoolObjectsBlocker2D : MonoBehaviour
    {
        private PoolObject _poolObject = default;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out _poolObject))
            {
                _poolObject.ReturnToPool();
            }
        }
    }
}