namespace Balloons.Features.ObjectPool
{
    using UnityEngine;

    /// <summary>
    /// Обертка для управления статическим классом PoolManager
    /// </summary>
    public sealed class PoolSetup : MonoBehaviour
    {
        [SerializeField]
        private PoolManager.PoolPart[] _pools;

        private void OnValidate()
        {
            for (int i = 0; i < _pools.Length; i++)
            {
                _pools[i].Name = _pools[i].Prefab.name;
            }
        }

        private void Awake() => Init();

        private void Init() => PoolManager.Init(_pools);
    }
}