import numpy as np
import matplotlib.dates as mdates
import matplotlib.pyplot as plt
import matplotlib.ticker as mtick
import mysql.connector
from datetime import datetime, timedelta
import pandas as pd
import math

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

myCursor.execute("SELECT * FROM t_gezet_epistat")
admin_epistat = myCursor.fetchall()
admin_epistat_arr = np.array(admin_epistat)

ad_epi_types = [('date', 'M8[D]'), ('region', 'U50'), ('agegroup', 'U15'), ('sex', 'U2'), ('brand', 'U50'), ('dose', 'U5'), ('count', int)]
ad_epi_array = np.array(admin_epistat, dtype = ad_epi_types)

#region Geleverd_vs_Toegediend
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

#endregion

#region dagelijks_toegediend
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
#endregion

#region wekelijks_toegediend
## TODO: ADD LINE IN WORD DOC
# # Wekelijks toegediend:

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

#     total_first_dose.append(first_dose)
#     total_last_dose.append(last_dose)

# plt.bar(allweeks, total_first_dose, color='#FEB64D')
# plt.bar(allweeks, total_last_dose, bottom=total_first_dose, color='#81C685')

# plt.title('Wekelijks toegediend', fontdict={'family':'serif','color':'white','size':18}, loc="right")
# plt.xlabel('Week', fontdict={'family':'serif','color':'white','size':12})
# plt.ylabel('Aantal', fontdict={'family':'serif','color':'white','size':12})

# plt.show()
#endregion

#region leveringen producenten
## TODO: ADD LINE IN WORD DOC
# # Leveringen producenten
# # Lijngrafiek
# sdate = del_array[0]['date']
# edate = (del_array[-1]['date'] + 1)

# alldates = np.arange(sdate, edate, timedelta(days=1)).astype('M8[D]')

# manufacturer = {
#     "Pfizer/BioNTech": [],
#     "Moderna": [],
#     "AstraZeneca/Oxford": [],
#     "Johnson&Johnson": []
# }

# total_cul_pfizer = 0
# total_cul_moderna = 0
# total_cul_astrazeneca = 0
# total_cul_johnson = 0

# for date in alldates:
#     pfizer_amount = 0
#     moderna_amount = 0
#     astraZemeca_amount = 0
#     johnsen_amount = 0

#     for deliv in del_array:
#         if (deliv['date'] == date):
#             if deliv['manufacturer'] == 'Pfizer/BioNTech':
#                 pfizer_amount += deliv['amount']
#             elif deliv['manufacturer'] == 'Moderna':
#                 moderna_amount += deliv['amount']
#             elif deliv['manufacturer'] == 'AstraZeneca/Oxford':
#                 astraZemeca_amount += deliv['amount']
#             elif deliv['manufacturer'] == 'Johnson&Johnson':
#                 johnsen_amount += deliv['amount']

#     total_cul_pfizer += pfizer_amount;
#     total_cul_moderna += moderna_amount;
#     total_cul_astrazeneca += astraZemeca_amount;
#     total_cul_johnson += johnsen_amount;

#     manufacturer['Pfizer/BioNTech'].append(total_cul_pfizer)
#     manufacturer['Moderna'].append(total_cul_moderna)
#     manufacturer['AstraZeneca/Oxford'].append(total_cul_astrazeneca)
#     manufacturer['Johnson&Johnson'].append(total_cul_johnson)

# plt.plot(alldates, manufacturer['Pfizer/BioNTech'])
# plt.plot(alldates, manufacturer['Moderna'])
# plt.plot(alldates, manufacturer['AstraZeneca/Oxford'])
# plt.plot(alldates, manufacturer['Johnson&Johnson'])

# plt.title('Leveringen producenten', fontdict={'family':'serif','color':'white','size':18}, loc="right")
# plt.xlabel('Datum', fontdict={'family':'serif','color':'white','size':12})
# plt.ylabel('Aantal (miljoen)', fontdict={'family':'serif','color':'white','size':12})

# plt.show()

