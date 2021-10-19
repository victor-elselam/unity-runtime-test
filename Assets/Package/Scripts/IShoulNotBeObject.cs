namespace com.elselam.runtimetest
{
    public interface IShouldNotBeObject<T>: IAssertObject<T>
    {
        IShouldNotBeObject<T> ShouldNotBe(T expectedResult);
    }
}