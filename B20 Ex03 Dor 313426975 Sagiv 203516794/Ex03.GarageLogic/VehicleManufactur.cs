using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class VehicleManufactur
    {
        public static Vehicle CreateVehicles(string i_LicenceNumber, string i_ModelName,
            EnergySource.eTypeOfEnergySource i_Source, string i_WheelManuFactorName, string i_KingOfVehicle)
        {
            Vehicle newVehicle;
            if (i_KingOfVehicle == "Car")
            {
                newVehicle = new Car(i_LicenceNumber, i_ModelName, i_Source, i_WheelManuFactorName);
            }
            else if (i_KingOfVehicle == "Motorcycle")
            {
                newVehicle = new Motorcycle(i_LicenceNumber, i_ModelName, i_Source, i_WheelManuFactorName);
            }
            else if (i_KingOfVehicle == "Truck")
            {
                newVehicle = new Truck(i_LicenceNumber, i_ModelName, i_Source, i_WheelManuFactorName);
            }
            else
            {
                throw  new ArgumentException(String.Format("Vehicle Manufacture doesn't support this ({0}) kind of vehicle yet", i_KingOfVehicle));
            }

            return newVehicle;
        }
    }
}
