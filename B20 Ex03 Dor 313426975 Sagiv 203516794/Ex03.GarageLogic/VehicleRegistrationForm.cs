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

        private enum eStatusOfFix
        {
            InProgress,
            Fixed,
            Paid
        }

        private readonly string  r_OwnerName;
        private string  m_PhoneNumber;
        private eStatusOfFix     m_Status;
        private Vehicle         m_Vehicle;

        public VehicleRegistrationForm(Vehicle i_NewVehcile, string i_OwnerName, string i_OwnerPhone)
        {
            r_OwnerName = i_OwnerName;
            PhoneNumber = i_OwnerPhone;
            Vehicle = i_NewVehcile;
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

        private eStatusOfFix Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        private Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }

        private void  isValidPhoneNumber(string i_PhoneNumber)
        {
            // catch exception of parse
            long.Parse(i_PhoneNumber);
            if (i_PhoneNumber.Length > sr_MaxLEngthPhoneNumber || i_PhoneNumber.Length < sr_MinLEngthPhoneNumber)
            {
                throw new ValueOutOfRangeException(sr_MinLEngthPhoneNumber, sr_MaxLEngthPhoneNumber));
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
    }

}
