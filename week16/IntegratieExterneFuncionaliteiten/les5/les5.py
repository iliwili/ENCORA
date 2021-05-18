import mysql.connector
import numpy as np

# DEEL 1
mijnDB = mysql.connector.connect(
    host="localhost",
    user="root",
    password="",
    database = "les5"
)

mijnCursor = mijnDB.cursor()

mijnCursor.execute("SELECT * FROM t_geleverd")
arr_geleverd = mijnCursor.fetchall()
arr_num_geleverd = np.array(arr_geleverd)

# print(arr_geleverd)
# print(arr_num_geleverd.dtype)

dtypes = [('date', 'M8[D]'), ('amount', int), ('manufacturer', 'U50')]
ndarray = np.array(arr_geleverd, dtype=dtypes)
# print(ndarray[0])


# DEEL 2
geleverd_split = np.array_split(arr_num_geleverd, 3, axis = 1)
# print('\n gesplitste array:')
# print(geleverd_split)
# print(geleverd_split[0])

dates = geleverd_split[0].flatten()
dates = dates.astype('M')

amount = geleverd_split[1].flatten()
amount = amount.astype('i')

manufacturer = geleverd_split[2].flatten()
manufacturer = manufacturer.astype('U')


# DEEL 3

# 1
print(np.sum(amount))
# 2
print(np.unique(manufacturer))
# 3
print(np.unique(manufacturer, return_counts=True))
# 4
print(np.unique(dates, return_counts=True))
print(np.stack(np.array(np.unique(dates, return_counts=True)),axis=1))
# 5 -> WHERE
bools = np.logical_and(amount > 100000, amount > 0)
arrFilter = amount[bools]
print(arrFilter)
# 6
print(np.unique(manufacturer[bools]))
# 7
