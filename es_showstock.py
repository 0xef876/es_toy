from elasticsearch import Elasticsearch
es = Elasticsearch(hosts=["https://localhost:9200"],verify_certs=False,http_auth=("elastic", "241900"))

# 검색 쿼리
query = {
    "query": {
        "match": {"company":'삼성전자'}
    }
}

# 검색 실행
result = es.search(index="stock", body=query)
for hit in result["hits"]["hits"]:
    print(hit["_source"])
