using System;

namespace Ex03.GarageLogic
{
    public struct ChargingVehicleDetails
    {
        private float m_QuantityOfEnergyToAdd;
        private EnergySource.eTypeOfEnergySource m_TypeOfEnergySource;
        private Nullable<Fuel.eFuelType> m_FuelType;

        public ChargingVehicleDetails(float i_QuantityOfEnergyToAdd, EnergySource.eTypeOfEnergySource i_TypeOfEnergySource, Nullable<Fuel.eFuelType> i_FuelType)
        {
            // check for good fuel type
            // throw exception in case
            // check for fill more than max energy can contain and make curr energy max in case of more than maz
            // throw exception
        }

        public float QuantityOfEnergyToAdd
        {
            get { return m_QuantityOfEnergyToAdd; }
            set { m_QuantityOfEnergyToAdd = value; }
        }

        public EnergySource.eTypeOfEnergySource TypeOfEnergySource
        {
            get { return m_TypeOfEnergySource; }
            set { m_TypeOfEnergySource = value; }
        }

        public Nullable<Fuel.eFuelType> FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }
    }
}
