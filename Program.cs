using System;
using Elasticsearch.Net;
using Nest;
namespace es_toy
{
    class Program
    {
        static void Main(string[] args)
        {
           var uri = new Uri("http://localhost:9200");
var connectionSettings = new ConnectionSettings(uri)
    .BasicAuthentication("elastic", "241900")
    .DefaultIndex("stock");

var client = new ElasticClient(connectionSettings);
var query = @"{
                    ""match"": {
                        ""company"": ""삼성전자""
                    }
}";

var searchResponse = client.Search<MyDocument>(s => s
    .Query(q => q
        .Raw($"{query}")
    )
);
foreach (var hit in searchResponse.Hits)
{
    Console.WriteLine($"Company : {hit.Source.company}, Code: {hit.Source.code}");
}
        }
    }
       public class MyDocument
    {
        public string company { get; set; }
        public string code { get; set; }
    }
}