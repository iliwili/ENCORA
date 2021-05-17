import random, os, time

# INFO VOORAF:
# HET IS MOGELIJK OM DEZE GAME MET MEERDERE MENSEN TE SPELEN. ER IS WEL MAAR 1 DEALER.
# VOOR HET GEMAKKELIJK TE MAKEN HEB IK EEN LIJST MET DE SPELERS EN DE DEALER APART GEHOUDEN OM 
# HET OVERZICHTELIJK TE HOUDEN EN LIJNEN CODE TE BESPAREN.
# IK HEB OOK GEBRUIK GEMAAKT VAN TIME.SLEEP() DOORHEEN DE CODE OM HET WAT ECHTER TE LATEN LIJKEN MET EEN AANTAL DELAYS.

def kaartenSamenstellen(lijst, symbolen, nummers):
    for symbool in symbolen:
        for nummer in nummers:
            lijst.append((symbool, nummer))

def schudKaarten(lijst):
    for i in range(0,3):
        random.shuffle(lijst)

def verdeelKaarten(lijst, spelers, dealer):
    for i in range(0,2):
        for speler in spelers:
            speler['kaarten'].append(lijst.pop())
        dealer['kaarten'].append(lijst.pop())

def berekenWaarde(speler):
    waarde = 0
    for kaart in speler['kaarten']:
        nummer = kaart[0]
        if type(nummer) != str:
            waarde += nummer
    
    for kaart in speler['kaarten']:
        nummer = kaart[0]
        if type(nummer) == str:
            if nummer == 'koning' or nummer == 'koningin' or nummer == 'boer':
                waarde += 10
            else:
                if waarde < 11:
                    waarde += 10
                else:
                    waarde += 1

    return waarde

def toonHand(speler):
    print('\nHAND:', '\'' + speler['username'] + '\'', 'WAARDE: ', berekenWaarde(speler))
    print('KAARTEN: ', end = "")
    for kaart in speler['kaarten']:
        print(str(kaart[0]) + ' ' + str(kaart[1]) + ', ', end = "")
    print('\n')

# geeft de waarde van de eerst van een dealer. 
# Dit is nodig voor in het begin van de game waar de spelers nog niet beide kaarten mogen zien.
def berekenWaardeDealerOverzicht(dealer):
    waarde = 0
    nummer = dealer['kaarten'][0][0]
    if type(nummer) != str:
            waarde += nummer
    else:
        if nummer == 'koning' or nummer == 'koningin' or nummer == 'boer':
            waarde += 10
        else:
            waarde += 11

    return waarde

# Geeft een overzicht van de kaarten op het bord.
def overzichtGame(dealer, spelers, status):
    print('OVERZICHT GAME')

    dealerWaarde = status == 'begonnen' and berekenWaardeDealerOverzicht(dealer) or berekenWaarde(dealer)
    dealerKaarten = status == 'begonnen' and dealer['kaarten'][0] or dealer['kaarten']

    print('{:8} {} waarde: {}'.format(dealer['username'], str(dealerKaarten), dealerWaarde))
    for speler in spelers:
        print('{:8} {} waarde: {}'.format(speler['username'], str(speler['kaarten']), berekenWaarde(speler)))

# Controleert of dealer een zet moet doen of niet.
# Kijkt of de waarde van de kaarten van een dealer groter zijn dan de waarde van de andere spelers.
def checkDealerZet(dealer, spelers):
    max = 0
    for speler in spelers:
        if berekenWaarde(speler) >= max:
            max = berekenWaarde(speler)
    if max > berekenWaarde(dealer):
        return True
    return False

# Controleert welke speler er heeft gewonnen.
def checkGewonnen(dealer, spelers):
    gewonnen = {}
    max = 0
    for speler in spelers:
        if berekenWaarde(speler) >= max:
            max = berekenWaarde(speler)
            gewonnen = speler

    if max < berekenWaarde(dealer):
        gewonnen = dealer
    return gewonnen

# Toont het score bord.
def toonScoreBord(dealer, spelers):
    print('SCORE BORD:')
    print(dealer['username'] + ':',str(dealer['score']))
    for speler in spelers:
        print(speler['username'] + ':', str(speler['score']))

# Controleert of de username al bestaat.
def checkOfUsernameBestaat(username, spelers):
    for speler in spelers:
        if speler['username'] == username:
            return True
    return False

# print met een aantal laad puntjes.
def printOpDezelfdeLijn(zin, t):
    for i in range(0,4):
        print(zin + (i * '.'), end = "\r")
        time.sleep(t)

nummers = [2,3,4,5,6,7,8,9,10,'boer', 'koningin', 'koning', 'aas']
symbolen = ['kl', 'rt', 'ht', 'sc']
kaarten = []

spelers = []
dealer = {'username': 'dealer', 'kaarten': [], 'score': 0}

# variabelen voor het spel
spelIsBezig = True
status = 'begin'
beurt = 'dealer'
verloren = {'verloren': False, 'speler': {}}

# zet deze lager voor snellere load times.
laadTijd = 0.3

os.system("cls")
print('WELKOM BIJ BLACKJACK!')

