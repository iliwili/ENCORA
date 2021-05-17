import mysql.connector

myDB = mysql.connector.connect(
            host="localhost",
            user="root",
            password="",
            database="encoraBis"
        )

myCursor = myDB.cursor()

# # Toon Brussel en alle deelgemeenten en de postcode uit de tabel met gemeenten.
# myCursor.execute('SELECT * FROM `t_gemeente` WHERE D_GemeenteNaam LIKE "%Brussel%";')
# myResult = myCursor.fetchall()
# print(myResult)

# # Toon alle personen hun voor- en achternaam en het e-mailadres. Sorteer op achternaam.
# myCursor.execute('SELECT d_voornaam, d_achternaam, d_email FROM t_persoondata ORDER BY 2;')
# myResult = myCursor.fetchall()
# print(myResult)

# # Toon alle informatie over de cursussen gesorteerd op cursustitel.
# myCursor.execute('SELECT * FROM t_cursus ORDER BY d_cursustitel;')
# myResult = myCursor.fetchall()
# print(myResult)

# # Pas de naam van een zelfgekozen cursus aan naar “databankbeheer met SQL”.
# myCursor.execute('UPDATE t_cursus SET d_cursustitel = "databankbeheer met SQL" WHERE d_cursustitel = "Frans";')
# myDB.commit()

# # Toon alle cursussen die tussen de 100 en 500 euro kosten, toon ook de prijs.
# myCursor.execute('SELECT d_cursustitel, d_cursus_prijs FROM t_cursus WHERE d_cursus_prijs >= 100 AND d_cursus_prijs <= 500;')
# myResult = myCursor.fetchall()
# print(myResult)

# # Bij het vorige deel is mijn naam fout geschreven. Pas de naam van Kristof Bruyninckx aan naar Kristoff.
# myCursor.execute('UPDATE t_persoondata SET d_voornaam = "Kristoff" WHERE d_voornaam = "Kristof";')
# myDB.commit()

# # Joins & aliassen (20%)

# # Toon een lijst van van de lesdagen, de cursusnaam en de lesplaats van alle cursussen.
# # Sorteer deze op lesdagen.
# myCursor.execute('SELECT m.d_lesdatum, l.d_campusnaam, c.d_cursustitel ' \
# 'FROM t_lesmoment AS m JOIN t_lesplaats l JOIN t_uitvoering AS u JOIN t_cursus AS c ' \
# 'WHERE m.FK_lesplaatsID = l.lesplaatsID AND m.FK_uitvoeringID = u.uitvoeringID AND u.FK_cursusID = c.cursusID ' \
# 'ORDER BY m.d_lesdatum;')

# myResult = myCursor.fetchall()
# print(myResult)

# # Maak een overzicht over jezelf van alle lesdagen. Toon de lesdagen, de cursusnaam en lesplaats(naam en adres).
# # Sorteer op lesdagen.
# # deze werkt niet in python voor een of andere reden
# myCursor.execute('SELECT CONCAT(p.d_voornaam, CONCAT(' ', p.d_achternaam)) Naam, u.d_startdatum Lesdag, c.d_cursustitel Cursus, CONCAT(CONCAT(l.d_campusnaam, CONCAT(CONCAT(' ', l.d_straatnaam), CONCAT(', ', CONCAT(l.d_huisnummer, CONCAT(' ', g.D_Postnummer)))))) Lesplaats FROM t_uitvoering AS u JOIN t_lesmoment AS m JOIN t_lesplaats l JOIN t_gemeente AS g JOIN t_cursus AS c JOIN t_inschrijving AS i JOIN t_persoondata AS p WHERE u.uitvoeringID = m.FK_uitvoeringID AND m.FK_lesplaatsID = l.lesplaatsID AND l.FK_gemeenteID = g.D_Gemeente AND c.cursusID = u.FK_cursusID AND u.uitvoeringID = i.FK_uitvoeringID AND i.FK_persoonID = 1 AND p.persoonID = i.FK_persoonID ORDER BY u.d_startdatum ASC')
# myResult = myCursor.fetchall()
# print(myResult)

# # Maak een overzicht voor de docent die les geeft en les volgt. Toon lesdagen, cursusnaam en rol(cursist of docent).
# # Sorteer op lesdagen.

# # Maak een query voor alle personen afkomstig uit Brussel of de deelgemeenten
# myCursor.execute('SELECT p.d_voornaam, p.d_achternaam, g.D_GemeenteNaam, g.D_Postnummer FROM t_persoondata AS p JOIN t_gemeente AS g WHERE p.FK_gemeenteID = g.D_Gemeente AND g.D_GemeenteNaam LIKE "%Brussel%";')
# myResult = myCursor.fetchall()
# print(myResult)

# # Uitbreiding(4B): Toon de cursussen van deze personen en de lesplaatsen.

# # Schrijf een query die zoekt naar de voornaam en achternaam van personen die geen docent zijn én die ook niet ingeschreven zijn als student voor een cursus.
# myCursor.execute('SELECT p.d_voornaam, p.d_achternaam ' \
# 'FROM t_persoondata AS p ' \
# 'WHERE p.persoonID NOT IN (SELECT d.FK_persoonID ' \
#                           'FROM t_docent d ' \
#                           'WHERE p.persoonID = d.FK_persoonID) ' \
#                   'AND p.persoonID NOT IN (SELECT i.FK_persoonID ' \
#                                           'FROM t_inschrijving AS i ' \
#                                           'WHERE p.persoonID = i.FK_persoonID);')
# myResult = myCursor.fetchall()
# print(myResult)

# # Pas de vorige sql query aan zodanig dat de personen die geen docent zijn en die ook niet ingeschreven zijn in een cursus, verwijderd worden uit de tabel met personen.
# myCursor.execute('DELETE FROM t_persoonData ' \
# 'WHERE persoonID NOT IN (SELECT d.FK_persoonID ' \
#                           'FROM t_docent d ' \
#                           'WHERE persoonID = d.FK_persoonID) AND persoonID NOT IN (SELECT i.FK_persoonID ' \
#                                                                                     'FROM t_inschrijving AS i ' \
#                                                                                     'WHERE persoonID = i.FK_persoonID);')
# myDB.commit()

# # Selecteren met functies (20%)
# # Maak een query van het aantal personen uit Brussel en de deelgemeenten.
# # Toon de voor- en achternaam, de gemeente en het aantal personen per gemeente.
# myCursor.execute('SELECT p.d_voornaam, p.d_achternaam, g.D_GemeenteNaam, COUNT(*) "Aantal personen" ' \
# 'FROM t_persoondata AS p INNER JOIN t_gemeente AS g ' \
# 'WHERE p.FK_gemeenteID = g.D_Gemeente AND D_GemeenteNaam LIKE "%Brussel%" ' \
# 'GROUP BY p.d_voornaam, p.d_achternaam;')

# myResult = myCursor.fetchall()
# print(myResult)

# # Toon de titel en de prijs per dag, niet de volledige prijs, van de goedkoopste cursus.
# myCursor.execute('SELECT d_cursustitel, MIN(d_cursus_prijs/d_aantal_dagen) "Prijs per dag" FROM t_cursus;')

# myResult = myCursor.fetchall()
# print(myResult)

# # Maak een query die weergeeft wat de gemiddelde dagprijs van de cursussen is. Rond af op 2 decimalen én voeg het euro-symbool toe 
# myCursor.execute('SELECT CONCAT("$", ROUND(AVG(d_cursus_prijs/d_aantal_dagen), 2)) "Gemiddelde prijs per dag" FROM t_cursus;')
# myResult = myCursor.fetchall()
# print(myResult)