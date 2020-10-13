print('\nOEFENINGEN')
print('\nOEFENING 1')
for i in range(1500, 2701):
    if i % 5 == 0 and i % 7 == 0:
        print(i)

print('\nOEFENING 2')
inp_gebruiker  = str(input('Geef een woord? '))

char_counter = 0
digit_counter = 0

# FOR LUS

for i in inp_gebruiker:
    if i.isdigit():
        digit_counter += 1
    elif i.isalpha():
        char_counter += 1

# TRY

for i in inp_gebruiker:
    try:
        i = int(i)
        digit_counter += 1
    except:
        char_counter += 1
    
print('letters: ' + str(char_counter))
print('getallen: ' + str(digit_counter))

print('\nOEFENING 3')
temp = ''

temp_c = float(input('Geef de temperatuur? (C) '))
temp_f = temp_c * 1.8000 + 32.00
print('C = ' + str(temp_c))
print('F = ' + str(temp_f))

print('\nOEFENING 4')
for i in range(0, 5):
    for j in range(0, i + 1):
        print('*', end=' ')
    print("\r")

for i in range(5, 0, -1):
    for j in range(0, i - 1):
        print('*', end=' ')
    print("\r")

print('\nOEFENING 5')
reeks = str(15489723455614)

even_counter = 0
oneven_counter = 0

for i in reeks:
    i = int(i)

    if i % 2 == 0:
        even_counter += 1
    else:
        oneven_counter += 1

print('De reeks: ' + reeks)
print('bevat ' + str(even_counter) + ' even getallen en ' + str(oneven_counter) + ' oneven getallen. ')

print('\nOEFENING 6')

x,y=0,1

while y<50:
    print(y)
    x,y = y,x+y

print('\nOEFENING 7')
binair = '01011011'
i = 1
total = 0

for b in binair [::-1]:
    total += int(b) * i
    i *= 2 

print('total of ' + (binair [::-1]) + ' is ' + str(total))