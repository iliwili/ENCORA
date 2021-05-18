import numpy as np
import matplotlib.pyplot as plt

# plotten
x = [2, 4, 5, 7, 8]
y = [4, 5, 6, 7, 1]

# plt.plot(x, y)
# plt.show()

x = np.arange(0, 6)
y = np.arange(0, 6)

# plt.plot(x1, y1)
# plt.show()

x = np.arange(0, 6)
y = x[5::-1]

# plt.plot(x, y)
# plt.show()

# 3

# plt.plot(y)
# plt.show()

# 4
weekdagen = ['MA', 'DI', 'WO', 'DO', 'VR', 'ZAT', 'ZON']
getallen = [1, 4, 3, 4, 5, 6, 7]

# plt.plot(getallen, weekdagen)
# plt.show()

# 5
str1 = ['test', 'ja', 'ok']
str2 = ['OK', 'YAS', 'SHEESH']

plt.plot(str1, str2)
plt.show()