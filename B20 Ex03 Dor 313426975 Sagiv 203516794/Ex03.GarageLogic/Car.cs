using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private static readonly float sr_CarMaxAirPressure = (float) eMaxAirPressure.Car;
        private static readonly int sr_CarAmountOfWheels = 4;
        private static readonly float sr_CarMaxBatteryTime = 2.1f;
        private static readonly float sr_CarMaxGasTank = 60;
        private static readonly Fuel.eFuelType sr_CarFuelType = Fuel.eFuelType.Octan96;

        public enum eCarColor
        {
            Red,
            Black,
            White,
            Silver
        }

        public enum eDoorsAmount
        {
            Two,
            Three,
            Four,
            Five
        }

        private eDoorsAmount m_DoorsAmount;
        private eCarColor m_Color;

        public Car(string i_LicenceNumber, string i_ModelName, EnergySource.eTypeOfEnergySource i_EnergySourceType,
            string i_WheelManufactorName)
            : base(i_LicenceNumber, i_ModelName, i_EnergySourceType)
        {
            for (int i = 0; i < sr_CarAmountOfWheels; i++)
            {
                CollectionOfWheels.Add(new Wheel(i_WheelManufactorName, sr_CarMaxAirPressure));
            }

            SetEnergySource();
        }

        public eDoorsAmount DoorsAmount
        {
            get { return m_DoorsAmount; }
            set { m_DoorsAmount = value; }
        }

        public eCarColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public override void SetEnergySource()
        {
            if (EnergySource is Battery)
            {
                Battery myBattery = EnergySource as Battery;
                myBattery.MaxOfEnergyCanContain = sr_CarMaxBatteryTime;
            }
            else
            {
                Fuel myGasTank = EnergySource as Fuel;
                myGasTank.FuelType = sr_CarFuelType;
                myGasTank.MaxOfEnergyCanContain = sr_CarMaxGasTank;
            }
        }

        public override string ToString()
        {
            return String.Format(@"{0}
Car Amount Of Doors: {1}
Car Color: {2}", VehicleDetails(), m_DoorsAmount, m_Color);
        }

        public override void FillRestDetails(object i_DatailsOne, object i_DetailsTwo)
        {
            this.DoorsAmount = (eDoorsAmount)i_DatailsOne;
            this.Color = (eCarColor)i_DetailsTwo;
        }
    }
}

