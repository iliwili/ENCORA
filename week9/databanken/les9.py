import mysql.connector

mijnDB = mysql.connector.connect(
    host="localhost",
    user="root",
    password="",
    database = "function_db"
)

mijnCursor = mijnDB.cursor()

mijnCursor.execute("SELECT * FROM producten")

mijnResultaat = mijnCursor.fetchall()

for record in mijnResultaat:
    print(record)

