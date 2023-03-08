import pymysql,json
def load_data():
    con = pymysql.connect(host='adminkitty.iptime.org', user='kitty', password='??',db='investar', charset='utf8') 
    cur = con.cursor()
    sql = "SELECT code, company FROM kr_company_info"
    cur.execute(sql)
    
    rows = cur.fetchall()
    Data = []
    for i in rows:
        code,company = i[0],i[1]

        data = {
        "code" : code,
        "company" : company,
        }
        Data.append(json.dumps(data,ensure_ascii=False))
    con.close()
    return Data
