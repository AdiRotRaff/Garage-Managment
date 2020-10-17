# GarageManagment

# Goals:
* Assimilation of work with departments, inheritance and polymorphism
* Collections in use
* Implementation enums
* Development and use of external Dll (assembly)
* Working with multiple projects
* Working with Exceptions


# Knowledge required:
* Object-Oriented Programming Using C # Polymorphism
* Collections in use
* Development and use of external Dll (Assembly)
* Working with several projects
* Work with Exceptions
* inheritance From Object

# The ultimate goal:
a small system that "runs" a garage.
The system will know how to run a garage that currently handles five types of vehicles -
• Regular motorcycle
(2 wheels with maximum air pressure, 30 fuel type, Octan95 7 liter fuel tank)
• electric motorcycle
(2 wheels with maximum air pressure, 30 maximum battery time - 1.2 hours)
• Normal car
4 (wheels with maximum air pressure, 32 fuel type, Octan96 60 liter fuel tank)
• electric car
(4 wheels with maximum air pressure, 32 maximum battery time - 2.1 hours)
• Truck
(16 wheels with maximum air pressure, 28 fuel type, Soler 120 liter fuel tank)

# Every vehicle has the features:
• Model name (string)
• license number (string)
• Percentage of energy remaining in its energy source (for the fuel / electricity meter) (Folat)
• Collection of wheels

# Each wheel has the following features:
• Manufacturer name (string)
• Current air pressure (float)
• Maximum air pressure set by the manufacturer (float)
• Inflation action (a method that gets a figure about how much air to add to a wheel, and changes the
Air pressure condition if it does not exceed the maximum)

# in addition to the features of a vehicle, also has the features:
# The motorcycle (regular / electric)
•Type license: A, A1, AA, B
• Engine volume in cc (int)

# The car (regular / electric)
• Color (possible colors are, red, white, black, silver)
• Number of doors, 2 (, 3, 4 or 5)
# The truck
• Does driving hazardous substances (bool)
• Float cargo volume

In a vehicle that runs on fuel you can find the following information and perform the following actions:
• Fuel Type: Soler, Octan95, Octan96, Octan98
• Current amount of fuel in liters (float)
• Maximum amount of fuel in liters (float)
• Refueling operation (a method that receives a quantity of liters for addition and type of fuel, and changes the fuel condition
If the type of fuel is suitable and there is no deviation from the size of the tank)

# In an electric vehicle you can find the following information and perform the following actions:
• Battery time remaining in hours (float)
• Maximum battery time in float hours
• Battery charging operation (a method that receives a data that is several hours to add to the battery and "charges" the
The battery, respectively, as long as the number of hours does not exceed the maximum)

# The following data must be kept for each vehicle in the garage:
• owner name (string)
• Phone owner (string)
• Vehicle condition in the garage (possible conditions: repaired, repaired, paid)
• Every vehicle that enters the garage in its initial condition is 'in repair.'

# The system will provide the following functionality to its user:
1. "Put" a new car in the garage. If you try to put a vehicle that is already in the garage (according to the license number), the system will issue a suitable message and use the vehicle that is already in the garage (and will change the condition of the vehicle to "repaired")
2. View the list of the license numbers of the vehicles in the garage, with the option to filter according to their condition in the garage.
3. Change the condition of a vehicle in the garage (the data requested from the user is the license number and the new condition.)
4. To inflate air in the wheels of a vehicle to the maximum (by license number)
5. Refuel a vehicle that is powered by fuel (the data is the license number, type of fuel to be refilled, as well as to be refilled)
6. Charge an electric vehicle (data is license number, amount of minutes to charge)
7. Display complete data of vehicle by license number (license number, model name, owner name, condition of the garage, details of the wheels (air pressure and manufacturer), fuel status + fuel type / battery status, and other details relevant to the specific vehicle type)
