import matplotlib.pyplot as plt
import numpy as np

#lijnen
# x1 = np.array([1,2,4,7])
# y1 = np.array([3,8,1,10])
#
# plt.plot(x1,y1, ls = ':', c = 'm', lw = '10')
# plt.show()

#markeringen
# x1 = np.array([1,2,4,7])
# y1 = np.array([3,8,1,10])
#
# plt.plot(x1,y1, marker = 'o', c = 'limegreen', mfc = '#f00', mec = '#00f', ms = '15', mew = '5')
# plt.show()

#shorthand
x1 = np.array([1,2,4,7])
y1 = np.array([3,8,1,10])

font1 = {'family':'fantasy','color':'blue','size':20}

plt.title('Grafiektitel', fontdict = font1)
plt.xlabel('x-as')
plt.ylabel('y-as')

plt.grid(axis = "x")

plt.plot(x1,y1, 'v--g')
plt.show()
