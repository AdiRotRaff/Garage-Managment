using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManagment
    {
        // key is LicenceNumber and data is VehicleRegistrationForm
        private readonly Dictionary<string, VehicleRegistrationForm> r_DictionaryOfAllPatient = new Dictionary<string, VehicleRegistrationForm>();

        public Dictionary<string, VehicleRegistrationForm> DictionaryOfAllPatient
        {
            get { return r_DictionaryOfAllPatient; }
        }

        public void EnterVehicleToGarage(VehicleRegistrationForm i_RegistrationForm)
        {
            if (r_DictionaryOfAllPatient.ContainsKey(i_RegistrationForm.Vehicle.LicenceNumber) == true)
            {
                throw new ArgumentException("You Vehicle is in the garage already so i will update his status of fix to In Progress");
                // remember to catch in case and
                //m_DictionaryOfAllpatient[i_NewVehicle].ChangeStatusOfFixToInProgress();
            }
            else
            {
                r_DictionaryOfAllPatient.Add(i_RegistrationForm.Vehicle.LicenceNumber, i_RegistrationForm);
            }
        }

        public void ChangeStatusOfvehicleAccordingToLicenceNumber(VehicleRegistrationForm.eStatusOfFix i_NewStatusOfFix, string i_LicenceNumber)
        {
            if (r_DictionaryOfAllPatient.ContainsKey(i_LicenceNumber) == false)
            {
                // catch exception
                throw new ArgumentException("Vehicle Doesn't Exist");
            }
            else
            {
                r_DictionaryOfAllPatient[i_LicenceNumber].Status = i_NewStatusOfFix;
            }
        }

        public void BlowToMaximunWheelAirPrresure(string i_LicenceNumber)
        {
            foreach (Wheel wheel in r_DictionaryOfAllPatient[i_LicenceNumber].Vehicle.CollectionOfWheels)
            {
                wheel.BlowTheWheel(wheel.MaxAirPressure - wheel.CurrAirPressure);
            }
        }

        public void ChargeEnergySource(ChargingVehicleDetails i_ChargingVehicleDetails)
        {
            try
            {
                r_DictionaryOfAllPatient[i_ChargingVehicleDetails.LicenceNumber].Vehicle.EnergySource.ChargeEnergySource(i_ChargingVehicleDetails);
                r_DictionaryOfAllPatient[i_ChargingVehicleDetails.LicenceNumber].Vehicle.UpdateEnergyPercent();
            }
            catch(ValueOutOfRangeException)
            {
                float fixedQuantityToAdd;
                if (r_DictionaryOfAllPatient[i_ChargingVehicleDetails.LicenceNumber].Vehicle.EnergySource
                    .QuantityOfEnergyLeft + i_ChargingVehicleDetails.QuantityOfEnergyToAdd > 0)
                {
                    fixedQuantityToAdd =
                        r_DictionaryOfAllPatient[i_ChargingVehicleDetails.LicenceNumber].Vehicle.EnergySource
                            .MaxOfEnergyCanContain - r_DictionaryOfAllPatient[i_ChargingVehicleDetails.LicenceNumber]
                            .Vehicle.EnergySource.QuantityOfEnergyLeft;
                }
                else
                {
                    fixedQuantityToAdd = r_DictionaryOfAllPatient[i_ChargingVehicleDetails.LicenceNumber].Vehicle
                        .EnergySource.QuantityOfEnergyLeft * -1;
                }

                ChargingVehicleDetails fixedForm = new ChargingVehicleDetails(
                    i_ChargingVehicleDetails.LicenceNumber, fixedQuantityToAdd,
                    i_ChargingVehicleDetails.TypeOfEnergySource, i_ChargingVehicleDetails.FuelType);
                r_DictionaryOfAllPatient[i_ChargingVehicleDetails.LicenceNumber].Vehicle.EnergySource.ChargeEnergySource(i_ChargingVehicleDetails);

                throw new Exception("Overflows/Underflow the Contents of your Enery tank so tank was filled till max(in case of Overflows)/min (in case ofUnderflow) content reached");
            }
        }

        public void IsVehicleExists(string input)
        {
            if (r_DictionaryOfAllPatient.ContainsKey(input) == false)
            {
                throw new ArgumentException(
                    string.Format(
                        "the vehicle with the license plate {0} doesnt exists in the garage",
                        input));
            }
        }
    }
}
