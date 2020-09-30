# naar absolute waarde
a = 5
b = 15
mijn_getal = a - b
print(abs(mijn_getal))

#resultaat van de deling en de restwaarde
getal1 = 25
getal2 = 4

div,mod = divmod(getal1, getal2)
print(div, mod)

# OPDRACHT
print("\nOPDRACHT")
# print("1.")
afgelegd_km = 5
nog_afteleggen_km = 15
# print(abs(afgelegd_km - nog_afteleggen_km))


# print("2.")
boek = 800
formaat_a = 300
formaat_b = 250

# print("formaat A:", divmod(boek, formaat_a))
# print("formaat B:", divmod(boek, formaat_b))

# print("3.")
tot_rek = 82.65
tot_pers = 4
# print(round(tot_rek / tot_pers, 2))

uitslag = 88

if uitslag < 50:
    print("Niet geslaagd")
else:
    if uitslag > 90:
        print("Geslaagd met grootste onderscheiding en de gelukwensen van de examencommissie")
    elif uitslag > 85:
        print("Geslaagd met grootste onderscheiding")
    elif uitslag > 77:
        print("Geslaagd met grote onderscheiding")
    elif uitslag > 68:
        print("Geslaagd met onderscheiding") 
    else:
     print("Geslaagd op voldoende wijze") 


# OPDRACHT EVEN OF ONEVEN
print("\nEVEN OF ONEVEN")
getal = 143
if getal % 2 == 0:
    print("even")
else:
    print("oneven")