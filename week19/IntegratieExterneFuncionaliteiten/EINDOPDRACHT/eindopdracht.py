import numpy as np
import matplotlib.dates as mdates
import matplotlib.pyplot as plt
import matplotlib.ticker as mtick
import mysql.connector
from datetime import timedelta
import pandas as pd

#region style for all graphs
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

plt.grid(color="white", alpha=0.3 ,zorder=0)
#endregion

#region database connectie
myDB = mysql.connector.connect(
    host="localhost",
    user="root",
    password="",
    database = "int_eindopdracht"
)

myCursor = myDB.cursor()
#endregion

#region data setup
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
#endregion

#region shared code
sdate = del_array[0]['date']
edate = (del_array[-1]['date'])

alldates = np.arange(sdate, edate, timedelta(days=1)).astype('M8[D]')

def plot_labels(title, xas, yas):
    plt.title(title, fontdict={'family':'serif','color':'white','size':18}, loc="right")
    plt.xlabel(xas, fontdict={'family':'serif','color':'white','size':12})
    plt.ylabel(yas, fontdict={'family':'serif','color':'white','size':12})

def to_week(date):
    return "w" + str(pd.to_datetime(str(date)).week)

allweeks = []
for x in [to_week(x) for x in alldates]:
    if x not in allweeks:
        allweeks.append(x)

ad_epi_split = np.array_split(admin_epistat_arr, 7, axis = 1)

total_order = [12500000, 5800000, 7740000, 5160000, 2900000]
#endregion

#region Geleverd_vs_Toegediend
total_cul_geleverd = 0;
total_cul_gezet = 0;
total_cul_voorraad = 0;

total_geleverd = []
total_gezet = []
total_voorraad = []

for date in alldates:
    cul_geleverd = 0
    cul_gezet = 0

    for deliv in del_array:
        if (deliv['date'] == date):
            cul_geleverd += deliv['amount']
    for gezet in ad_array:
        if (gezet['date'] == date):
            cul_gezet += (gezet['first_dose'] + gezet['second_dose'])

    total_cul_geleverd += cul_geleverd
    total_cul_gezet += cul_gezet
    total_cul_voorraad += cul_geleverd - cul_gezet

    total_geleverd.append(total_cul_geleverd)
    total_gezet.append(total_cul_gezet)
    total_voorraad.append(total_cul_voorraad)

plt.plot(alldates, total_geleverd, color="#B39DDB", zorder=3)
plt.plot(alldates, total_gezet, color="#BADFFB", zorder=3)
plt.plot(alldates, total_voorraad, color="#D06B6A", zorder=3)

plot_labels('Geleverd vs toegediend', 'Datum', 'Aantal (miljoen)')

# x label format
fig.autofmt_xdate()
ax.xaxis.set_major_formatter(mdates.DateFormatter('%m-%d'))

plt.legend(['Doses deliverd', 'Doses administered', 'Doses in stock'])

plt.show()
#endregion

#region Dagelijks_toegediend
total_first_dose = []
total_last_dose = []

for (indx, date) in np.ndenumerate(alldates):
    first_dose = 0
    last_dose = 0
    for admin in ad_array:
        if admin['date'] == date:
            first_dose += admin['first_dose']
            last_dose += admin['second_dose']

    total_first_dose.append(first_dose)
    total_last_dose.append(last_dose)

plt.bar(alldates, total_first_dose, color="#FEB64D", zorder=3)
plt.bar(alldates, total_last_dose, color="#81C685", zorder=3)

plot_labels('Dagelijks toegediend', 'Datum', 'Aantal')

plt.legend(['1st of 2 doses', 'last dose'])

plt.show()
#endregion

#region Wekelijks_toegediend
total_first_dose = []
total_last_dose = []

for week in allweeks:
    first_dose = 0
    last_dose = 0
    for ad in ad_array:
        if week == to_week(ad['date']):
            first_dose += ad['first_dose']
            last_dose += ad['second_dose']

    total_first_dose.append(first_dose)
    total_last_dose.append(last_dose)

plt.bar(allweeks, total_first_dose, color='#FEB64D', zorder=3)
plt.bar(allweeks, total_last_dose, bottom=total_first_dose, color='#81C685', zorder=3)

plot_labels('Wekelijks toegediend', 'Week', 'Aantal')

plt.legend(['1st of 2 doses', 'last dose'])

plt.show()
#endregion

