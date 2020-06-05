using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private static readonly float sr_MotorcycleWheelMaxAirPressure = float.Parse(eMaxAirPressure.Motorcycle.ToString());
        private static readonly int sr_MotorcycleAmountOfWheels = 2;
        private static readonly float sr_MotorcycleMaxBatteryTime = 1.2f;
        private static readonly float sr_MotorcycleMaxGasTank = 7;
        private static readonly Fuel.eFuelType sr_MotocycleFuelType = Fuel.eFuelType.Octan95;

        public enum eCategoryOfmotocycleLicence
        {
            A = 0,
            A1,
            AA,
            B
        }

        private eCategoryOfmotocycleLicence m_CategoryOfmotocycleLicence;
        private int m_EngineCapacity;

        public Motorcycle(string i_LicenceNumber, string i_ModelName, EnergySource.eTypeOfEnergySource i_EnergySourceType, string i_WheelManufactorName)
            : base(i_LicenceNumber, i_ModelName, i_EnergySourceType)
        {
            for (int i = 0; i < sr_MotorcycleAmountOfWheels; i++)
            {
                CollectionOfWheels.Add(new Wheel(i_WheelManufactorName, sr_MotorcycleWheelMaxAirPressure));
            }

            SetEnergySource();
        }

        public override void SetEnergySource()
        {
            if (EnergySource is Battery)
            {
                Battery myBattery = EnergySource as Battery;
                myBattery.MaxOfEnergyCanContain = sr_MotorcycleMaxBatteryTime;
            }
            else
            {
                Fuel myGasTank = EnergySource as Fuel;
                myGasTank.FuelType = sr_MotocycleFuelType;
                myGasTank.MaxOfEnergyCanContain = sr_MotorcycleMaxGasTank;
            }
        }

        public eCategoryOfmotocycleLicence CategoryOfmotocycleLicence
        {
            get { return m_CategoryOfmotocycleLicence; }
            set { m_CategoryOfmotocycleLicence = value; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }

        public override string ToString()
        {
            return String.Format(@"{0}
Category of licence: {1}
Engine Capacity: {2}", VehicleDetails(), m_CategoryOfmotocycleLicence, m_EngineCapacity);
        }
    }
}
