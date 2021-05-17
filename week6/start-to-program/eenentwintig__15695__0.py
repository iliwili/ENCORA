#VARIABELEN
#var met lijst voor waarden en var met lijst voor symbolen

#lege lijst voor samengestelde kaarten (boek kaarten)
#lege dictionairy voor hand van pc en speler

#vul de lijst voor samengestelde kaarten

#functie die ALLE kaarten in een hand toont, gebruik parameter om de speler of pc in te vullen


#functie die het totaal van alle kaarten in een hand teruggeeft, gebruik parameter om de speler of pc in te vullen
    #10 punten als de waarde boer, koningin of koning is.
    #punten als het een aas is
        #als het totaal 11 of meer is +1
        #anders het totaal met 10 vermeerderen
    #anders de waarde bij het totaal optellen

#functie om het totaal te tonen

#starten met spelen(het spel wordt waar)

#zolang het spel duurt:
    #kaarten schudden

    #kaarten uitdelen, om beurten een kaart aan de pc en speler geven en die uit de kaartenlijst verwijderen

    #start de beurt van de speler
    #zolang de speler speelt:
        #toon hand
        #toon totaal

        #vraag speler input

        #als de speler een kaart vraagt geef een kaart en verwijder uit de kaartenlijst(boek kaarten)
            #als het totaal meer dan 21 is heeft is de speler zijn beurt voorbij en is hij 'kapot'
        #anders als de speler geen kaart vraagt is de speler zijn beurt voorbij

        #anders is het spel voorbij en sluit het programma af

    #beurt van de computer starten

    #zolang pc speelt en de speler is niet kapot is
        #toon hand van de pc
        #toon totaal van de pc

        #als het totaal van de pc kleiner is dan het totaal van de speler
            #neem een kaart uit de kaartelijst en verwijder ze uit die lijst

        #anders is de beurt van de pc voorbij

        #als de pc meer dan 21 heeft is hij 'kapot'

    #als de speler kapot waar is:
        #tel score op bij pc
        #print speler busted
    #anders als de pc kapot waar is:
        #tel score op bij speler
        #print pc busted
    #anders als het totaal vd speler meer is dan het totaal vd pc:
        #print gewonnen
        #tel score op bij speler
    #anders:
        #print pc wint
        #tel score op bij pc

    #Vraag of de speler opnieuw wil spelen:
        #als het antwoord nee is stop het spel (spelen is niet meer waar)


    #kaartenlijst aanvullen met de lijst van de hand van de pc
    #kaartenlijst aanvullen met de lijst van de hand van de speler

    #maak de hand van de speler leeg
    #maak de hand van de pc leeg
