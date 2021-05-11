using Examples.LocalStorage;

namespace Examples
{
    public enum Environment
    {
        Test,
        Game
    }
    
    public class SimpleContext : IContext
    {
        public Environment Environment => Environment.Test;
        public ILocalStorage LocalStorage { get; }

        public SimpleContext()
        {
            ContextProvider.Subscribe(this);
            LocalStorage = LocalStorageFactoring.CreateInstance();
        }
    }
}