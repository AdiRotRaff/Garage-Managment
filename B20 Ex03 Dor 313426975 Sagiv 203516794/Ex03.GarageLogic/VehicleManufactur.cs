using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleManufactur
    {
        // to support new type of vehivcle all you need to do is right new vehicle manufactor with new enum (JOB DONE)
        public enum eSupportedVehicle
        {
            Motorcycle = 0,
            Car,
            Truck,
        }

        public static Vehicle CreateVehicles(out bool v_VehicleIsValid, string i_LicenceNumber, string i_ModelName, EnergySource.eTypeOfEnergySource i_Source, string i_WheelManuFactorName, eSupportedVehicle i_typeOfVehicleToInsert)
        {
            Vehicle newVehicle;

            if (i_typeOfVehicleToInsert == eSupportedVehicle.Car)
            {
                newVehicle = new Car(i_LicenceNumber, i_ModelName, i_Source, i_WheelManuFactorName);
            }
            else if (i_typeOfVehicleToInsert == eSupportedVehicle.Motorcycle)
            {
                newVehicle = new Motorcycle(i_LicenceNumber, i_ModelName, i_Source, i_WheelManuFactorName);
            }
            else if (i_typeOfVehicleToInsert == eSupportedVehicle.Truck)
            {
                newVehicle = new Truck(i_LicenceNumber, i_ModelName, i_Source, i_WheelManuFactorName);
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle Manufacture doesn't support this ({0}) kind of vehicle yet", i_typeOfVehicleToInsert));
            }

            v_VehicleIsValid = true;
            return newVehicle;
        }
    }
}
