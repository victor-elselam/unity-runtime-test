using UnityEngine;

namespace Examples.LocalStorage
{
    public class UnityLocalStorage: ILocalStorage
    {
        public void Save(string key, string serialized)
        {
            PlayerPrefs.SetString(key, serialized);
        }

        public string Get(string key)
        {
            return PlayerPrefs.GetString(key);
        }
    }
}