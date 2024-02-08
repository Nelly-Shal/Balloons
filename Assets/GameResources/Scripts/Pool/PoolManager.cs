namespace Balloons.Features.ObjectPool
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Статический класс для управления пулами
    /// </summary>
    public static class PoolManager
    {
        private static PoolPart[] _pools;
        private static GameObject _objectsParent = default;

        [Serializable]
        public struct PoolPart
        {

            public string Name;
            public int Count;
            public PoolObject Prefab;
            public ObjectPooling ojectPooling;
        }

        /// <summary>
        /// Инициализация пул менеджера
        /// </summary>
        /// <param name="newPools"></param>
        public static void Init(PoolPart[] newPools)
        {
            _pools = newPools;
            _objectsParent = new GameObject();
            _objectsParent.name = "Pool";

            for (int i = 0; i < _pools.Length; i++)
            {
                if (_pools[i].Prefab != null)
                {
                    _pools[i].ojectPooling = new ObjectPooling();
                    _pools[i].ojectPooling.Init(_pools[i].Count, _pools[i].Prefab, _objectsParent.transform);
                }
            }
        }

        /// <summary>
        /// Получить или создать новый объект
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public static GameObject GetOrCreate(string name, Vector3 position, Quaternion rotation)
        {
            GameObject result = null;
            if (_pools != null)
            {
                for (int i = 0; i < _pools.Length; i++)
                {
                    if (string.Compare(_pools[i].Name, name) == 0)
                    {
                        result = _pools[i].ojectPooling.GetOrCreate().gameObject;
                        result.transform.position = position;
                        result.transform.rotation = rotation;
                        result.SetActive(true);
                        return result;
                    }
                }
            }
            return result;
        }
    }
}