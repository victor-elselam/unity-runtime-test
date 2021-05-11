using System.Threading.Tasks;
using Scripts;

namespace Examples
{
    public class SimpleTest : AssertMonoBehaviour
    {
        public async void Awake()
        {
            //Prepare
            var context = new SimpleContext();
            Setup("[SimpleTest]");
            
            //Supports await task, so as http requests and any async processing
            await Task.Delay(1000);

            //Execute
            const string key1 = "testKey1";
            const string value1 = "testValue1";
            context.LocalStorage.Save(key1, value1);
            
            //Assert
            Assert(() => context.LocalStorage.Get(key1))
                .ShouldBe(value1).Because($"{value1} was the value for {key1}").Run();
        
            //Execute
            const string key2 = "testKey2";
            const string value2 = "testValue2";
            context.LocalStorage.Save(key2, value2);
            
            //Assert
            Assert(() => context.LocalStorage.Get(key2))
                .ShouldBe(value2).Because($"{value2} was the value for {key2}").Run();
            
            //Execute
            const string key3 = "testKey3";
            const string value3 = "testValue3";
            context.LocalStorage.Save(key3, value3);
            
            //Assert
            Assert(() => context.LocalStorage.Get(key3))
                .ShouldBe(value3).Because($"{value3} was the value for {key3}").Run();
        
            //Finish test scope
            Finish();
        }
    }
}
