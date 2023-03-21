using System;
using Elasticsearch.Net;
using System.Linq;

using Nest;

namespace Update
{
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

            // 검색 결과에서 도큐먼트 ID 가져오기
            var documentId = searchResponse.Hits.First().Id;

                    // 업데이트할 필드와 값을 지정
            var updateRequest = new UpdateRequest<MyDocument, object>(documentId)
            {
                Doc = new { code = "123456789" }
            };

            // Elasticsearch 클라이언트를 사용하여 업데이트 요청 전송
            var updateResponse = client.Update<MyDocument, object>(updateRequest);

            Console.WriteLine($"Updated: {updateResponse.Result}");
        }
    }
        public class MyDocument
    {
        public string company { get; set; }
        public string code { get; set; }
    }
}   
