import numpy as np

arr1 = np.array([1, 2, 3, 500], dtype='i1')
arr2 = np.array(['roos', 'tulp', 'lelie'], dtype='U2')

# print(arr1.dtype)
# print(arr2.dtype)

getallenAlsString = np.array([1, 2, 3, 4], dtype='U')
# print(getallenAlsString.dtype)

# print(arr2)
# print(arr1)

#datatypes omvormen
floats = np.array([1.1, 2.1, 3.1])
ints = floats.astype('i')
# print(ints)
# print(ints.dtype)

getallen2 = np.array([1, 0, 10, 4])
bools = getallen2.astype('b')
# print(bools)
# print(bools.dtype)

#iteratie
array1d = np.arange(0, 16)
# for a in array1d:
#     print(a)

array2d = array1d.reshape(2, 8)
# for a in array2d:
#     for b in a:
#         print(b)

array3d = array1d.reshape(2, 4, 2)
# for a in array3d:
#     for b in a:
#         for c in b:
#             print(c)

# nditer
# for i in np.nditer(array2d):
#     print(i)

# het datatype van alle elementen aanpassen
# for i in np.nditer(loops3D, flags=['buffered'], op_dtypes=['S']):
#     print(i)

# iteratie met steps
# je moet wel het aantal lagen kennen
# for i in np.nditer(array2d[:,::2]):
#     print(i)

# ndenumerate voor de index van het element te kennen
# for indx, i in np.ndenumerate(array3d):
#     print(indx, i)


# JOIN EN SPLIT
# concatenate
array1dJ1 = np.arange(0, 3)
array1dJ2 = np.arange(0, 3)

# print(np.concatenate((array1dJ1, array1dJ2)))

arr2dJ1 = np.array([[0, 1, 3], [3, 4, 5]])
arr2dJ2 = np.array([[0, 1, 3], [3, 4, 6]])

# print(np.concatenate((arr2dJ1, arr2dJ2), axis=1))

# stacking
# print(np.stack((array1dJ1, arsray1dJ2), axis=1))

#split
sarray = np.arange(0, 9)
print(np.array_split(sarray, 2))