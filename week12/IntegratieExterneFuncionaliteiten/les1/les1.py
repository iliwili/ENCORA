import numpy as np

# print(np.__version__)

# arr = np.array([1, 2, 3, 4, 5])

# print(arr)
# print(type(arr))

# # 0-D array
# arr0D = np.array(13)
# print(arr0D)

# # 1-D array
# arr1D = np.array([0,1,2,3,4])
# print(arr1D)

# 2-D array
arr2D = np.array([[0,1,2,3,4] , [5,6,7,8,9]])
print(arr2D)

# # 3-D array
# arr3D = np.array([[[1,2,3], [4,5,6]], [[1,2,3], [4,5,6]]])
# print(arr3D)

# print('dimensies:', arr0D.ndim)

# arrND = np.array([1,2,3,4], ndmin=5)
# print(arrND)
# print('number of dimensions :', arrND.ndim)

# arrange = np.arange(26, 46, 2)
# # print(arrange)

# linspace1 = np.linspace(10, 50, num=15)
# # print(linspace1)

# linspace2 = np.linspace(6, 25, 7, endpoint=True, retstep=True)
# print(linspace2)

# shape
print(arr2D.shape)