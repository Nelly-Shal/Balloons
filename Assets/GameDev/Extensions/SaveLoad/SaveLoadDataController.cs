namespace GameDev.Extensions.SaveLoad
{
    using UnityEngine;

    /// <summary>
    /// Контролер загрузки и сохранения данных через PlayerPrefs и JsonUtility
    /// </summary>
    public class SaveLoadDataController<T> : MonoBehaviour
    {
        protected virtual void SaveData(string saveString, object obj)
        {
            string json = JsonUtility.ToJson(obj);
            PlayerPrefs.SetString(saveString, json);
            PlayerPrefs.Save();
        }

        protected virtual T LoadData(string saveString)
        {
            string jsonString = PlayerPrefs.GetString(saveString);
            return JsonUtility.FromJson<T>(jsonString);
        }
    }
}
