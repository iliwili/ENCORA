import numpy as np
import matplotlib.pyplot as plt

x = [1, 2, 3, 4]
y = [1, 2, 3, 4]

# plt.plot(x, y ,color='green', linestyle='dashed', marker='o', markerfacecolor='blue', markersize='10')
# plt.xlabel('test')
# plt.ylabel('tester')
# plt.title('title',  {'family':'serif','color':'blue','size':20})
# plt.grid(True)
# plt.show()

x1 = np.array([1,2,4,7])
y1 = np.array([3,8,1,10])

plt.plot(x1, y1, color="#D3691F", linestyle="-.", linewidth="3", marker="<", markerfacecolor="#BEBE00", markeredgecolor="#FD4962", markersize="10")
plt.grid(True, color="lightblue", linestyle="dashed", linewidth="2")

plt.xlabel('X-as', fontdict= {'family':'serif','color':'red'}, loc="left")
plt.ylabel('Y-as', fontdict= {'family':'serif','color':'red'}, loc="bottom")
plt.title('Titel van de grafiek', fontdict= {'family':'serif','color':'blue','size':16}, loc="right")

plt.show()