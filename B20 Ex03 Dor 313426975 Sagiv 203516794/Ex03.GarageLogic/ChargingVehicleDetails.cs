using System;

namespace Ex03.GarageLogic
{
    public struct ChargingVehicleDetails
    {
        private readonly string r_LicenceNumber;
        private float m_QuantityOfEnergyToAdd;
        private readonly EnergySource.eTypeOfEnergySource r_TypeOfEnergySource;
        private readonly Nullable<Fuel.eFuelType> r_FuelType;

        public ChargingVehicleDetails(string i_LicenceNumber, string i_QuantityOfEnergyToAdd, string i_TypeOfEnergySource, string i_FuelType)
        {
            // catch argument exception in case
            r_FuelType = DecodeFuelTypeFromUserIfExist(i_FuelType);
            m_QuantityOfEnergyToAdd = DecodeQuantityOfEnergyToAdd(i_QuantityOfEnergyToAdd);
            r_TypeOfEnergySource = DecodeTypeOfEnergySource(i_TypeOfEnergySource);
            r_LicenceNumber = i_LicenceNumber;

        }

        public float QuantityOfEnergyToAdd
        {
            get { return m_QuantityOfEnergyToAdd; }
            set { m_QuantityOfEnergyToAdd = value; }
        }

        public EnergySource.eTypeOfEnergySource TypeOfEnergySource
        {
            get { return r_TypeOfEnergySource; }
            //set { m_TypeOfEnergySource = value; }
        }

        public Nullable<Fuel.eFuelType> FuelType
        {
            get { return r_FuelType; }
            //set { m_FuelType = value; }
        }

        public string LicenceNumber
        {
            get { return r_LicenceNumber; }
            //set { m_FuelType = value; }
        }

        private static Fuel.eFuelType? DecodeFuelTypeFromUserIfExist(string i_FuelType)
        {
            Fuel.eFuelType? fuelType;

            if (i_FuelType == null)
            {
                fuelType = null;
            }
            else
            {
                if (i_FuelType == "Octan95" || i_FuelType == "octan95")
                {
                    fuelType = Fuel.eFuelType.Octan95;
                }
                else if (i_FuelType == "Octan96" || i_FuelType == "octan96")
                {
                    fuelType = Fuel.eFuelType.Octan96;
                }
                else if (i_FuelType == "Octan98" || i_FuelType == "octan98")
                {
                    fuelType = Fuel.eFuelType.Octan98;
                }
                else if (i_FuelType == "Soler" || i_FuelType == "soler")
                {
                    fuelType = Fuel.eFuelType.Soler;
                }
                else
                {
                    throw new ArgumentException("We don't Have This Kind of Fuel In Our Garage");
                }
            }

            return fuelType;
        }

        private static float DecodeQuantityOfEnergyToAdd(string i_QuantityOfEnergyToAdd)
        {
            bool v_Parsing;
            float quantityToAdd;

            v_Parsing = float.TryParse(i_QuantityOfEnergyToAdd, out quantityToAdd);

            if (v_Parsing == false)
            {
                throw new FormatException("You Need To Enter An Num (float) Of quantity you want to add");
            }

            return quantityToAdd;
        }

        private static EnergySource.eTypeOfEnergySource DecodeTypeOfEnergySource(string i_TypeOfEnergySource)
        {
            EnergySource.eTypeOfEnergySource typeOfEnergySource;

            if (i_TypeOfEnergySource == "Battery" || i_TypeOfEnergySource == "battery")
            {
                typeOfEnergySource = EnergySource.eTypeOfEnergySource.Battery;
            }
            else if (i_TypeOfEnergySource == "Fuel" || i_TypeOfEnergySource == "fuel")
            {
                typeOfEnergySource = EnergySource.eTypeOfEnergySource.Fuel;
            }
            else
            {
                throw new ArgumentException("we don't have that kind of enery source here");
            }

            return typeOfEnergySource;
        }
    }
}
