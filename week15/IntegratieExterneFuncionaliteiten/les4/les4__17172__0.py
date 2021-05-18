    import numpy as np


#zoeken
arr = np.array([1,2,4,2,6,7,2,8,2,110,2])
arrZoek = np.where(arr == 2)
print(arrZoek)


arr = np.arange(1,11)
print(arr)

evenInd = np.where(arr%2 == 0)
onevenInd = np.where(arr%2 == 1)
print(evenInd)
print(onevenInd)

even = [arr[i] for i in evenInd]
print(even)


#sorteren
getallen = np.array([3,2,0,1])
strings = np.array(['banaan', 'kers', 'appel'])
bools = np.array([True, False, True, False, False])

getallenSort = np.sort(getallen)
print(getallenSort)

stringsAlfabetisch = np.sort(strings)
print(stringsAlfabetisch)

boolsSort = np.sort(bools)
print(boolsSort)


#mulitdimensionale sort
getallen2D = np.array([[3,7,6],[5,0,1], [4,9,2]])
sort2D = np.sort(getallen2D)
print(sort2D)

sort2D = np.sort(getallen2D, axis = 0)
print(sort2D)

sort2D = np.sort(getallen2D, axis = 1)
print(sort2D)

sort2D = np.sort(getallen2D, axis = None)
print(sort2D)

#searchsorted
arr = np.array([0,1,2,5])
print(np.searchsorted(arr,3))

print(np.searchsorted(stringsAlfabetisch, 'citroen'))

arr = np.array([1,4,9,12])
print(np.searchsorted(arr,[2,3,5,10]))

#sorteren keyword
dtypes = [('id',int), ('naam','U50'), ('punten',float)]
studenten = [(1,'Jan', 94.2), (2,'Freya', 88.2), (3,'Filip',33.3)]
studentArr = np.array(studenten, dtype=dtypes)
sortStudentArr = np.sort(studentArr, order='punten')
print(sortStudentArr)


#argsort
arr = np.array([13,11,10,12])
argSortArr = np.argsort(arr)
print(argSortArr)
print([arr[i] for i in argSortArr])

#lexsort
voornaam = ['Jan', 'Lea', 'An', 'Jan']
achternaam = ['Peeters', 'Schoemaker', 'Ooms', 'Janssen']
lexSortArr = np.lexsort((achternaam, voornaam))
print(lexSortArr)
print([voornaam[i] + ' ' + achternaam[i] for i in lexSortArr])


a = [1,5,1,4,3,4,4] # First column
b = [9,4,0,4,0,2,1] # Second column
ind = np.lexsort((b,a))
print([(a[i],b[i]) for i in ind])

tupleList = list(zip(a,b))
print(tupleList)
ind = np.argsort(a)
print([(a[i],b[i]) for i in ind])

tupleArr = np.array(tupleList,dtype = np.dtype([('x',int),('y',int)]))
print(np.argsort(tupleArr))


#filteren
arr =  np.arange(0,5)
bools = [True, False, True, False, True]

print(arr)
print(bools)

arrFilter = arr[bools]
print(arrFilter)


arr = np.arange(20,41)
bools = []

for i in arr:
    if i%3 == 0:
        bools.append(True)
    else:
        bools.append(False)

arrFilter = arr[bools]

print(arrFilter)


arr = np.arange(20,41)

bools = arr%3 == 0

arrFilter = arr[bools]
print(arrFilter)


arr = np.arange(20,41)

bools = np.logical_and(np.logical_and(arr%3 == 0, arr < 30), arr%2 == 1)

arrFilter = arr[bools]
print(arrFilter)
