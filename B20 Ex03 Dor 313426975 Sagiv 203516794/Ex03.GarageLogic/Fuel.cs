using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Fuel : EnergySource
    {
        // to support in adding other type of car that can be charging fuel
        //private static List<>;
        // replace in list of fuel type to avoid problem in including another type of vehicle like traktor and to throw exception in finding type of fuel
        public enum eFuelType
        {
            Octan98 = 0,
            Octan96,
            Octan95,
            Soler
        }

        public enum eCapacity
        {
            Car = 60,
            Motocycle = 7,
            Truck = 120
        }

        private eFuelType m_FuelType;

        public eFuelType FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

        public override void ChargeEnergySource(ChargingVehicleDetails i_ChargingDetails)
        {
            // catch exception
            checkEnergySourceType(i_ChargingDetails.TypeOfEnergySource);
            checkForAvailableTypeOfFuel(i_ChargingDetails.FuelType.Value);
            checkForDeviationInTank(i_ChargingDetails.QuantityOfEnergyToAdd);

            this.QuantityOfEnergyLeft += i_ChargingDetails.QuantityOfEnergyToAdd;
        }

        public override void checkForDeviationInTank(float i_QuantityOfEnergyToAdd)
        {
            if (this.QuantityOfEnergyLeft + i_QuantityOfEnergyToAdd > this.MaxOfEnergyCanContain || this.QuantityOfEnergyLeft + i_QuantityOfEnergyToAdd < 0)
            {
                // in catch block make m_CurrAirPressure = m_MaxAirPressure
                throw new ValueOutOfRangeException(0, this.MaxOfEnergyCanContain);
            }
        }

        private void checkForAvailableTypeOfFuel(eFuelType i_FuelType)
        {
            if (i_FuelType != m_FuelType)
            {
                // catch exception
                throw new ArgumentException(String.Format(@"Trying To Fuel your Vehicle With {0} When Your Vehicles Runs on {1}", i_FuelType, m_FuelType));
            }
        }

        public override void checkEnergySourceType(eTypeOfEnergySource i_TypeOfEnergySource)
        {
            if (i_TypeOfEnergySource != eTypeOfEnergySource.Fuel)
            {
                throw new ArgumentException(String.Format(@"be careful looks like you are trying to charge your gas tank with electricity"));
            }
        }
        public override string ToString()
        {
            return string.Format(@"
Vehicle Fuel Left: {0}
Vehicle Fuel Type: {1}
vehicle Capacity Of Tank: {2}", QuantityOfEnergyLeft, m_FuelType, MaxOfEnergyCanContain);
        }
    }
}