#region Leveringen_producenten
# Lijngrafiek
manufacturer = {
    "Pfizer/BioNTech": [],
    "Moderna": [],
    "AstraZeneca/Oxford": [],
    "Johnson&Johnson": []
}

total_cul_pfizer = 0
total_cul_moderna = 0
total_cul_astrazeneca = 0
total_cul_johnson = 0

for date in alldates:
    pfizer_amount = 0
    moderna_amount = 0
    astraZemeca_amount = 0
    johnsen_amount = 0

    for deliv in del_array:
        if (deliv['date'] == date):
            if deliv['manufacturer'] == 'Pfizer/BioNTech':
                pfizer_amount += deliv['amount']
            elif deliv['manufacturer'] == 'Moderna':
                moderna_amount += deliv['amount']
            elif deliv['manufacturer'] == 'AstraZeneca/Oxford':
                astraZemeca_amount += deliv['amount']
            elif deliv['manufacturer'] == 'Johnson&Johnson':
                johnsen_amount += deliv['amount']

    total_cul_pfizer += pfizer_amount;
    total_cul_moderna += moderna_amount;
    total_cul_astrazeneca += astraZemeca_amount;
    total_cul_johnson += johnsen_amount;

    manufacturer['Pfizer/BioNTech'].append(total_cul_pfizer)
    manufacturer['Moderna'].append(total_cul_moderna)
    manufacturer['AstraZeneca/Oxford'].append(total_cul_astrazeneca)
    manufacturer['Johnson&Johnson'].append(total_cul_johnson)

plt.plot(alldates, manufacturer['Pfizer/BioNTech'], zorder=3)
plt.plot(alldates, manufacturer['Moderna'], zorder=3)
plt.plot(alldates, manufacturer['AstraZeneca/Oxford'], zorder=3)
plt.plot(alldates, manufacturer['Johnson&Johnson'], zorder=3)

plot_labels('Leveringen producenten', 'Datum', 'Aantal (miljoen)')

plt.legend(['Pfizer/BioNTech', 'Moderna', 'AstraZeneca/Oxford', 'Johnson&Johnson'])

plt.show()
# Taartdiagram
labels = ['Pfizer/BioNTech', 'Moderna', 'AstraZeneca/Oxford', 'Johnson&Johnson']
data = []

manufacturer = {
    "Pfizer/BioNTech": 0,
    "Moderna": 0,
    "AstraZeneca/Oxford": 0,
    "Johnson&Johnson": 0
}

for deliv in del_array:
    manufacturer[deliv['manufacturer']] += deliv['amount']

for key in manufacturer:
    data.append(manufacturer[key])

plt.pie(data, explode=(0, 0.1, 0, 0), labels=labels, autopct='%1.1f%%', shadow=True, textprops={'color':"w"})

plt.title('Leveringen producenten', fontdict={'family':'serif','color':'white','size':18}, loc="center")

plt.show()
#endregion

#region Wekelijks_geleverd_dosissen
total_pfizer = []
total_moderna = []
total_astrazeneca = []
total_johnson = []

for week in allweeks:
    pfizer_amount = 0
    moderna_amount = 0
    astrazeneca_amount = 0
    johnson_amount = 0

    for deliv in del_array:
        if week == to_week(deliv['date']):
            if deliv['manufacturer'] == 'Pfizer/BioNTech':
                pfizer_amount += deliv['amount']
            elif deliv['manufacturer'] == 'Moderna':
                moderna_amount += deliv['amount']
            elif deliv['manufacturer'] == 'AstraZeneca/Oxford':
                astrazeneca_amount += deliv['amount']
            elif deliv['manufacturer'] == 'Johnson&Johnson':
                johnson_amount += deliv['amount']

    total_pfizer.append(pfizer_amount)
    total_moderna.append(moderna_amount)
    total_astrazeneca.append(astrazeneca_amount)
    total_johnson.append(johnson_amount)

# stacked
tot_pf_mod = np.add(total_pfizer, total_moderna).tolist()
tot_pf_mod_ast = np.array([total_pfizer, total_moderna, total_astrazeneca]).sum(axis=0)

plt.bar(allweeks, total_pfizer,color='#BBDEFB')
plt.bar(allweeks, total_moderna, bottom=total_pfizer, color='#E47273', zorder=3)
plt.bar(allweeks, total_astrazeneca, bottom=tot_pf_mod, color='#FEB74C', zorder=3)
plt.bar(allweeks, total_johnson, bottom=tot_pf_mod_ast, color='#80C785', zorder=3)

