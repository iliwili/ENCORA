import random, os

te_raden_lijst = ['SPELEN', 'TELLEN', 'TYPEN', 'TEST', 'KNALLEN']
reeds_geraden_woorden = []

os.system("cls")
print('WELKOM BIJ PYTHON GALGJE\n')

woord_aantal = 1

while len(te_raden_lijst) != 0:
    te_raden_woord = te_raden_lijst[random.randint(0, len(te_raden_lijst)-1)]
    
    te_checken_woord = te_raden_woord
    te_raden = '_'*len(te_raden_woord)
    kans = 0
    
    print('Woord ' + str(woord_aantal)+ ': ' + te_raden + ' (' + str(len(te_raden)) + ' letters)')

    while te_raden_woord != te_raden:
        if (kans == 5):
            print('\nJe 5 beurten zijn opgeraakt' + (len(te_raden_lijst) == 1 and '.' or ', probeer het volgende woord eens!'))
            break

        print(te_checken_woord)
        gok = input('Geef een letter in?' + ' [' + str(5-kans) + ' kansen] ' +  '(' + te_raden + ') ')

        kans += 1
        if len(gok) > 1:
            print('Geef maximum \'1\' letter in! ')
            kans -= 1
        else:
            if gok.isdigit() or gok == '':
                print('Letter mag niet leeg of een nummer zijn! ')
                kans -= 1
            else:
                try:
                    gok = gok.upper()
                    index = te_checken_woord.index(gok)
                    te_raden = "".join((te_raden[:index],gok,te_raden[index+1:]))
                    te_checken_woord = "".join((te_checken_woord[:index],'*',te_checken_woord[index+1:]))
                    kans -= 1
                except ValueError:
                    print(gok, 'komt niet voor in het woord')

    if kans < 5:
        reeds_geraden_woorden.append(te_raden_woord)
        print('\nJe hebt het woord geraden in ' + str(kans) + ' beurten! ')
        print('Overzicht geraden woorden: ', reeds_geraden_woorden, '\n')
    else:
        if len(te_raden_lijst) != 1:
            print('Het ziet er naar uit dat je het woord niet hebt kunnen raden, geen zorgen er zijn nog woorden!\n')

    woord_aantal += 1
    te_raden_lijst.remove(te_raden_woord)

print('\nHet spel is afgelopen, hier een klein overzicht: ')
if len(reeds_geraden_woorden) == 0:
    print('Je hebt niets geraden :(')
else:
    print('Aantal geraden woorden: ' + str(len(reeds_geraden_woorden)))
    print('Overzicht geraden woorden:', reeds_geraden_woorden)