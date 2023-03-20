using System;
using Nest;

namespace Create
{
    public class MyDocument
    {
        public string company { get; set; }
        public string code { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri)
                .BasicAuthentication("elastic", "241900")
                .DefaultIndex("stock");

            var client = new ElasticClient(connectionSettings);

            // 인덱스 생성 또는 업데이트
            var createIndexResponse = client.Indices.Create("test", c => c
                .Settings(s => s
                    .NumberOfShards(1)
                    .NumberOfReplicas(0)
                )
                .Map<MyDocument>(m => m
                    .AutoMap()
                )
            );

            // 문서 추가
            var document = new MyDocument
            {
                company = "Kitty2",
                code = "88888"
            };
            client.IndexDocument(document);
        }
    }
}
