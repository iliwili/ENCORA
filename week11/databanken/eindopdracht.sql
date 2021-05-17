/* DEEL 2 */
CREATE DATABASE eindopdracht;

/* gemeente tabel importen */

/* gemeente table naam veranderen */
RENAME TABLE t_gemeenten__15695__0 to t_gemeente;
/* een PK toevoegen */
ALTER TABLE t_gemeente ADD PRIMARY KEY(D_Gemeente);
/* persoonData tabel */
CREATE TABLE t_persoonData(
    persoonID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    d_voornaam VARCHAR(100),
    d_achternaam VARCHAR(100),
    d_geslacht VARCHAR(1),
    d_straatnaam VARCHAR(100),
    d_huisnummer INT(4),
    FK_gemeenteID INT(4),
    d_email	VARCHAR(100),
    d_telefoonnummer VARCHAR(50),
	FOREIGN KEY (FK_gemeenteID) REFERENCES t_gemeente(D_gemeente)
);

/* docent tabel ow */
CREATE TABLE t_docent(
	docentID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    d_stamboeknummer INT(11),
    d_docent_sinds DATETIME,
    FK_persoonID INT,
	FOREIGN KEY (FK_persoonID) REFERENCES t_persoonData(persoonID)
);

/* cursus tabel */
CREATE TABLE t_cursus(
	cursusID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	d_cursustitel VARCHAR(150),
	d_aantal_dagen INT,
	d_cursus_prijs DECIMAL(10, 2),
	d_omschrijving VARCHAR(6000)
);

/* cursusDocent tabel */
CREATE TABLE t_cursusDocent(
	cursusDocentID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	FK_cursusID INT,
	FK_docentID INT,
	FOREIGN KEY (FK_cursusID) REFERENCES t_cursus(cursusID),
	FOREIGN KEY (FK_docentID) REFERENCES t_docent(docentID)
);

/* uitvoering tabel */
CREATE TABLE t_uitvoering(
	uitvoeringID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	d_startdatum DATETIME,
	FK_cursusID INT,
	FOREIGN KEY (FK_cursusID) REFERENCES t_cursus(cursusID)
);

/* lesplaats tabel */
CREATE TABLE t_lesplaats(
	lesplaatsID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	d_campusnaam VARCHAR(100),
	d_straatnaam VARCHAR(100),
	d_huisnummer INT(4),
	FK_gemeenteID INT,
	d_email VARCHAR(100),
	d_telefoonnummer VARCHAR(50),
	FOREIGN KEY (FK_gemeenteID) REFERENCES t_gemeente(D_Gemeente)
);

/* lesmoment tabel */
CREATE TABLE t_lesmoment(
	lesmomentID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	d_lesdatum DATETIME,
	FK_uitvoeringID INT,
	FK_docentID INT,
	FK_lesplaatsID INT,
	FOREIGN KEY (FK_uitvoeringID) REFERENCES t_uitvoering(uitvoeringID),
	FOREIGN KEY (FK_docentID) REFERENCES t_docent(docentID),
	FOREIGN KEY (FK_lesplaatsID) REFERENCES t_lesplaats(lesplaatsID)
);

/* inschrijving tabel */
CREATE TABLE t_inschrijving(
	inschrijvingID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	d_inschrijfdatum DATETIME,
	FK_uitvoeringID INT,
	FK_persoonID INT,
	FOREIGN KEY (FK_uitvoeringID) REFERENCES t_uitvoering(uitvoeringID),
	FOREIGN KEY (FK_persoonID) REFERENCES t_persoonData(persoonID)
);

/* lesplaats tabel vullen */
INSERT INTO t_lesplaats(d_campusnaam, d_straatnaam, d_huisnummer, FK_gemeenteID, d_email, d_telefoonnummer)
VALUES('Campus Grotesteenweg', 'Grotesteenweg', 224, 214, 'encora@so.antwerpen.be', 033343434),
('Campus Grotesteenweg 226 (NT2)', 'Grotesteenweg', 226, 214, 'encora.administratieNT2@so.antwerpen.be', 033343310),
('Campus Eikenstraat', 'Eikenstraat', 8, 59,'encora@so.antwerpen.be', 033343434),
('Lesplaats d’Herbouvillekaai', 'd’Herbouvillekaai', 94, 61, '', 033343434),
('Lesplaats Gildekamersstraat ingang via Kaasstraat', 'Gildekamersstraat', 0, 59, '', 033343434),
('Lesplaats Kipdorpvest', 'Kipdorpvest', 24, 59, 'encora.administratieNT2@so.antwerpen.be', 032923100),
('Lesplaats Desguinlei', 'Desguinlei', 33, 60, 'encora.administratieNT2@so.antwerpen.be', 032891440),
('Lesplaats Van Aerdtstraat', 'Van Aerdtstraat', 63, 65, 'encora.administratieNT2@so.antwerpen.be', 034328520);

