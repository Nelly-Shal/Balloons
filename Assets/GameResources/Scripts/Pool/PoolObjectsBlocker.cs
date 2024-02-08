namespace Balloons.Features.Spawn
{
    using UnityEngine;

    /// <summary>
    /// Возвращает объекты в пул по триггеру
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public sealed class PoolObjectsBlocker : MonoBehaviour
    {
        private PoolObject _poolObject = default;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out _poolObject))
            {
                _poolObject.ReturnToPool();
            }
        }
    }
}