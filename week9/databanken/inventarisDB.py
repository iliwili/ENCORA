import mysql.connector

mijnDB = mysql.connector.connect(
    host="localhost",
    user="root",
    password="",
    database = "inventaris"
)

mijnCursor = mijnDB.cursor()

# # OEF1

# # MAAK EEN NIEUWE DATABANK MET DE NAAM INVENTARIS AAN.
# mijnCursor.execute("CREATE DATABASE inventaris")

# # MAAK EEM t_inventaris AAN EN VOEG EEN ID KOLOM TOE.
# mijnCursor.execute("CREATE TABLE t_inventaris(id_PK INT NOT NULL PRIMARY KEY AUTO_INCREMENT)")

# # VOEG AAN DE TABEL DE KOLOMMEN d_product, d_prijs EN d_btw TOE.
# mijnCursor.execute("ALTER TABLE t_inventaris ADD COLUMN d_product VARCHAR(255)")
# mijnCursor.execute("ALTER TABLE t_inventaris ADD COLUMN d_prijs DOUBLE")
# mijnCursor.execute("ALTER TABLE t_inventaris ADD COLUMN d_btw INT")

# # OEF2

# # VOEG IN DE TABEL INVENTARIS VAN DE VORIGE OEFENING 5 RIJEN MET VERSCHILLENDE WAARDES IN.
# sql = "INSERT INTO t_inventaris (d_product, d_prijs, d_btw) VALUES (%s, %s, %s)"
# values = [("product1", 100, 6), ("product2", 200, 21), ("product3", 300, 21), ("product4", 400, 21), ("product5", 500, 12)]

# mijnCursor.executemany(sql,values)

# mijnDB.commit()

# # UPDATE
# # VERANDER DE BTW VAN product2 NAAR 6% BTW.
# sql = "UPDATE t_inventaris SET d_btw = 6 WHERE d_product = 'product2'"
# mijnCursor.execute(sql)

# # VERANDER DE PRIJS VAN product3.
# sql = "UPDATE t_inventaris SET d_prijs = 301 WHERE d_product = 'product3'"
# mijnCursor.execute(sql)

# mijnDB.commit()

# # OEF3
# # ALLE WAARDEN TONEN
# mijnCursor.execute("SELECT * FROM t_inventaris")
# mijnResultaat = mijnCursor.fetchall()

# for record in mijnResultaat:
#     print(record)

# # ALLEEN DE PRODUCTNAMEN TONEN
# mijnCursor.execute("SELECT d_product FROM t_inventaris")
# mijnResultaat = mijnCursor.fetchall()

# for record in mijnResultaat:
#     print(record)