/* Maak 5 records aan voor cursussen en personen. 1 ervan ben jezelf en
1 ervan heeft mijn naam: Kristoff Bruyninckx, de rest is fictief. */
INSERT INTO t_persoonData(d_voornaam, d_achternaam, d_geslacht, d_straatnaam, d_huisnummer, FK_gemeenteID, d_email, d_telefoonnummer)
VALUES('Ilias', 'El Makrini', 'M', 'straat', 20, 65, 'ilias0258@gmail.com', 04632546854),
('Kristoff', 'Bruyninckx', 'M', 'straat', 30, 62, 'kristoff@gmail.com', 0451256489),
('Alejandro', 'De Haan', 'M', 'straat', 35, 95, 'test@gmail.com', 0452635874),
('Tom', 'De Wolf', 'M', 'straat', 40, 105, 'tom@gmail.com', 0445879563),
('Sarah', 'Test', 'V', 'straat', 50, 385, 'sarah@gmail.com', 0485795632),
('Bro', 'Jaa', 'V', 'straat', 60, 386, 'bro@gmail.com', 0485795632);

/* De cursussen hebben 3,4 of 5 aantal lesdagen */

VALUES('Frans', 4, 50, 'Dit is een omschrijving.'),
('IT', 3, 350, 'Dit is een omschrijving.'),
('Software', 5, 550, 'Dit is een omschrijving.'),
('Web', 4, 450, 'Dit is een omschrijving.'),
('Management', 3, 300, 'Dit is een omschrijving.');

/* Er zijn bij de personen 2 docenten. Gebruik Kristof Bruyninckx als 1
van de docenten. */
INSERT INTO t_docent(d_stamboeknummer, d_docent_sinds, FK_persoonID)
VALUES(5035, '2015-11-05 00:00:00', 2),
(5036, '2018-12-05 00:00:00', 4)

/* Ik geef 3 cursussen, docent 2 geeft 4 cursussen. */
INSERT INTO t_cursusDocent(FK_cursusID, FK_docentID)
VALUES(1,1),
(2,1),
(3,1),
(4,2),
(3,2)


/* Maak voor 2 cursussen 2 verschillende uitvoeringsversies aan.
Minstens 1 van deze cursussen wordt door beide docenten gegeven. */
INSERT INTO t_uitvoering(d_startdatum, FK_cursusID)
VALUES('2020-09-04 08:20:00', 3),
('2020-09-07 09:30:00',1),
('2020-10-01 10:00:00',3),
('2020-09-16 11:00:00',1);

/* Maak voor de uitvoeringsversies telkens het aantal lesdagen aan.
Neem ongeveer een week tussen de lessen.
Een docent geeft maar 1 uitvoeringsversie. */
INSERT INTO t_lesmoment(d_lesdatum, FK_uitvoeringID, FK_docentID, FK_lesplaatsID)
VALUES('2020-09-04 08:20:00', 1, 1, 2),
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
('2020-09-16 11:00:00', 4, 1, 6);

/* Maak voor de 3 overige personen én 1 docent een inschrijving in een 
uitvoeringsversie van een cursus aan.
Jijzelf volgt beide cursussen. */
INSERT INTO t_inschrijving(d_inschrijfdatum, FK_uitvoeringID, FK_persoonID)
VALUES('2020-08-28 09:00:00', 1, 1),
('2020-08-28 09:10:00', 2, 1),
('2020-07-01 08:30:00', 1, 3),
('2020-09-01 10:00:00', 3, 5),
('2020-09-05 08:00:00', 4, 4);

/* DEEL 3 */
/* Toon Brussel en alle deelgemeenten en de postcode uit de tabel met gemeenten. */
SELECT * FROM `t_gemeente` WHERE D_GemeenteNaam LIKE '%Brussel%';

/* Toon alle personen hun voor- en achternaam en het e-mailadres. Sorteer op achternaam. */
SELECT d_voornaam, d_achternaam, d_email 
FROM t_persoondata
ORDER BY 2;

/* Toon alle informatie over de cursussen gesorteerd op cursustitel. */
SELECT *
FROM t_cursus
ORDER BY d_cursustitel;

/* Pas de naam van een zelfgekozen cursus aan naar “databankbeheer met SQL”. */
UPDATE t_cursus
SET d_cursustitel = 'databankbeheer met SQL'
WHERE d_cursustitel = 'Frans';

/* Toon alle cursussen die tussen de 100 en 500 euro kosten, toon ook de prijs. */
SELECT d_cursustitel, d_cursus_prijs
FROM t_cursus
WHERE d_cursus_prijs >= 100 AND d_cursus_prijs <= 500;

/* . Bij het vorige deel is mijn naam fout geschreven. Pas de naam van Kristof Bruyninckx aan naar Kristoff. */
UPDATE t_persoondata
SET d_voornaam = 'Kristoff'
WHERE d_voornaam = 'Kristof';

/* Joins & aliassen (20%) */
/* Toon een lijst van van de lesdagen, de cursusnaam en de lesplaats van
alle cursussen.
Sorteer deze op lesdagen. */
SELECT m.d_lesdatum, l.d_campusnaam, c.d_cursustitel 
FROM t_lesmoment AS m JOIN t_lesplaats l JOIN t_uitvoering AS u JOIN t_cursus AS c
WHERE m.FK_lesplaatsID = l.lesplaatsID AND m.FK_uitvoeringID = u.uitvoeringID AND u.FK_cursusID = c.cursusID
ORDER BY m.d_lesdatum;

