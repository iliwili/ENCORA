
getal = 2.0
print(getal)
if isinstance(getal, (int, float)):
    print('een getal')
else:
    print('is geen getal')


if type(getal) == int or type(getal) == float:
    print(str(getal) + ' is een getal')
else:
    print(str(getal) + ' is geen getal')

print(type(getal))

print('\nINPUT')

# naam = ''
# while naam == '':
#   naam = input('Wat is je naam? ')
#   print(isinstance(naam, str))

# print(naam)

# getal2_str = input('Geef een getal? ')

# try:
#     getal2 = int(getal2_str)
#     print(getal2)
# except ValueError:
#     print('Je gaf geen getal in. Probeer opnieuw')
#     getal2_str = input('Geef een getal? ')

# boolean_var = True
# getal3 = 1

# while boolean_var:
#     if getal3 < 10:
#         getal3 += 1
#         print(getal3)
#     else:
#         boolean_var = False
# print("uit de loop")


## Opdracht 1
print('\nOPDRACHT WACHTWOORD\n')
password = '1'
input_password = ''

while password != input_password:
    input_password = input('Geef het wachtwoord in? ')

    if password != input_password:
        print('Het ingegeven wachtwoord klopt niet. Probeer opnieuw.')

print('Het wachtwoord is correct')


