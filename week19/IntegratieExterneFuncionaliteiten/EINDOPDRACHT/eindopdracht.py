import numpy as np
import matplotlib.dates as mdates
import matplotlib.pyplot as plt
import mysql.connector
from datetime import datetime, timedelta
import pandas as pd 

# STYLE FOR GRAPH
fig = plt.figure(figsize=(10, 8))
ax = fig.add_subplot(111)

fig.patch.set_facecolor('#202021')

ax.tick_params(axis='x', colors='white')
ax.tick_params(axis='y', colors='white')

ax.spines['bottom'].set_color('#fff')
ax.spines['top'].set_color('#fff') 
ax.spines['right'].set_color('#fff')
ax.spines['left'].set_color('#fff')

ax.set_facecolor('#202021')

# DATABASE CONNECTIE
myDB = mysql.connector.connect(
    host="localhost",
    user="root",
    password="",
    database = "int_eindopdracht"
)

myCursor = myDB.cursor()

myCursor.execute("SELECT * FROM t_geleverd")
delivered = myCursor.fetchall()
delivered_arr = np.array(delivered);

del_types = [('date', 'M8[D]'), ('amount', int), ('manufacturer', 'U50')]
del_array = np.array(delivered, dtype = del_types)

myCursor.execute("SELECT * FROM t_gezet")
administrated = myCursor.fetchall()
administrated_arr = np.array(administrated)

ad_types = [('date', 'M8[D]'), ('first_dose', int), ('second_dose', int), ('region', 'U30')]
ad_array = np.array(administrated, dtype = ad_types)

## TODO: ADD LINE IN WORD DOC
# Geleverd vs toegediend

# sdate = del_array[0]['date']
# edate = (del_array[-1]['date'])

# alldates = np.arange(sdate, edate, timedelta(days=1)).astype('M8[D]')

# total_cul_geleverd = 0;
# total_cul_gezet = 0;
# total_cul_voorraad = 0;

# total_geleverd = []
# total_gezet = []
# total_voorraad = []

# for date in alldates:
#     cul_geleverd = 0
#     cul_gezet = 0
#     for deliv in del_array:
#         if (deliv['date'] == date):
#             cul_geleverd += deliv['amount']
#     for gezet in ad_array:
#         if (gezet['date'] == date):
#             cul_gezet += (gezet['first_dose'] + gezet['second_dose'])
    
#     total_cul_geleverd += cul_geleverd
#     total_cul_gezet += cul_gezet
#     total_cul_voorraad += cul_geleverd - cul_gezet
    
#     total_geleverd.append(total_cul_geleverd)
#     total_gezet.append(total_cul_gezet)
#     total_voorraad.append(total_cul_voorraad)

# plt.plot(alldates, total_geleverd, color="#B39DDB")
# plt.plot(alldates, total_gezet, color="#BADFFB")
# plt.plot(alldates, total_voorraad, color="#D06B6A")

# plt.grid(color="white")

# plt.title('Geleverd vs toegediend', fontdict={'family':'serif','color':'white','size':18}, loc="right")
# plt.xlabel('Datum', fontdict={'family':'serif','color':'white','size':12})
# plt.ylabel('Aantal (miljoen)', fontdict={'family':'serif','color':'white','size':12})

# # x label format
# fig.autofmt_xdate()
# ax.xaxis.set_major_formatter(mdates.DateFormatter('%m-%d'))

# plt.show()

## TODO: ADD LINE IN WORD DOC
# Dagelijks toegediend:

# sdate = del_array[0]['date']
# edate = (del_array[-1]['date'] + 1)

# alldates = np.arange(sdate, edate, timedelta(days=1)).astype('M8[D]')

# total_first_dose = []
# total_last_dose = []

# for (indx, date) in np.ndenumerate(alldates):
#     first_dose = 0
#     last_dose = 0
#     for admin in ad_array:
#         if admin['date'] == date:
#             first_dose += admin['first_dose']
#             last_dose += admin['second_dose']
#     total_first_dose.append(first_dose)
#     total_last_dose.append(last_dose)
            

# plt.bar(alldates, total_first_dose, color="#FEB64D")
# plt.bar(alldates, total_last_dose, color="#81C685")

# plt.title('Dagelijks toegediend', fontdict={'family':'serif','color':'white','size':18}, loc="right")
# plt.xlabel('Datum', fontdict={'family':'serif','color':'white','size':12})
# plt.ylabel('Aantal', fontdict={'family':'serif','color':'white','size':12})

# plt.show()

## TODO: ADD LINE IN WORD DOC
# Wekelijks toegediend:

# date to week
# def to_week(date):
#     return "w" + str(pd.to_datetime(str(date)).week)

# sdate = del_array[0]['date']
# edate = (del_array[-1]['date'] + 1)

# alldates = np.arange(sdate, edate, timedelta(days=1)).astype('M8[D]')

# allweeks = []
# for x in [to_week(x) for x in alldates]:
#     if x not in allweeks:
#         allweeks.append(x)

# total_first_dose = []
# total_last_dose = []

# for week in allweeks:
#     first_dose = 0
#     last_dose = 0
#     for ad in ad_array:
#         if week == to_week(ad['date']):
#             first_dose += ad['first_dose']
#             last_dose += ad['second_dose']

#     print(week, first_dose, last_dose)
#     total_first_dose.append(first_dose)
#     total_last_dose.append(last_dose)

# plt.bar(allweeks, total_first_dose, color='#FEB64D')
# plt.bar(allweeks, total_last_dose, color='#81C685')

# plt.title('Wekelijks toegediend', fontdict={'family':'serif','color':'white','size':18}, loc="right")
# plt.xlabel('Week', fontdict={'family':'serif','color':'white','size':12})
# plt.ylabel('Aantal', fontdict={'family':'serif','color':'white','size':12})

# plt.show()