plot_labels('Wekelijks geleverd', 'Week', 'Aantal')

plt.legend(['Pfizer/BioNTech', 'Moderna', 'AstraZeneca/Oxford', 'Johnson&Johnson'])

plt.show()
#endregion

#region Vacconaties_per_leeftijdscategorie
# Leeftijd
ages = np.unique(ad_epi_split[2].flatten())
vaccinaties = []

for indx in range(len(ages)):
    count = 0
    for epi in ad_epi_array:
        if ages[indx] == epi['agegroup']:
            count += 1
    vaccinaties.append(count)

tot_vacc = np.sum(vaccinaties)
data = [(vac / tot_vacc) * 100 for vac in vaccinaties]

plt.barh(ages, data, color='#FEB64D', zorder=3)
ax.xaxis.set_major_formatter(mtick.PercentFormatter())

plot_labels('Vaccinaties per leeftijdscategorie', 'Aantal (%)', 'Leeftijden')

plt.show()
# geslacht
sex = np.unique(ad_epi_split[3].flatten())
vaccinaties = []

for indx in range(len(sex)):
    count = 0
    for epi in ad_epi_array:
        if sex[indx] == epi['sex']:
            count += 1
    vaccinaties.append(count)

tot_vacc = np.sum(vaccinaties)
data = [(vac / tot_vacc) * 100 for vac in vaccinaties]

plt.barh(sex, data, color='#FEB64D', height=0.7, zorder=3)
ax.xaxis.set_major_formatter(mtick.PercentFormatter())

plot_labels('Vaccinaties per geslacht', 'Aantal (%)', 'Geslacht')

plt.show()
#endregion

#region Producenten
# Taartdiagram
manufacturer = {
    "Pfizer/BioNTech": 0,
    "Moderna": 0,
    "AstraZeneca/Oxford": 0,
    "Johnson&Johnson": 0,
    "Curevac": 0
}

for deliv in del_array:
    manufacturer[deliv['manufacturer']] += deliv['amount']

data_first_layer = []

for indx, key in enumerate(manufacturer):
    data_first_layer.append([manufacturer[key], total_order[indx] - manufacturer[key]])

cmap = plt.get_cmap("tab20c")
outer_colors = cmap(np.arange(5)*4)
inner_colors = cmap([1, 2, 5, 6, 9, 10, 13, 14, 17, 18])

inner_labels = ['Del' , 'Tot', 'Del' , 'Tot', 'Del' , 'Tot', 'Del' , 'Tot', 'Del' , 'Tot']

plt.pie(np.array(data_first_layer).sum(axis=1), labels=[key for key in manufacturer], radius=1, colors=outer_colors,
       wedgeprops=dict(width=0.3, edgecolor='w'), textprops={'color':"w"})
plt.pie(np.array(data_first_layer).flatten(), labels=inner_labels, radius=0.7, colors=inner_colors,
       wedgeprops=dict(width=0.3, edgecolor='w'), textprops={'color':"w"})
plt.margins(0, 0)

subgroup_names_legs=['Pfizer/BioNTech', 'Moderna', 'AstraZeneca/Oxford', 
'Johnson&Johnson', 'Curevac']

plt.legend(loc=(0.9, 0.1))
handles, labels = ax.get_legend_handles_labels()

ax.legend(handles[3:], subgroup_names_legs, loc=(0.9, 0.7))

plt.title('Producenten taartdiagram', fontdict={'family':'serif','color':'white','size':18}, loc="center")

plt.show()
# Staaf
manufacturer = {
    "Pfizer/BioNTech": 0,
    "Moderna": 0,
    "AstraZeneca/Oxford": 0,
    "Johnson&Johnson": 0,
    "Curevac": 0
}
ordered = []
to_order = []

for deliv in del_array:
    manufacturer[deliv['manufacturer']] += deliv['amount']

for indx, key in enumerate(manufacturer):
    ordered.append(manufacturer[key])
    to_order.append(total_order[indx] - manufacturer[key])

plt.bar([key for key in manufacturer], ordered, color='#E47273', zorder=3)
plt.bar([key for key in manufacturer], to_order, bottom=ordered,  color='#FEB64D', zorder=3)

plot_labels('Producenten staafdiagram', 'Producenten', 'Aantal (10 miljoen)')

plt.legend(['Deliverd', 'To deliver'])

plt.show()
#endregion