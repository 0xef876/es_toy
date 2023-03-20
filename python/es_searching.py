from elasticsearch import Elasticsearch

# Elasticsearch 연결
es = Elasticsearch(hosts=["https://localhost:9200"],verify_certs=False,http_auth=("elastic", "241900"))

# 검색 쿼리
query = {
    "query": {
        "match_all": {}
    }
}

# 검색 실행
result = es.search(index="my_index", body=query)

# 검색 결과 출력
for hit in result["hits"]["hits"]:
    print(hit["_source"])
