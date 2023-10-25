using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenceNumber;
        private readonly EnergySource r_EnergySource;
        private readonly List<Wheel> r_CollectionOfWheels;
        private float m_PrecentageOfRemainingEnergy;

        public static bool operator ==(Vehicle lhs, Vehicle rhs)
        {
            bool v_EqualsRegistrationForm = false;

            if (lhs.Equals(rhs) == true)
            {
                v_EqualsRegistrationForm = true;
            }

            return v_EqualsRegistrationForm;
        }

        public static bool operator !=(Vehicle lhs, Vehicle rhs)
        {
            return !(lhs == rhs);
        }

        public Vehicle(string i_LicenceNumber, string i_ModelName, EnergySource.eTypeOfEnergySource i_Source)
        {
            r_ModelName = i_ModelName;
            r_LicenceNumber = i_LicenceNumber;
            r_CollectionOfWheels = new List<Wheel>();

            if (i_Source == EnergySource.eTypeOfEnergySource.Battery)
            {
                r_EnergySource = new Battery();
            }
            else
            {
                r_EnergySource = new Fuel();
            }
        }

        public string ModelName
        {
            get { return r_ModelName; }
        }

        public string LicenceNumber
        {
            get { return r_LicenceNumber; }
        }

        public float PrecentageOfRemainingEnergy
        {
            get { return m_PrecentageOfRemainingEnergy; }
            set { m_PrecentageOfRemainingEnergy = value; }
        }

        public EnergySource EnergySource
        {
            get { return r_EnergySource; }
        }

        public List<Wheel> CollectionOfWheels
        {
            get { return r_CollectionOfWheels; }
        }

        // catch exception
        public override bool Equals(object io_obj)
        {
            bool eqauls = false;

            if (io_obj != null)
            {
                Vehicle toCompareTo = io_obj as Vehicle;

                if (toCompareTo != null)
                {
                    eqauls = this.GetHashCode() == toCompareTo.GetHashCode();
                }
            }

            return eqauls;
        }

        // Overriding Object.GetHasCode using r_LicenceNumber as the logic
        public override int GetHashCode()
        {
            return r_LicenceNumber.GetHashCode();
        }

        public string VehicleDetails()
        {
            string vehicleDetails = string.Format(@"{5}Licence Number: {0}{5}Model : {1}{5}Wheel: {2}{5}Precentage Of Remaining Energy: {3}{5}Energy Source: {4}", r_LicenceNumber, r_ModelName, r_CollectionOfWheels[0].ToString(), m_PrecentageOfRemainingEnergy, EnergySource.ToString(), Environment.NewLine);

            return vehicleDetails;
        }

        public void UpdateEnergyPercent()
        {
            m_PrecentageOfRemainingEnergy = (EnergySource.QuantityOfEnergyLeft / EnergySource.MaxOfEnergyCanContain) * 100;
        }

        public abstract void SetEnergySource();

        public abstract void FillRestDetails(object i_DatailsOne, object i_DetailsTwo);

        public abstract override string ToString();
    }
}
