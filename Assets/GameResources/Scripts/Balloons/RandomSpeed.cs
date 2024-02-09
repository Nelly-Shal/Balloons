namespace Balloons.Features.Balloons
{
    using UnityEngine;

    /// <summary>
    /// Случайная скорость
    /// </summary>
    [RequireComponent(typeof(MoveController))]
    public class RandomSpeed : MonoBehaviour
    {
        [SerializeField, Min(0)]
        protected float minSpeed = default;
        [SerializeField, Min(0)]
        protected float maxSpeed = default;

        protected MoveController moveController = default;

        protected virtual void Awake() => moveController = GetComponent<MoveController>();

        protected virtual void OnEnable() => moveController.Speed = Random.Range(minSpeed, maxSpeed);
    }
}