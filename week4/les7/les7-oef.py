print('OEFENINGEN\n')
print('OEFENING 1')
nummer = [10,20,30,20,10,50,60,40,80,50,40]
newlist = []

for i in nummer:
   if newlist.count(i) == 0:
       newlist.append(i)

print(newlist)

print('\nOEFENING 2')
empty_list = []
if (len(empty_list) == 0):
    print('Deze list is leeg')
else:
    print('Deze list is niet leeg')

print('\nOEFENING 3')
weekdagen = ['maandag', 'dinsdag', 'woensdag', 'donderdag', 'vrijdag', 'zaterdag', 'zondag']
copy_weekdagen = weekdagen.copy()

print('weekdagen: ', end='')
for w in weekdagen:
    print(w, end=', ')
print('\nweekdagen_copy: ', end='')
for cw in copy_weekdagen:
    print(cw, end=', ')

print('\nOEFENING 4')
zin = 'De kat krabt de krollen van de trap'
zin_splits = zin.split(' ')
list = []

for z in zin_splits:
    if len(z) > 3:
        list.append(z)

print(list)

print('\nOEFENING 5')
kleuren = [0,1,2,3,4,5,6,7,9]
new_list = []

for k in kleuren:
    if kleuren.index(k) % 3 == 0:
        new_list.append(k)

print(new_list)

print('\nOEFENING 6')
list = ['abc', 'xyz', 'aba', '1221', '22', 'cedc', 'aa']
new_list = []

for l in list:
    if len(l) > 2:
        new_list.append(l)

print(new_list)