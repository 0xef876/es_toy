using System;
using Nest;

namespace Read
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
                .DefaultIndex("stock")
                .BasicAuthentication("elastic", "241900");

            var client = new ElasticClient(connectionSettings);

            // 검색 쿼리 작성
            var searchResponse = client.Search<MyDocument>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.company)
                        .Query("Kitty2")
                    )
                )
            );

            // 검색 결과 출력
            foreach (var hit in searchResponse.Hits)
            {
                Console.WriteLine($"Company: {hit.Source.company}, Code: {hit.Source.code}");
            }
        }
    }
}
