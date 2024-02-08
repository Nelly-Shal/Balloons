namespace Balloons.Features.ObjectPool
{
    using UnityEngine;

    /// <summary>
    /// Объект пула
    /// </summary>
    public sealed class PoolObject : MonoBehaviour
    {
        /// <summary>
        /// Вернуть объект в пул
        /// </summary>
        public void ReturnToPool() => gameObject.SetActive(false);
    }
}