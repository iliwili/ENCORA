import mysql.connector
import numpy as np

mijnDB = mysql.connector.connect(
    host = 'localhost',
    user = 'root',
    password = '',
    database = 'vaccins'
)

mijnCursor = mijnDB.cursor()
mijnCursor.execute('SELECT * from delivered')
geleverd = mijnCursor.fetchall()

print('\n data uit de databank:')
print(geleverd)

#numpy array
geleverd_arr = np.array(geleverd)
print('\n ndarray:')
print(geleverd_arr)

#met dtypes
dtypes = [('datum','M8[D]'),('aantal','i'),('leverancier','U50')]
geleverd_arr_dtypes = np.array(geleverd, dtype = dtypes)
print('\n ndarry met dtypes:')
print(geleverd_arr_dtypes)

#Deel 2
#array_split
geleverd_split = np.array_split(geleverd_arr, 3, axis = 1)
print('\n gesplitste array:')
print(geleverd_split)
print(geleverd_split[0])

#flatten
datums = geleverd_split[0].flatten()
print('\n flatten datum:', datums)
print('dtype datums: ', datums.dtype)
datums = datums.astype('M')
print('\n flatten datum met juiste dtype:', datums)
print('dtype datums: ', datums.dtype)

aantallen = geleverd_split[1].flatten()
aantallen = aantallen.astype('i')

leveranciers = geleverd_split[2].flatten()
leveranciers = leveranciers.astype('U')

print('\nalle 1D array:')
print(datums)
print(datums.dtype)
print(aantallen)
print(aantallen.dtype)
print(leveranciers)
print(leveranciers.dtype)

#rot90
geleverd_rot = np.rot90(geleverd_arr, -1)
print('\n gedraaide array')
print(geleverd_rot)

datums = np.array(np.rot90(geleverd_arr)[2], dtype = 'M8[D]')
aantallen = np.array(np.rot90(geleverd_arr)[1], dtype = 'i')
leveranciers = np.array(np.rot90(geleverd_arr)[0])

print('\n alle 1D array:')
print(datums)
print(datums.dtype)
print(aantallen)
print(aantallen.dtype)
print(leveranciers)
print(leveranciers.dtype)

#DEEL 3
#1
print('\n totaal vaccins:')
print(np.sum(aantallen))

#2
print('\n unieke leveranciers:')
print(np.unique(leveranciers))

#3
print('\n levering per leverancier:')
print(np.unique(leveranciers, return_counts=True))

#4
print('\n leveringen per datum:')
print(np.unique(datums, return_counts=True))
print(np.stack(np.array(np.unique(datums, return_counts=True)),axis=1))

#5
print('\n leveringen boven 100duizend:')
aantallen_boven_100k = np.where(aantallen>100000)
print(aantallen_boven_100k)
print(aantallen[np.where(aantallen>100000)])

#6
print(leveranciers[aantallen_boven_100k])

#7
print(np.stack((leveranciers[aantallen_boven_100k],aantallen[aantallen_boven_100k]), axis=1))

#8
print(len(aantallen_boven_100k[0]))

#9
print(aantallen[np.where(datums == np.datetime64('2021-02-22'))])

#10
feb = np.where(np.logical_and(datums > np.datetime64('2021-01-31'), datums < np.datetime64('2021-03-01')))
print(feb)
feb_aantallen = aantallen[feb]
print(feb_aantallen)
print(np.sum(aantallen[np.where(np.logical_and(datums > np.datetime64('2021-01-31'), datums < np.datetime64('2021-03-01')))]))

#11
print(np.sort(geleverd_arr_dtypes, order= "aantal"))
