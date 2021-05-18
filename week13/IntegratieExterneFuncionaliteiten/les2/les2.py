import numpy as np

arr1D = np.arange(0, 12)
print(arr1D)
# print('eerste:', arr1D[0])
# print('derde:', arr1D[2])

# print(arr1D[2:8])
# print(arr1D[:5])
# print(arr1D[10:])

# multidimensionale array
# indexering
arr2D = arr1D.reshape(2, 6)
print('arr2D')
print(arr2D)
print(arr2D[1][2])

arr3D = arr1D.reshape(2,2,3)
print('arr 3D')
print(arr3D)
# print(arr3D[1][0][1])

# slicing
# print(arr2D[1, 1:])
# print(arr3D[1, 0, :-1])

# slicing meer
# print(arr2D[0:, -1:])
# print(arr2D[0:, 1:5])

# print(arr3D[0:, 0:, 0])
# print(arr3D[0:, 0, 1])

# slicing met stappen
print(arr1D[0:-1:2])