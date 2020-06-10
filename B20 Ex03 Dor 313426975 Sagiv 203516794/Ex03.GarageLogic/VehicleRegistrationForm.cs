using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleRegistrationForm
    {
        private static readonly int sr_MaxLEngthPhoneNumber = 10;
        private static readonly int sr_MinLEngthPhoneNumber = 9;

        public enum eStatusOfFix
        {
            InProgress = 0,
            Fixed,
            Paid
        }

        private readonly string r_OwnerName;
        private readonly Vehicle m_Vehicle;
        private string m_PhoneNumber;
        private eStatusOfFix m_Status;

        public VehicleRegistrationForm(Vehicle i_NewVehcile, string i_OwnerName)
        {
            r_OwnerName = i_OwnerName;
            m_Vehicle = i_NewVehcile;
            Status = eStatusOfFix.InProgress;
        }

        public string OwnerName
        {
            get { return r_OwnerName; }
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set
            {
                // catch format exception
                isValidPhoneNumber(value);
                m_PhoneNumber = value;
            }
        }

        public eStatusOfFix Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        private void isValidPhoneNumber(string i_PhoneNumber)
        {
            long.Parse(i_PhoneNumber); // catch exception of parse

            if (i_PhoneNumber.Length > sr_MaxLEngthPhoneNumber || i_PhoneNumber.Length < sr_MinLEngthPhoneNumber)
            {
                throw new ValueOutOfRangeException(sr_MinLEngthPhoneNumber, sr_MaxLEngthPhoneNumber);
            }
        }

        // Overriding Object.Equals using this.GetHasCode as the logic for comaprison
        public override bool Equals(object io_obj)
        {
            bool eqauls = false;

            if (io_obj != null)
            {
                VehicleRegistrationForm toCompareTo = io_obj as VehicleRegistrationForm;

                if (toCompareTo != null)
                {
                    eqauls = this.GetHashCode() == toCompareTo.GetHashCode();
                }
            }

            return eqauls;
        }

        public static bool operator ==(VehicleRegistrationForm lhs, VehicleRegistrationForm rhs)
        {
            bool v_EqualsRegistrationForm = false;

            if (lhs.Equals(rhs) == true)
            {
                v_EqualsRegistrationForm = true;
            }

            return v_EqualsRegistrationForm;
        }

        public static bool operator !=(VehicleRegistrationForm lhs, VehicleRegistrationForm rhs)
        {
            return !(lhs == rhs);
        }

        // Overriding Object.GetHasCode using m_PhoneNumber as the logic
        public override int GetHashCode()
        {
            return m_PhoneNumber.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder allDetailsOfVehicleAndOwner = new StringBuilder();

            string treatmentDetails = string.Format(@"Owner name: {0}{3}Phone Number: {1}{3}Status Of Fix: {2}", OwnerName, PhoneNumber, Status, Environment.NewLine);

            allDetailsOfVehicleAndOwner.Append(treatmentDetails);
            allDetailsOfVehicleAndOwner.Append(Vehicle.ToString());

            return allDetailsOfVehicleAndOwner.ToString();
        }

        public void CheckEqualStatus(eStatusOfFix userChoice)
        {
            if (userChoice == m_Status)
            {
                throw new ArgumentException(string.Format("The vehicle is already in {0} status", m_Status));
            }
        }

        public void ChangeStatusOfFixToInProgress()
        {
            Status = eStatusOfFix.InProgress;
        }
    }
}
