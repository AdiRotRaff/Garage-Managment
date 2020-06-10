using System;

namespace Ex03.GarageLogic
{
    public struct ChargingVehicleDetails
    {
        private readonly string r_LicenceNumber;
        private readonly float r_QuantityOfEnergyToAdd;
        private readonly EnergySource.eTypeOfEnergySource r_TypeOfEnergySource;
        private readonly Fuel.eFuelType? r_FuelType;

        public ChargingVehicleDetails(string i_LicenceNumber, float i_QuantityOfEnergyToAdd, EnergySource.eTypeOfEnergySource i_TypeOfEnergySource, Fuel.eFuelType? i_FuelType)
        {
            // catch argument exception in case
            if (i_FuelType.HasValue == true)
            {
                r_FuelType = i_FuelType;
            }
            else
            {
                r_FuelType = null;
            }

            r_QuantityOfEnergyToAdd = i_QuantityOfEnergyToAdd;
            r_TypeOfEnergySource = i_TypeOfEnergySource;
            r_LicenceNumber = i_LicenceNumber;
        }

        public float QuantityOfEnergyToAdd
        {
            get { return r_QuantityOfEnergyToAdd; }
        }

        public EnergySource.eTypeOfEnergySource TypeOfEnergySource
        {
            get { return r_TypeOfEnergySource; }
        }

        public Fuel.eFuelType? FuelType
        {
            get { return r_FuelType; }
        }

        public string LicenceNumber
        {
            get { return r_LicenceNumber; }
        }
    }
}
