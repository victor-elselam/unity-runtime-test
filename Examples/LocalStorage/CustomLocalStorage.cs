using System.Collections.Generic;

namespace Examples.LocalStorage
{
    public class CustomLocalStorage : ILocalStorage
    {
        private readonly Dictionary<string, string> _customLocalStorage;

        public CustomLocalStorage()
        {
            _customLocalStorage = new Dictionary<string, string>();
        }
        
        public void Save(string key, string serialized)
        {
            _customLocalStorage[key] = serialized;
        }

        public string Get(string key)
        {
            return _customLocalStorage[key];
        }
    }
}