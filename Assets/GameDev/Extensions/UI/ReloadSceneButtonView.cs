namespace GameDev.Extensions
{
    using UnityEngine.SceneManagement;

    /// <summary>
    /// Перезагрузка текущей сцены по кнопке
    /// </summary>
    public class ReloadSceneButtonView : AbstractButtonView
    {
        /// <summary>
        /// Перезагружает сцену
        /// </summary>
        public override void OnButtonClick() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}