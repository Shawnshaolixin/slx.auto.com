using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace JsonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = "";
            JObject obj = JsonConvert.DeserializeObject<JObject>(json);

            foreach (var item in obj)
            {
                Console.WriteLine("key=>" + item.Key); // default,// Second //Third
                foreach (JToken itemToken in item.Value) // 便利 default 下面的内容
                {

                    foreach (JToken itemTokenChild in itemToken) // 这是对应的线
                    {
                        Console.WriteLine(itemTokenChild[0]);
                        foreach (var itemTokenChildChild in itemTokenChild) // 线里面 都是一样的了。
                        {

                        }

                    }

                }
                Console.WriteLine("key end=>" + item.Key);
            }
            Type type = obj.GetType();
            var properties = type.GetProperties();
            var fields = type.GetFields();
            var defaultMem = type.GetDefaultMembers();

            Console.WriteLine("Hello World!");
        }
    }
}
