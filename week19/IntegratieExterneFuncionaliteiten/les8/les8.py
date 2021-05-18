import numpy as np
import matplotlib.pyplot as plt


x = np.array(['A', 'B', 'C', 'D'])
y = np.array([4, 6, 8, 9])

# plt.barh(x, y)
# plt.show()

taart = np.array([34, 45, 67, 83])
x = np.array(['A', 'B', 'C', 'D'])
plt.pie(taart, labels=x)
plt.legend(x)

plt.show()