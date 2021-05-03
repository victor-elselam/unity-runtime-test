namespace Examples
{
    public static class ContextProvider
    {
        public static IContext Context { get; private set; }
        
        public static void Subscribe(IContext context)
        {
            Context = context;
        }
    }
}