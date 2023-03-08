from elasticsearch import Elasticsearch
import es_data
es = Elasticsearch(hosts=["https://localhost:9200"],verify_certs=False,http_auth=("elastic", "241900"))

data = es_data.load_data()
for i in range(1,len(data)):
    es.index(index="stock", id=i, body=data[i-1])