## TODO: ADD LINE IN WORD DOC
## Taartdiagram

# labels = ['Pfizer/BioNTech', 'Moderna', 'AstraZeneca/Oxford', 'Johnson&Johnson']
# sizes = []
# explode = (0, 0.1, 0, 0)

# manufacturer = {
#     "Pfizer/BioNTech": 0,
#     "Moderna": 0,
#     "AstraZeneca/Oxford": 0,
#     "Johnson&Johnson": 0
# }

# for deliv in del_array:
#     manufacturer[deliv['manufacturer']] += deliv['amount']

# for key in manufacturer:
#     sizes.append(manufacturer[key])

# plt.pie(sizes, explode=explode, labels=labels, autopct='%1.1f%%',
#         shadow=True, textprops={'color':"w"})

# plt.show()
#endregion

#region wekelijks_geleverd_dosissen
## TODO: ADD LINE IN WORD DOC
## wekelijks geleverde dosissen

# # date to week
# def to_week(date):
#     return "w" + str(pd.to_datetime(str(date)).week)

# sdate = del_array[0]['date']
# edate = (del_array[-1]['date'] + 1)

# alldates = np.arange(sdate, edate, timedelta(days=1)).astype('M8[D]')

# allweeks = []
# for x in [to_week(x) for x in alldates]:
#     if x not in allweeks:
#         allweeks.append(x)

# total_pfizer = []
# total_moderna = []
# total_astrazeneca = []
# total_johnson = []

# for week in allweeks:
#     pfizer_amount = 0
#     moderna_amount = 0
#     astrazeneca_amount = 0
#     johnson_amount = 0

#     for deliv in del_array:
#         if week == to_week(deliv['date']):
#             if deliv['manufacturer'] == 'Pfizer/BioNTech':
#                 pfizer_amount += deliv['amount']
#             elif deliv['manufacturer'] == 'Moderna':
#                 moderna_amount += deliv['amount']
#             elif deliv['manufacturer'] == 'AstraZeneca/Oxford':
#                 astrazeneca_amount += deliv['amount']
#             elif deliv['manufacturer'] == 'Johnson&Johnson':
#                 johnson_amount += deliv['amount']

#     total_pfizer.append(pfizer_amount)
#     total_moderna.append(moderna_amount)
#     total_astrazeneca.append(astrazeneca_amount)
#     total_johnson.append(johnson_amount)

# tot_pf_mod = np.add(total_pfizer, total_moderna).tolist()
# tot_pf_mod_ast = np.array([total_pfizer, total_moderna, total_astrazeneca]).sum(axis=0)

# plt.bar(allweeks, total_pfizer,color='#BBDEFB')
# plt.bar(allweeks, total_moderna, bottom=total_pfizer, color='#E47273')
# plt.bar(allweeks, total_astrazeneca, bottom=tot_pf_mod, color='#FEB74C')
# plt.bar(allweeks, total_johnson, bottom=tot_pf_mod_ast, color='#80C785')

# plt.title('Wekelijks toegediend', fontdict={'family':'serif','color':'white','size':18}, loc="right")
# plt.xlabel('Week', fontdict={'family':'serif','color':'white','size':12})
# plt.ylabel('Aantal', fontdict={'family':'serif','color':'white','size':12})

# plt.show()
#endregion

#region vacconaties per leeftijdscategorie
#leeftijd
# ad_epi_split = np.array_split(admin_epistat_arr, 7, axis = 1)

# ages = np.unique(ad_epi_split[2].flatten())
# vaccinaties = []

# for indx in range(len(ages)):
#     count = 0
#     for epi in ad_epi_array:
#         if ages[indx] == epi['agegroup']:
#             count += 1
    
#     vaccinaties.append(count)

# tot_vacc = np.sum(vaccinaties)

# data = []

# for vac in vaccinaties:
#     percent = (vac / tot_vacc) * 100

#     data.append(percent)

# plt.barh(ages, data, color='#FEB64D')
# ax.xaxis.set_major_formatter(mtick.PercentFormatter())


