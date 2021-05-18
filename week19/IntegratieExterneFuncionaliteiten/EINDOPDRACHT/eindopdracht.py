import numpy as np
import matplotlib.dates as mdates
import matplotlib.pyplot as plt
import mysql.connector
from datetime import datetime, timedelta


# DATABASE CONNECTIE
myDB = mysql.connector.connect(
    host="localhost",
    user="root",
    password="",
    database = "eindopdracht"
)

myCursor = myDB.cursor()

myCursor.execute("SELECT * FROM t_geleverd")
geleverd_arr = myCursor.fetchall()
geleverd_np_arr = np.array(geleverd_arr);

dtypes = [('date', 'M8[D]'), ('amount', int), ('manufacturer', 'U50')]
ndarray = np.array(geleverd_arr, dtype=dtypes)

geleverd_unique_dates = np.unique(np.array_split(geleverd_np_arr, 3, axis = 1)[0]).astype('M')

myCursor.execute("SELECT * FROM t_gezet")
gezet_arr = myCursor.fetchall()
gezet_np_arr = np.array(gezet_arr)

ztypes = [('date', 'M8[D]'), ('first_dose', int), ('second_dose', int), ('region', 'U30')]
zdarray = np.array(gezet_arr, dtype=ztypes)


sdate = geleverd_unique_dates[0]
edate = (geleverd_unique_dates[-1] + 1)

# print([sdate+timedelta(days=x) for x in range((edate-sdate).days)])
alldates = np.arange(sdate, edate, timedelta(days=1)).astype('M')

total_cul_geleverd = 0;
total_cul_gezet = 0;
total_cul_voorraad = 0;

total_geleverd = []
total_gezet = []
total_voorraad = []

## loop through all the dates, then de geleverd en gezet to get all the valuess!!
for date in alldates:
    cul_geleverd = 0
    cul_gezet = 0
    for deliv in ndarray:
        if (deliv['date'] == date):
            cul_geleverd += deliv['amount']
            # print('YESS', deliv)
    for gezet in zdarray:
        if (gezet['date'] == date):
            cul_gezet += (gezet['first_dose'] + gezet['second_dose'])
    
    total_cul_geleverd += cul_geleverd
    total_cul_gezet += cul_gezet
    total_cul_voorraad += cul_geleverd - cul_gezet
    
    total_geleverd.append(total_cul_geleverd)
    total_gezet.append(total_cul_gezet)
    total_voorraad.append(total_cul_voorraad)

fig = plt.figure(figsize=(15, 5))
ax = fig.add_subplot(111)
fig.autofmt_xdate()
ax.xaxis.set_major_formatter(mdates.DateFormatter('%m-%d'))

plt.plot(alldates, total_geleverd)
plt.plot(alldates, total_gezet)
plt.plot(alldates, total_voorraad)

plt.show()