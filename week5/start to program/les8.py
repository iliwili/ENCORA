# OEFENINGEN
print('OEFENINGEN\n')
print('OEFENING 1\n')
alle_getallen = [i for i in range(50, 101)]
print(alle_getallen)

print('\nOEFENING 2\n')
alle_even_getallen = [i for i in range(50, 101) if i % 2 == 0]
print(alle_even_getallen)

print('\nOEFENING 3\n')
alle_deelbare_getallen = [i for i in range(1500, 2701) if i % 5 == 0 or i % 7 == 0]
print(alle_deelbare_getallen)

print('\nOEFENING 4\n')
lijst = ['abc', 'xyz', 'aba', '1221', '22', 'cedc', 'aa']
nieuwe_lijst = [element for element in lijst if len(element) > 2 and element[0] == element[len(element)-1]]
print(nieuwe_lijst)

print('\nOEFENING 5\n')
getallen = [0,1,2,3,4,5,6,7,9]
nieuw_getallen = [getal for getal in getallen if getallen.index(getal) % 3 == 0]
print(nieuw_getallen)