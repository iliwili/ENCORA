import mysql.connector
import csv

def reconnectToDB(db):
    if (len(db) == 0):
        return mysql.connector.connect(
            host="localhost",
            user="root",
            password="",
        )
    else:
        return mysql.connector.connect(
            host="localhost",
            user="root",
            password="",
            database=db
        )
    

myDB = reconnectToDB("")

myCursor = myDB.cursor()

myCursor.execute('DROP DATABASE IF EXISTS encoraBis;')
myCursor.execute("CREATE DATABASE encoraBis");

myDB = reconnectToDB("encoraBis")

myCursor = myDB.cursor()

# GEMEENTE DB
myCursor.execute('CREATE TABLE t_gemeente (D_Gemeente INT(4) NOT NULL PRIMARY KEY, D_Postnummer INT(4), D_GemeenteNaam VARCHAR(50), D_LandCode VARCHAR(3))')
with open('t_gemeenten__15695__0.csv') as csv_file:
    csv_data = csv.reader(csv_file, delimiter=';')
    next(csv_data)
    gemeentes = []
    for row in csv_data:
        gemeentes.append((int(row[0]), int(row[1]), row[2], row[3]))
    
    for gemeente in gemeentes:
        myCursor.execute('INSERT INTO t_gemeente(D_Gemeente, D_Postnummer, D_GemeenteNaam, D_LandCode) VALUES("%s", "%s", "%s", "%s")', gemeente)

# PERSOONDATA TABLE
myCursor.execute('CREATE TABLE t_persoonData(' \
    'persoonID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,' \
    'd_voornaam VARCHAR(100),' \
    'd_achternaam VARCHAR(100),' \
    'd_geslacht VARCHAR(1),' \
    'd_straatnaam VARCHAR(100),' \
    'd_huisnummer INT(4),' \
    'FK_gemeenteID INT(4),' \
    'd_email	VARCHAR(100),' \
    'd_telefoonnummer VARCHAR(50),' \
	'FOREIGN KEY (FK_gemeenteID) REFERENCES t_gemeente(D_gemeente)' \
');')

# DOCENT TABLE
myCursor.execute('CREATE TABLE t_docent(' \
	'docentID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,' \
    'd_stamboeknummer INT(11),' \
    'd_docent_sinds DATETIME,' \
    'FK_persoonID INT,' \
	'FOREIGN KEY (FK_persoonID) REFERENCES t_persoonData(persoonID)' \
');')

# CURSUS TABLE
myCursor.execute('CREATE TABLE t_cursus(' \
	'cursusID INT NOT NULL AUTO_INCREMENT PRIMARY KEY, ' \
	'd_cursustitel VARCHAR(150),' \
	'd_aantal_dagen INT,' \
	'd_cursus_prijs DECIMAL(10, 2),' \
	'd_omschrijving VARCHAR(6000)' \
');')

# CURSUSDOCENT TABLE
myCursor.execute('CREATE TABLE t_cursusDocent(' \
	'cursusDocentID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,' \
	'FK_cursusID INT,' \
	'FK_docentID INT,' \
	'FOREIGN KEY (FK_cursusID) REFERENCES t_cursus(cursusID),' \
	'FOREIGN KEY (FK_docentID) REFERENCES t_docent(docentID)' \
');')

# UITVOERING TABLE
myCursor.execute('CREATE TABLE t_uitvoering(' \
	'uitvoeringID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,' \
	'd_startdatum DATETIME,' \
	'FK_cursusID INT,' \
	'FOREIGN KEY (FK_cursusID) REFERENCES t_cursus(cursusID)' \
');')

# LESPLAATS TABLE
myCursor.execute('CREATE TABLE t_lesplaats(' \
	'lesplaatsID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,' \
	'd_campusnaam VARCHAR(100),' \
	'd_straatnaam VARCHAR(100),' \
	'd_huisnummer INT(4),' \
	'FK_gemeenteID INT,' \
	'd_email VARCHAR(100),' \
	'd_telefoonnummer VARCHAR(50),' \
	'FOREIGN KEY (FK_gemeenteID) REFERENCES t_gemeente(D_Gemeente)' \
');')

