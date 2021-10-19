using System;

namespace Examples.LocalStorage
{
    public static class LocalStorageFactoring
    {
        public static ILocalStorage CreateInstance()
        {
            var environment = ContextProvider.Context.Environment;
            switch (environment)
            {
                case Environment.Test:
                    return new CustomLocalStorage();
                case Environment.Game:
                    return new UnityLocalStorage();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}