/* Maak een overzicht over jezelf van alle lesdagen.
Toon de lesdagen, de cursusnaam en lesplaats(naam en adres).
Sorteer op lesdagen. */
SELECT CONCAT(p.d_voornaam, CONCAT(' ', p.d_achternaam)) Naam, u.d_startdatum Lesdag, c.d_cursustitel Cursus, CONCAT(CONCAT(l.d_campusnaam, CONCAT(CONCAT(' ', l.d_straatnaam), CONCAT(', ', CONCAT(l.d_huisnummer, CONCAT(' ', g.D_Postnummer)))))) Lesplaats
FROM t_uitvoering AS u JOIN t_lesmoment AS m JOIN t_lesplaats l JOIN t_gemeente AS g JOIN t_cursus AS c JOIN t_inschrijving AS i JOIN t_persoondata AS p
WHERE u.uitvoeringID = m.FK_uitvoeringID AND m.FK_lesplaatsID = l.lesplaatsID AND l.FK_gemeenteID = g.D_Gemeente AND c.cursusID = u.FK_cursusID AND u.uitvoeringID = i.FK_uitvoeringID AND i.FK_persoonID = 1 AND p.persoonID = i.FK_persoonID;

/* Maak een overzicht voor de docent die les geeft en les volgt.
Toon lesdagen, cursusnaam en rol(cursist of docent).
Sorteer op lesdagen. */

/* Maak een query voor alle personen afkomstig uit Brussel of de
deelgemeenten. */
SELECT p.d_voornaam, p.d_achternaam, g.D_GemeenteNaam, g.D_Postnummer
FROM t_persoondata AS p JOIN t_gemeente AS g
WHERE p.FK_gemeenteID = g.D_Gemeente AND g.D_GemeenteNaam LIKE '%Brussel%';

/* Uitbreiding(4B): Toon de cursussen van deze personen en de
lesplaatsen.  */

/* Schrijf een query die zoekt naar de voornaam en achternaam van
personen die geen docent zijn én die ook niet ingeschreven zijn als
student voor een cursus. */
SELECT p.d_voornaam, p.d_achternaam
FROM t_persoondata AS p
WHERE p.persoonID NOT IN (SELECT d.FK_persoonID 
                          FROM t_docent d 
                          WHERE p.persoonID = d.FK_persoonID) 
                  AND p.persoonID NOT IN (SELECT i.FK_persoonID 
                                          FROM t_inschrijving AS i 
                                          WHERE p.persoonID = i.FK_persoonID);

/* Pas de vorige sql query aan zodanig dat de personen die geen docent
zijn en die ook niet ingeschreven zijn in een cursus, verwijderd
worden uit de tabel met personen. */
DELETE FROM t_persoonData
WHERE persoonID NOT IN (SELECT d.FK_persoonID 
                          FROM t_docent d 
                          WHERE persoonID = d.FK_persoonID) 
				AND persoonID NOT IN (SELECT i.FK_persoonID 
									  FROM t_inschrijving AS i 
                                      WHERE persoonID = i.FK_persoonID);
/* Selecteren met functies (20%) */
/* Maak een query van het aantal personen uit Brussel en de deelgemeenten.
Toon de voor- en achternaam, de gemeente en het aantal personen per gemeente. */
SELECT p.d_voornaam, p.d_achternaam, g.D_GemeenteNaam, COUNT(*) 'Aantal personen'
FROM t_persoondata AS p INNER JOIN t_gemeente AS g 
WHERE p.FK_gemeenteID = g.D_Gemeente AND D_GemeenteNaam LIKE '%Brussel%'
GROUP BY p.d_voornaam, p.d_achternaam;

/* Toon de titel en de prijs per dag, niet de volledige prijs, van de
goedkoopste cursus. */
SELECT d_cursustitel, MIN(d_cursus_prijs/d_aantal_dagen) 'Prijs per dag'
FROM t_cursus;

/* Maak een query die weergeeft wat de gemiddelde dagprijs van de
cursussen is. Rond af op 2 decimalen én voeg het euro-symbool toe */
SELECT ROUND(AVG(d_cursus_prijs/d_aantal_dagen), 2) 'Gemiddelde prijs per dag'
FROM t_cursus;

/* Maak een query die alle cursussen van 3 dagen én met een dagprijs
lager dan de gemiddelde dagprijs weergeven. Toon de naam, duur en
dagprijs. */

/* Pas de vorige query aan zodat je ook de som van alle dagprijzen
toont. Voeg de tekst weekprijs toe aan deze uitkomst. */

/* Maak een query voor de docent die ook voor cursussen ingeschreven
is. Ga hier na of er een conflict is tussen geplande lesdagen dat er les
gegeven en les gevolgd wordt. Toon dan de tekst conflict of geen
conflict. */

/* Maak een query die controleert of het aantal dagen van alle cursussen
met “databank” in de titel overeenkomt met de ingeplande lesdagen. */