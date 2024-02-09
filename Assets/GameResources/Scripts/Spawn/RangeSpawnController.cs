using Balloons.Features.ObjectPool;
using System.Collections;
using UnityEngine;

namespace Balloons.Features.Spawn
{
    /// <summary>
    /// Спавн объектов в диапазоне размера спавнера
    /// </summary>
    public class RangeSpawnController : MonoBehaviour
    {
        [SerializeField]
        protected GameObject prefabToSpawn = default;

        [SerializeField]
        protected bool spawnOnEnable = true;

        [SerializeField, Min(0)]
        protected float minDelay = 0.8f;
        [SerializeField, Min(0)]
        protected float maxDelay = 2f;

        protected float nextSpawn = 0f;
        protected Coroutine coroutine = default;

        protected float xPosition = default;
        protected float yPosition = default;
        protected float zPosition = default;
        protected Vector3 newPosition = default;
        protected GameObject newObject = default;

        protected virtual void OnEnable()
        {
            nextSpawn = Random.Range(minDelay, maxDelay);
            if (spawnOnEnable)
            {
                StartSpawn();
            }
        }

        /// <summary>
        /// Начать спавн объектов
        /// </summary>
        public virtual void StartSpawn()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
            coroutine = StartCoroutine(SpawnCoroutine());
        }

        /// <summary>
        /// Остановиь спавн объектов
        /// </summary>
        public virtual void StopSpawn()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }

        protected virtual IEnumerator SpawnCoroutine()
        {
            while (isActiveAndEnabled)
            {
                if (Time.time > nextSpawn)
                {
                    xPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
                    yPosition = transform.position.y;
                    zPosition = transform.position.z;

                    newPosition = new Vector3(xPosition, yPosition, zPosition);
                    newObject = PoolManager.GetOrCreate(prefabToSpawn.name, newPosition, transform.localRotation);

                    nextSpawn = Time.time + Random.Range(minDelay, maxDelay);
                }
                yield return null;
            }
        }
    }
}