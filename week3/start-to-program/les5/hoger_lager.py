import random, time, os

## Opdracht 2
os.system("cls")
print('\nOPDRACHT HOGER LAGER\n')

te_raden = random.randint(1,100)
gok = 0
i = 0

print('Het antwoord is ' + str(te_raden))

while not gok == te_raden:
    if (i == 10):
        print("\nJe 10 beurten zijn opgeraakt, probeer opnieuw te spelen\n")
        break

    i += 1
    try: 
        gok = int(input("\nGok " + str(i) + ": "))
    except: 
        print('\nFoute input, geef een getal in!')
        i -= 1
    

    if gok < 1 or gok > 100:
        print('getal moet tussen 1 en 100 zijn')
        i -= 1
    else:
        if gok > te_raden:
            print("Lager, nog", 10-i, "beurten!")
        elif gok < te_raden:
            print("Hoger, nog", 10-i, "beurten!")
        elif gok == te_raden:
            print("\nGoed gedaan, je hebt het in " + str(i) + (i == 1 and " beurt" or " beurten") + " geraden!\n")