# LESMOMENT TABLE
myCursor.execute('CREATE TABLE t_lesmoment(' \
	'lesmomentID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,' \
	'd_lesdatum DATETIME,' \
	'FK_uitvoeringID INT,' \
	'FK_docentID INT,' \
	'FK_lesplaatsID INT,' \
	'FOREIGN KEY (FK_uitvoeringID) REFERENCES t_uitvoering(uitvoeringID),' \
	'FOREIGN KEY (FK_docentID) REFERENCES t_docent(docentID),' \
	'FOREIGN KEY (FK_lesplaatsID) REFERENCES t_lesplaats(lesplaatsID)' \
');')

# INSCHRIJVING TABLE
myCursor.execute('CREATE TABLE t_inschrijving(' \
	'inschrijvingID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,' \
	'd_inschrijfdatum DATETIME,' \
	'FK_uitvoeringID INT,' \
	'FK_persoonID INT,' \
	'FOREIGN KEY (FK_uitvoeringID) REFERENCES t_uitvoering(uitvoeringID),' \
	'FOREIGN KEY (FK_persoonID) REFERENCES t_persoonData(persoonID)' \
');')

# lesplaats tabel vullen
sql = "INSERT INTO t_lesplaats(d_campusnaam, d_straatnaam, d_huisnummer, FK_gemeenteID, d_email, d_telefoonnummer) VALUES (%s, %s, %s, %s, %s, %s)"
values = [
    ('Campus Grotesteenweg', 'Grotesteenweg', 224, 214, 'encora@so.antwerpen.be', 33343434), 
    ('Campus Grotesteenweg 226 (NT2)', 'Grotesteenweg', 226, 214, 'encora.administratieNT2@so.antwerpen.be', 33343310), 
    ('Campus Eikenstraat', 'Eikenstraat', 8, 59,'encora@so.antwerpen.be', 33343434), 
    ('Lesplaats d’Herbouvillekaai', 'd’Herbouvillekaai', 94, 61, '', 33343434), 
    ('Lesplaats Gildekamersstraat ingang via Kaasstraat', 'Gildekamersstraat', 0, 59, '', 33343434),
    ('Lesplaats Kipdorpvest', 'Kipdorpvest', 24, 59, 'encora.administratieNT2@so.antwerpen.be', 32923100),
    ('Lesplaats Desguinlei', 'Desguinlei', 33, 60, 'encora.administratieNT2@so.antwerpen.be', 32891440),
    ('Lesplaats Van Aerdtstraat', 'Van Aerdtstraat', 63, 65, 'encora.administratieNT2@so.antwerpen.be', 34328520)
    ]
myCursor.executemany(sql,values)

# Maak 5 records aan voor cursussen en personen. 1 ervan ben jezelf en
# 1 ervan heeft mijn naam: Kristoff Bruyninckx, de rest is fictief.
sql = "INSERT INTO t_persoonData(d_voornaam, d_achternaam, d_geslacht, d_straatnaam, d_huisnummer, FK_gemeenteID, d_email, d_telefoonnummer) VALUES (%s, %s, %s, %s, %s, %s, %s, %s)"
values = [
    ('Ilias', 'El Makrini', 'M', 'straat', 20, 65, 'ilias0258@gmail.com', 4632546854),
    ('Kristoff', 'Bruyninckx', 'M', 'straat', 30, 62, 'kristoff@gmail.com', 451256489),
    ('Alejandro', 'De Haan', 'M', 'straat', 35, 95, 'test@gmail.com', 452635874),
    ('Tom', 'De Wolf', 'M', 'straat', 40, 105, 'tom@gmail.com', 445879563),
    ('Sarah', 'Test', 'V', 'straat', 50, 385, 'sarah@gmail.com', 485795632),
    ('Bro', 'Jaa', 'V', 'straat', 60, 386, 'bro@gmail.com', 485795632)
    ]
myCursor.executemany(sql,values)