aantalSpelers = 0
while aantalSpelers == 0:
    try: 
        aantalSpelers = int(input('\nHoeveel spelers doen er mee (dealer niet meegerekend)? '))
    except: 
        print('Foute input, geef een getal in!')
        aantalSpelers = 0  

for i in range (0, aantalSpelers):
    username = ''
    while username == '':
        username = input('Wat is de username van speler(' + str(i+1) + ') [uniek]: ')
        if checkOfUsernameBestaat(username, spelers):
            print('Username bestaat al, gebruik een andere!\n')
            username = ''
    
    spelers.append({'username': username, 'kaarten': [], 'score': 0})

while spelIsBezig:
    # deze wordt uitgevoerd vanaf ronde 2
    if status == 'opniuew':
        toonScoreBord(dealer, spelers)
        input("\nDruk op Enter om verder te gaan")
        status == 'begin'
    
    if status == 'begin':
        os.system("cls")

        # kaarten samen stellen
        printOpDezelfdeLijn('De kaarten worden samengesteld', laadTijd)
        os.system("cls")
        kaartenSamenstellen(kaarten, nummers, symbolen)
        # kaarten schudden
        printOpDezelfdeLijn('De kaarten worden geschud', laadTijd)
        os.system("cls")
        schudKaarten(kaarten)
        # kaarten verdelen
        printOpDezelfdeLijn('De kaarten worden verdeeld onder de spelers', laadTijd)
        os.system("cls")
        verdeelKaarten(kaarten, spelers, dealer)

        # status van de game op begonnen zetten => nodig voor overzicht game
        status = 'begonnen'
    
    if status == 'begonnen':
        os.system("cls")
        print('OVERZICHT NA UITGEDEELDE KAARTEN ',  end = "")
        overzichtGame(dealer, spelers, status)
        input("\nDruk op Enter om te beginnen")

        # beurt van de spelers
        for speler in spelers:
            os.system("cls")
            print(speler['username'], 'is aan de beurt!\n')
            overzichtGame(dealer, spelers, status)

            toonHand(speler)
            
            spelerKeuze = ''
            while spelerKeuze not in ['hit', 'h', 'stand', 's'] :
                spelerKeuze = input('Wat is je volgende stap ' + speler['username'] + '? (hit (h) / stand (s)) ')
            
            if spelerKeuze == 'hit' or spelerKeuze == 'h':
                printOpDezelfdeLijn(speler['username'] + ' neemt een kaart', laadTijd)
                print('\n')
                speler['kaarten'].append(kaarten.pop())

                overzichtGame(dealer, spelers, status)
                input("Druk op Enter om door te gaan")
                
                if berekenWaarde(speler) > 21:
                    # goed er uit gaan
                    verloren['verloren'] = True
                    verloren['speler'] = speler
                    beurt = ''
                    break
        
        # hier de status op bezig zetten zodat bij het overzicht alle kaarten van de dealer worden getoond.
        status = 'bezig'
        
        if beurt == 'dealer':
            # beurt van de dealer
            os.system("cls")
            print(dealer['username'], 'is aan de beurt!\n')
            
            overzichtGame(dealer, spelers, status)

            toonHand(dealer)
            
            if checkDealerZet(dealer, spelers):
                printOpDezelfdeLijn(dealer['username'] + ' neemt een kaart', laadTijd)
                print('\n')
                dealer['kaarten'].append(kaarten.pop())

                overzichtGame(dealer, spelers, status)
                input("Druk op Enter om door te gaan")

                if berekenWaarde(dealer) > 21:
                    # goed er uit gaan
                    verloren['verloren'] = True
                    verloren['speler'] = dealer
            else:
                print('Dealer neemt geen kaart!')
                input("Druk op Enter om door te gaan")

    if verloren['verloren'] == False:
        os.system("cls")
        printOpDezelfdeLijn('Resultaten berekenen', laadTijd)    
        gewonnen = checkGewonnen(dealer, spelers)
        
        os.system("cls")
        print(gewonnen['username'], 'heeft gewonnen met een waarde van ' + str(berekenWaarde(gewonnen)))

        if gewonnen['username'] == 'dealer':
            dealer['score'] += 1
        else:
            [speler for speler in spelers if speler['username'] == gewonnen['username']][0]['score'] += 1
    else:
        os.system("cls")
        print(verloren['speler']['username'], 'heeft verloren!')

        if verloren['speler']['username'] != 'dealer':
            dealer['score'] += 1

        for speler in spelers:
            if speler['username'] != verloren['speler']['username']:
                speler['score'] += 1

    verderDoen = ''
    while verderDoen not in ['ja', 'j', 'nee', 'n'] :
        verderDoen = input('Wil je verder spelen? (ja (j) / nee (n)) ')

    if verderDoen == 'ja' or verderDoen == 'j':
        # status op begon om een nieuwe game te starten
        status = 'opnieuw'
        # iedereen zijn kaarten legen
        dealer['kaarten'] = []
        for speler in spelers:
            speler['kaarten'] = []
        # kaarten boek legen
        kaarten = []
        # verloren resetten
        verloren = {'verloren': False, 'speler': {}}
        # beurt resetten
        beurt = 'dealer'

        continue
    else:
        spelIsBezig = False

os.system("cls")
toonScoreBord(dealer, spelers)