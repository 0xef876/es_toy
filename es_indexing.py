from elasticsearch import Elasticsearch
# 엘라스틱서치 연결
es = Elasticsearch(hosts=["https://localhost:9200"],verify_certs=False,http_auth=("elastic", "241900"))

# 데이터
data = {
    "company": "Apple",
    "date": "2021-01-01",
    "price": 134.33
}

# 데이터를 색인
es.index(index="my_index", id=1, body=data)
