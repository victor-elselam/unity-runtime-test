namespace Examples
{
    public interface ILocalStorage
    {
        void Save(string key, string serialized);
        string Get(string key);
    }
}