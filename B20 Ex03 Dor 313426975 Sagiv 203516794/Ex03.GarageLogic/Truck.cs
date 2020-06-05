using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    // think how to support electric Truck on the future
    class Truck : Vehicle
    {
        private static readonly float sr_TruckMaxAirPressure = float.Parse(eMaxAirPressure.Truck.ToString());
        private static readonly int sr_TruckAmountOfWheels = 16;
        private static readonly float sr_TruckMaxGasTank = 120;
        private static readonly Fuel.eFuelType sr_TruckFuelType = Fuel.eFuelType.Soler;

        private bool v_ContainHazerMaterial;
        private float m_CargoVolume;

        public Truck(string i_LicenceNumber, string i_ModelName, EnergySource.eTypeOfEnergySource i_EnergySourceType,
            string i_WheelManufactorName)
            : base(i_LicenceNumber, i_ModelName, i_EnergySourceType)
        {
            for (int i = 0; i < sr_TruckAmountOfWheels; i++)
            {
                CollectionOfWheels.Add(new Wheel(i_WheelManufactorName, sr_TruckMaxAirPressure));
            }

            SetEnergySource();
        }

        public bool ContainHazerMaterial
        {
            get { return v_ContainHazerMaterial; }
            set { v_ContainHazerMaterial = value; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public override void SetEnergySource()
        {
            if (EnergySource is Battery)
            {
                throw new ArgumentException("This System Doesn't Support Electric Truck yet");
            }
            else
            {
                Fuel myEnergySource = EnergySource as Fuel;
                myEnergySource.FuelType = sr_TruckFuelType;
                myEnergySource.MaxOfEnergyCanContain = sr_TruckMaxGasTank;
            }
        }

        public override string ToString()
        {
            return String.Format(@"{0}
Truck's Cargo Volume: {1}
Truck Contain Hazard Material: {2}", VehicleDetails(), m_CargoVolume, v_ContainHazerMaterial);
        }
    }
}
