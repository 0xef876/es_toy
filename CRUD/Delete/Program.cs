using System;
using System.Linq;
using Nest;

namespace Delete
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


            var documentId = searchResponse.Hits.First().Id;

            // 도큐먼트 삭제
            var deleteResponse = client.Delete<MyDocument>(documentId);

            Console.WriteLine($"Deleted: {deleteResponse.Result}");
        }
    }
}
