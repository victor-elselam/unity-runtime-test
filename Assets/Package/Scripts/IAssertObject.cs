namespace com.elselam.runtimetest
{
    public interface IAssertObject<T> {

        IAssertObject<T> Because(string message);
        IAssertObject<T> Run();
    }
}