# plt.title('Vaccinaties per leeftijdscategorie', fontdict={'family':'serif','color':'white','size':18}, loc="right")
# plt.xlabel('Aantal (%)', fontdict={'family':'serif','color':'white','size':12})
# plt.ylabel('Leeftijden', fontdict={'family':'serif','color':'white','size':12})

# plt.show()

# # geslacht
# sex = np.unique(ad_epi_split[3].flatten())
# vaccinaties = []

# for indx in range(len(sex)):
#     count = 0
#     for epi in ad_epi_array:
#         if sex[indx] == epi['sex']:
#             count += 1
    
#     vaccinaties.append(count)

# tot_vacc = np.sum(vaccinaties)

# data = []

# for vac in vaccinaties:
#     percent = (vac / tot_vacc) * 100

#     data.append(percent)

# plt.barh(sex, data, color='#FEB64D')
# ax.xaxis.set_major_formatter(mtick.PercentFormatter())


# plt.title('Vaccinaties per geslacht', fontdict={'family':'serif','color':'white','size':18}, loc="right")
# plt.xlabel('Aantal (%)', fontdict={'family':'serif','color':'white','size':12})
# plt.ylabel('Geslacht', fontdict={'family':'serif','color':'white','size':12})

# plt.show()
#endregion

#region producenten
#taartdiagram
total_order = [12500000, 5800000, 7740000, 5160000, 2900000]

manufacturer = {
    "Pfizer/BioNTech": 0,
    "Moderna": 0,
    "AstraZeneca/Oxford": 0,
    "Johnson&Johnson": 0,
    "Curevac": 0
}

for deliv in del_array:
    manufacturer[deliv['manufacturer']] += deliv['amount']

# data_first_layer = []

# for indx, key in enumerate(manufacturer):
#     data_first_layer.append([manufacturer[key], total_order[indx] - manufacturer[key]])

# cmap = plt.get_cmap("tab20c")
# outer_colors = cmap(np.arange(5)*4)
# inner_colors = cmap([1, 2, 5, 6, 9, 10, 13, 14, 17, 18])

# inner_labels = ['Del' , 'Tot', 'Del' , 'Tot', 'Del' , 'Tot', 'Del' , 'Tot', 'Del' , 'Tot']

# plt.pie(np.array(data_first_layer).sum(axis=1), labels=[key for key in manufacturer], radius=1, colors=outer_colors,
#        wedgeprops=dict(width=0.3, edgecolor='w'), textprops={'color':"w"})
# plt.pie(np.array(data_first_layer).flatten(), labels=inner_labels, radius=0.7, colors=inner_colors,
#        wedgeprops=dict(width=0.3, edgecolor='w'), textprops={'color':"w"})
# plt.margins(0, 0)

# subgroup_names_legs=['Pfizer/BioNTech', 'Moderna', 'AstraZeneca/Oxford', 
# 'Johnson&Johnson', 'Curevac']

# plt.legend(loc=(0.9, 0.1))
# handles, labels = ax.get_legend_handles_labels()

# ax.legend(handles[3:], subgroup_names_legs, loc=(0.9, 0.7))

# plt.title('Producenten taartdiagram', fontdict={'family':'serif','color':'white','size':18}, loc="center")

# plt.show()
#staaf
ordered = []
to_order = []

for indx, key in enumerate(manufacturer):
    ordered.append(manufacturer[key])
    to_order.append(total_order[indx] - manufacturer[key])

plt.bar([key for key in manufacturer], ordered)
plt.bar([key for key in manufacturer], to_order, bottom=ordered)

plt.title('Producenten staafdiagram', fontdict={'family':'serif','color':'white','size':18}, loc="right")
plt.xlabel('Producenten', fontdict={'family':'serif','color':'white','size':12})
plt.ylabel('Aantal (miljoen)', fontdict={'family':'serif','color':'white','size':12})

plt.legend(['Deliverd', 'To deliver'])

plt.show()
#endregion