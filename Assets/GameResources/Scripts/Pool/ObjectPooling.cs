namespace Balloons.Features.ObjectPool
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Пул объектов
    /// </summary>
    public sealed class ObjectPooling : MonoBehaviour
    {
        private List<PoolObject> _objects = new List<PoolObject>();
        private Transform _objectsParent = default;
        private GameObject _newObject = default;

        /// <summary>
        /// Иниациализация пула
        /// </summary>
        /// <param name="count"></param>
        /// <param name="obj"></param>
        /// <param name="objects_parent"></param>
        public void Init(int count, PoolObject obj, Transform objects_parent)
        {
            _objectsParent = objects_parent;
            for (int i = 0; i < count; i++)
            {
                CreateObject(obj, objects_parent);
            }
        }

        public PoolObject GetOrCreate()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i].gameObject.activeInHierarchy == false)
                {
                    _objects[i].gameObject.SetActive(true);
                    return _objects[i];
                }
            }
            CreateObject(_objects[0], _objectsParent);
            return _objects[_objects.Count - 1];
        }

        private void CreateObject(PoolObject obj, Transform objects_parent)
        {
            _newObject = Instantiate(obj.gameObject);
            _newObject.name = obj.name;
            _newObject.transform.SetParent(objects_parent);
            _objects.Add(_newObject.GetComponent<PoolObject>());
            _newObject.SetActive(false);
        }
    }
}