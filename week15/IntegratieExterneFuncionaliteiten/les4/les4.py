import numpy as np
from numpy.core.records import array

arr1 = np.array([4, 5, 6, 2, 4, 6, 7, 9, 4])
index = np.where(arr1 == 4)


# sorteren
arr3 = np.arange(0, 12)
arr4 = ['test', 'ikiwi', 'bloem', 'safemoon']
arr5 = [True, False, True, True, False]

# print(np.sort(arr3))
# print(np.sort(arr4))
# print(np.sort(arr5))

arr6 = np.array([[3, 4, 5], [2, 1, 0]])
# print(np.sort(arr6, axis=None))

arr7 = [7, 9, 3, 6, 0]
# print(np.searchsorted(arr7, 0))

# sorteren op keywoord
dtypes = [('id',int), ('naam', 'S'),('punten',float)]
studenten = [(1,'Jan', 94.2),(2,'Freya',88.2),(3,'Filip',33.3)]
studentArr = np.array(studenten, dtype = dtypes)
sortStudentArr = np.sort(studentArr, order = 'punten')
# print(sortStudentArr)

#argsort & lexsoort
arr = np.array([13,11,10,12])
argSortArr = np.argsort(arr)
# print(argSortArr)
# print([arr[i] for i in argSortArr])

voornaam = ['Jan', 'Lea', 'An', 'Jan']
achternaam = ['Peeters', 'Schoemaker', 'Ooms', 'Janssen']
lexSortArr = np.lexsort((achternaam, voornaam))
# print(lexSortArr)
# print([voornaam[i] + ' ' +  achternaam[i] for i in lexSortArr])

arr8 = np.arange(0, 5)
arr9 = [True, False, True, False, True]


arrFilter = arr8[arr9]
# print(arrFilter)

getallen = np.arange(20, 40)
bools = []

for a in getallen:
    if a % 3 == 0:
        bools.append(True)
    else:   
        bools.append(False)

arrFilter = getallen[bools]
print(arrFilter)