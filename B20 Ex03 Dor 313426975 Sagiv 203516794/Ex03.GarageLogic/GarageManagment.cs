using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManagment
    {
        // key is LicenceNumber and data is VehicleRegistrationForm
        private readonly Dictionary<string, VehicleRegistrationForm> r_DictionaryOfAllPatient = new Dictionary<string, VehicleRegistrationForm>();

        public void EnterVehicleToGarage(Vehicle i_NewVehicle, VehicleRegistrationForm i_RegistrationForm)
        {
            if (r_DictionaryOfAllPatient.ContainsKey(i_NewVehicle.LicenceNumber) == true)
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
                wheel.BlowTheWheel(wheel.MaxAirPressure);
            }
        }

        public void FillEnergySource(ChargingVehicleDetails i_ChargingVehicleDetails)
        {
            try
            {
                r_DictionaryOfAllPatient[i_ChargingVehicleDetails.LicenceNumber].Vehicle.EnergySource
                    .ChargeEnergySource(i_ChargingVehicleDetails);
            }
            catch(ValueOutOfRangeException)
            {
                Console.WriteLine("Overflows the Contents of your Enery tank so tank was filled till max content reached");
                i_ChargingVehicleDetails.QuantityOfEnergyToAdd =
                    r_DictionaryOfAllPatient[i_ChargingVehicleDetails.LicenceNumber].Vehicle.EnergySource
                        .MaxOfEnergyCanContain - r_DictionaryOfAllPatient[i_ChargingVehicleDetails.LicenceNumber]
                        .Vehicle.EnergySource.QuantityOfEnergyLeft;
                r_DictionaryOfAllPatient[i_ChargingVehicleDetails.LicenceNumber].Vehicle.EnergySource
                    .ChargeEnergySource(i_ChargingVehicleDetails);
            }
        }
    }
}
