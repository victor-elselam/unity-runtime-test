namespace Examples
{
    public interface IContext
    {
        Environment Environment { get; }
        ILocalStorage LocalStorage { get; }
    }
}