# De cursussen hebben 3,4 of 5 aantal lesdagen
sql = "INSERT INTO t_cursus(d_cursustitel, d_aantal_dagen, d_cursus_prijs, d_omschrijving) VALUES (%s, %s, %s, %s)"
values = [
    ('Frans', 4, 50, 'Dit is een omschrijving.'),
    ('IT', 3, 350, 'Dit is een omschrijving.'),
    ('Software', 5, 550, 'Dit is een omschrijving.'),
    ('Web', 4, 450, 'Dit is een omschrijving.'),
    ('Management', 3, 300, 'Dit is een omschrijving.')
    ]
myCursor.executemany(sql,values)

# Er zijn bij de personen 2 docenten. Gebruik Kristof Bruyninckx als 1 van de docenten.
sql = "INSERT INTO t_docent(d_stamboeknummer, d_docent_sinds, FK_persoonID) VALUES(%s, %s, %s)"
values = [
    (5035, '2015-11-05 00:00:00', 2),
    (5036, '2018-12-05 00:00:00', 4)
    ]
myCursor.executemany(sql, values)

# Ik geef 3 cursussen, docent 2 geeft 4 cursussen.
sql = "INSERT INTO t_cursusDocent(FK_cursusID, FK_docentID) VALUES(%s, %s)"
values = [
    (1,1),
    (2,1),
    (3,1),
    (4,2),
    (3,2)
    ]
myCursor.executemany(sql, values)

# Maak voor 2 cursussen 2 verschillende uitvoeringsversies aan. Minstens 1 van deze cursussen wordt door beide docenten gegeven.
sql = "INSERT INTO t_uitvoering(d_startdatum, FK_cursusID) VALUES(%s, %s)"
values = [
    ('2020-09-04 08:20:00', 3),
    ('2020-09-07 09:30:00',1),
    ('2020-10-01 10:00:00',3),
    ('2020-09-16 11:00:00',2)
    ]

myCursor.executemany(sql, values)

# Maak voor de uitvoeringsversies telkens het aantal lesdagen aan. Neem ongeveer een week tussen de lessen.
# Een docent geeft maar 1 uitvoeringsversie.
sql = "INSERT INTO t_lesmoment(d_lesdatum, FK_uitvoeringID, FK_docentID, FK_lesplaatsID) VALUES(%s, %s, %s, %s)"
values = [
    ('2020-09-04 08:20:00', 1, 1, 2),
    ('2020-09-11 08:20:00', 1, 1, 2),
    ('2020-09-18 08:20:00', 1, 1, 2),
    ('2020-09-25 08:20:00', 1, 1, 2),
    ('2020-10-02 08:20:00', 1, 1, 2),
    ('2020-09-07 09:30:00', 2, 1, 2),
    ('2020-09-14 09:30:00', 2, 1, 2),
    ('2020-09-21 09:30:00', 2, 1, 2),
    ('2020-10-01 10:00:00', 3, 2, 4),
    ('2020-10-08 10:00:00', 3, 2, 4),
    ('2020-10-15 10:00:00', 3, 2, 4),
    ('2020-10-22 10:00:00', 3, 2, 4),
    ('2020-10-29 10:00:00', 3, 2, 4),
    ('2020-09-16 11:00:00', 4, 1, 6),
    ('2020-09-16 11:00:00', 4, 1, 6),
    ('2020-09-16 11:00:00', 4, 1, 6)
    ]

myCursor.executemany(sql, values)

# Maak voor de 3 overige personen én 1 docent een inschrijving in een uitvoeringsversie van een cursus aan.
# Jijzelf volgt beide cursussen.
sql = "INSERT INTO t_inschrijving(d_inschrijfdatum, FK_uitvoeringID, FK_persoonID) VALUES(%s, %s, %s)"
values = [
    ('2020-08-28 09:00:00', 1, 1),
    ('2020-08-28 09:10:00', 2, 1),
    ('2020-07-01 08:30:00', 1, 3),
    ('2020-09-01 10:00:00', 3, 5),
    ('2020-09-05 08:00:00', 4, 4)
    ]

myCursor.executemany(sql, values)

# commit alles
myDB.commit()