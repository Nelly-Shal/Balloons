namespace GameDev.Extensions
{
    using UnityEngine;

    /// <summary>
    /// Активирует и деактивирует паузу
    /// </summary>
    public sealed class PauseWindowEvent : MonoBehaviour
    {
        [SerializeField]
        private bool _pauseOnEnable = true;

        private void OnEnable() => Time.timeScale = _pauseOnEnable ? 0f : 1f;

        private void OnDisable() => Time.timeScale = _pauseOnEnable ? 1f : 0f;
    }
}