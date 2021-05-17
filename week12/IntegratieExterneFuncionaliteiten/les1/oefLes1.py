import numpy as np
# oef 1
arrOef1 = np.arange(12, 38, 3)
print(arrOef1[::-1])

# oef 2
arr2DOef2 = np.linspace(2, 10, num=9, endpoint=True)
print(arr2DOef2)

arr3DOef2 = arr2DOef2.reshape(3,3)
print(arr3DOef2)

# oef 3

# eye()
# np.eye(...) geeft een 2 dimensionale array terug met '1' in een dialoog en de rest wordt opgevuld met '0'
# je kan met de paramters het aantal rijen en kolommen kiezen, 
# je kan ook met de 'k' paramter de positie kiezen van de diagonaal ten op zichte van het midden: default = 0 (dus in het midden) 1 = 1 rij boven het midden enz.. 

# 3 rijen en 3 kollomen met de diagonaal in het midden
print('EX1', np.eye(3, 3))

# 3 rijen en 3 kollomen met de diagonaal 1 positie boven het midden
print('EX2',np.eye(3, k=1))

# 3 rijen en 3 kollomen met de diagonaal 1 positie onder het midden
print('EX3',np.eye(3, k=-1))

# identity()
# np.identity(...) is een 2 dimensuonale array die bestaat uit nullen en een diagonaal van '1' heeft in het midden.
# het heeft een parameter n die aangeeft hoeveel rijen en kolommen je wilt
# een array met 4 kolommen en rijen
print(np.identity(4))

# ones()
# np.ones(...) is een functie om een array aan te maken met bepaalde shape die gevuld is met '1'
# gewone array met 5 enen
print(np.ones(5))

# een twee dimensionale array met 2 kolommen en 2 rijen gevuld met enen
print(np.ones((2, 2)))

# zeros()
# np.zeros(...) idem. als zeros maar de array wordt gevuld met '0'
# gewone array met 5 nullen
print(np.zeros(5))

# een twee dimensionale array met 2 kolommen en 2 rijen gevuld met nullen
print(np.zeros((2, 2)))

# full()
# np.full(...) idem. als ones and zeros maar de array wordt gevuld met een zelf gekozen value die als parameter wordt meegegeven
# gewone array met 5 '10'
print(np.full(5, 10))

# een twee dimensionale array met 2 kolommen en 2 rijen gevuld met '10'
print(np.full((2, 2), 10))


# voor de laatste 3
x = np.arange(6)
x = x.reshape((2, 3))
x
# ones_like()
# np.ones_like(...) is een functie die een array terug geeft gevuld met 'enen' die dezelfde shape heeft als de array die wordt meegeven als parameter
print(np.ones_like(x))


# zeros_like()
# np.zeros_like(...) is een functie die een array terug geeft gevuld met 'nullen' die dezelfde shape heeft als de array die wordt meegeven als parameter
print(np.zeros_like(x))

# full_like()
# np.full_like(...) is een functie die een array terug geeft gevuld met 'waardes die je zelf kan kiezen' die dezelfde shape heeft als de array die wordt meegeven als parameter
print(np.full_like(x, 10))