using Elasticsearch.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ElasticSearch
{
    class Program
    {
        static void Main(string[] args)
        {
     //       var settings = new ConnectionConfiguration(new Uri("http://localhost:9200/"))
     //.RequestTimeout(TimeSpan.FromMinutes(2));
     //       var lowlevelClient = new ElasticLowLevelClient(settings);
     //       UserInifo u = new UserInifo();
     //       u.BirthDay = DateTime.Now;
     //       u.Id = 1;
     //       u.Name = "test";

          //  var result = lowlevelClient.BulkPut<Result>(u);
            List<Publisher> plist = new List<Publisher>();
            plist.Add(new Publisher
            {
                Name = "开心便利店",
                UserId = 96401,
                Telphone = "18607732201"
            });
            plist.Add(new Publisher
            {
                Name = "福利社社长",
                UserId = 96402,
                Telphone = "18607732202"
            });
            plist.Add(new Publisher
            {
                Name = "心情驿站",
                UserId = 96406,
                Telphone = "18607732203"
            });
            plist.Add(new Publisher
            {
                Name = "车销通课代表",
                UserId = 96407,
                Telphone = "18607732204"
            }); plist.Add(new Publisher
            {
                Name = "热点追踪队",
                UserId = 96409,
                Telphone = "13488811921"
            }); plist.Add(new Publisher
            {
                Name = "首席内幕官",
                UserId = 96410,
                Telphone = "13911885555"
            }); plist.Add(new Publisher
            {
                Name = "小易聊车市",
                UserId = 96411,
                Telphone = "13901161111"
            }); plist.Add(new Publisher
            {
                Name = "车圈老炮",
                UserId = 96412,
                Telphone = "13611033333"
            }); plist.Add(new Publisher
            {
                Name = "车销通官方账号",
                UserId = 5680,
                Telphone = "13522218317"
            }); plist.Add(new Publisher
            {
                Name = "马健晖",
                UserId = 80233,
                Telphone = "18610756145"
            });
            var json =   JsonConvert.SerializeObject(plist);

            
            Console.ReadKey();
        }

    }

    public class Publisher
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Telphone { get; set; }
    }
    public class Result : IElasticsearchResponse
    {
        public IApiCallDetails ApiCall { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool TryGetServerErrorReason(out string reason)
        {
            throw new NotImplementedException();
        }
    }
    public class UserInifo : PostData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }

        public override void Write(Stream writableStream, IConnectionConfigurationValues settings)
        {
            throw new NotImplementedException();
        }

        public override Task WriteAsync(Stream writableStream, IConnectionConfigurationValues settings, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
