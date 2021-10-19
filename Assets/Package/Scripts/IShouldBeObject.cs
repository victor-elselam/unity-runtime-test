namespace com.elselam.runtimetest
{
    public interface IShouldBeObject<T>: IAssertObject<T> {
        IShouldBeObject<T> ShouldBe(T expectedResult);
    }
}