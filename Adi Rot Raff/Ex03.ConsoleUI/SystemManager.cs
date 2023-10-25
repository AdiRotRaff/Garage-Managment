using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class SystemManager
    {
        private readonly GarageManagment r_Garage = new GarageManagment();
        private UI m_Ui = new UI();

        public GarageManagment Garage
        {
            get { return r_Garage; }
        }

        public UI Ui
        {
            get { return m_Ui; }
            set { m_Ui = value; }
        }

        public void OpenGarage()
        {
            UI.eUserChoice choice = new UI.eUserChoice();
            bool v_closeGarage = false;

            Ui.PrintSignToUser(string.Format("Welcome to Brian O'Conner and Turto's garage"));

            do
            {
                try
                {
                    choice = (UI.eUserChoice) m_Ui.PrintAllEnumValuesGetUserChoice(choice, "Menu");
                    m_Ui.ClearConsole();

                    if (choice == UI.eUserChoice.InsertNewCar)
                    {
                        insertNewCar();
                    }
                    else if (choice == UI.eUserChoice.DisplayDriverLicenceNumberWithFilterByStatusOfFix)
                    {
                        displayDriverLicenceNumberWithFilterByStatusOfFix();
                    }
                    else if (choice == UI.eUserChoice.ChangeStatusOfFix)
                    {
                        changeStatusOfFix();
                    }
                    else if (choice == UI.eUserChoice.BlowWheelsToMaximum)
                    {
                        blowWheelsToMax();
                    }
                    else if (choice == UI.eUserChoice.ChargeVehicle)
                    {
                        chargeVehicle();
                    }
                    else if (choice == UI.eUserChoice.DisplayFullDetailsOfVehicleByLicenceNumber)
                    {
                        displayFullVehicleDataByLicenseNumber();
                    }
                    else if (choice == UI.eUserChoice.Exit)
                    {
                        v_closeGarage = true;
                    }
                    else
                    {
                        m_Ui.PrintInvalidErrorWithSpecificError("Chose Wrong Number");
                    }
                }
                catch (ArgumentException ae)
                {
                    m_Ui.PrintNatural(ae.Message);
                }
                catch (FormatException)
                {
                    m_Ui.PrintInvalidErrorWithSpecificError("You need to choose an integer");
                }
            }
            while (v_closeGarage == false);

            m_Ui.PrintSignToUser("Goodbye Brian O'Conner and Turto's garage It Was A good Time");
        }

        private void insertNewCar()
        {
            VehicleRegistrationForm currRegistrationForm = null;
            bool v_VehicleExist;

            try
            {
                v_VehicleExist = false;
                currRegistrationForm = fillVehicleRegistrationForm();
            }
            catch (ArgumentException ae)
            {
                //// existing license number exist
                v_VehicleExist = true;
                m_Ui.PrintNatural(ae.Message);
            }

            if (v_VehicleExist == false)
            {
                Garage.EnterVehicleToGarage(currRegistrationForm);
                m_Ui.PrintNatural("Car Was Inserted");
            }
        }

        private VehicleRegistrationForm fillVehicleRegistrationForm()
        {
            VehicleRegistrationForm newreRegistrationForm;
            Vehicle newVehicle;
            string ClientName;

            m_Ui.PrintSignToUser(string.Format("Filling Vehicle Registration Form"));

            try
            {
                newVehicle = registNewCar(); // throws excweption in case of existing license number
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }

            m_Ui.PrintSignToUser(string.Format("Contact Information"));
            ClientName = m_Ui.GetStringWIthoutConditionFromUser("Name");

            newreRegistrationForm = new VehicleRegistrationForm(newVehicle, ClientName);
            getPhoneNumberToRegistrationForm(newreRegistrationForm);

            return newreRegistrationForm;
        }

        private void getPhoneNumberToRegistrationForm(VehicleRegistrationForm i_NewreRegistrationForm)
        {
            string ClientPhoneNumber;
            bool v_ValidRegistrationForm;

            do
            {
                v_ValidRegistrationForm = true;

                try
                {
                    ClientPhoneNumber = m_Ui.GetStringWIthoutConditionFromUser("Phone Number");
                    i_NewreRegistrationForm.PhoneNumber = ClientPhoneNumber;
                }
                catch (ValueOutOfRangeException vore)
                {
                    m_Ui.PrintNatural(vore.Message);
                    v_ValidRegistrationForm = false;
                }
            }
            while (v_ValidRegistrationForm == false);
        }

        private Vehicle registNewCar()
        {
            Vehicle registedVehicle;
            string licenceNumber;
            string modelName;
            string wheelManufactor;

            m_Ui.PrintSignToUser("Create Vehicle");

            m_Ui.GetVehicleLicenseNumberCheckForExisiting(Garage, out licenceNumber);
            try
            {
                r_Garage.IsVehicleExists(licenceNumber);
            }
            catch(ArgumentException ae)
            {
                r_Garage.ChangeStatus(licenceNumber, VehicleRegistrationForm.eStatusOfFix.InProgress);
                //// for good kriot (for those who will see insert new car method)
                throw new ArgumentException(string.Format("{0} Status Changed To In Progress", licenceNumber));
            }

            modelName = m_Ui.GetStringWIthoutConditionFromUser("Model Name");
            wheelManufactor = m_Ui.GetStringWIthoutConditionFromUser("Wheel Manufacture Name");
            registedVehicle = MakeVehicle(licenceNumber, modelName, wheelManufactor);
            insertRestVehicleDetails(registedVehicle);

            return registedVehicle;
        }

        private Vehicle MakeVehicle(string i_LicenceNumber, string i_ModelName, string i_WheelManufactor)
        {
            Vehicle newVehicle = null;
            EnergySource.eTypeOfEnergySource typeOfEnergySource = new EnergySource.eTypeOfEnergySource();
            VehicleManufactur.eSupportedVehicle typeOfVehicleToInsert = new VehicleManufactur.eSupportedVehicle();
            bool v_VehicleIsValid = true;

            do
            {
                try
                {
                    typeOfVehicleToInsert = (VehicleManufactur.eSupportedVehicle) m_Ui.PrintAllEnumValuesGetUserChoice(typeOfVehicleToInsert, "Vehicle Choosing");
                    typeOfEnergySource = (EnergySource.eTypeOfEnergySource) m_Ui.PrintAllEnumValuesGetUserChoice(typeOfEnergySource, "Energy Source Choosing");
                    newVehicle = VehicleManufactur.CreateVehicles(out v_VehicleIsValid, i_LicenceNumber, i_ModelName, typeOfEnergySource, i_WheelManufactor, typeOfVehicleToInsert);
                }
                catch (ArgumentException ae)
                {
                    //// (RIGHT NOW) possible ArgumentException for inserting unsupported Vehicle or insert electric truck (not supported)
                    v_VehicleIsValid = false;
                    m_Ui.PrintNatural(ae.Message);
                }
            }
            while (v_VehicleIsValid == false);

            return newVehicle;
        }

        private void insertRestVehicleDetails(Vehicle i_NewVehicle)
        {
            m_Ui.PrintSignToUser("Insert Current Situation Of Your Vehicle");
            insertCurrrentAirPressureOfWheels(i_NewVehicle);
            insertAmountOfEnergyToAdd(i_NewVehicle);

            if (i_NewVehicle is Motorcycle)
            {
                Motorcycle.eCategoryOfmotocycleLicence categoryOfMotocycleLicence = new Motorcycle.eCategoryOfmotocycleLicence();
                int engineCapacity;

                categoryOfMotocycleLicence = (Motorcycle.eCategoryOfmotocycleLicence)m_Ui.PrintAllEnumValuesGetUserChoice(categoryOfMotocycleLicence, "Motocycle License Category");
                m_Ui.PrintSignToUser("Engine Capacity");
                engineCapacity = (int)m_Ui.getFloatWithoutAnyCondition("Engine Capacity");

                i_NewVehicle.FillRestDetails(categoryOfMotocycleLicence, engineCapacity);
            }
            else if (i_NewVehicle is Car)
            {
                Car.eDoorsAmount doorsAmount = new Car.eDoorsAmount();
                Car.eCarColor color = new Car.eCarColor();

                doorsAmount = (Car.eDoorsAmount)m_Ui.PrintAllEnumValuesGetUserChoice(doorsAmount, "Amount Of Doors");
                color = (Car.eCarColor)m_Ui.PrintAllEnumValuesGetUserChoice(color, "Car Color");

                i_NewVehicle.FillRestDetails(doorsAmount, color);
            }
            else
            {
                bool v_ContainHazerMaterial;
                float cargoVolume;

                m_Ui.PrintSignToUser("Cargo Volume");
                cargoVolume = m_Ui.getFloatWithoutAnyCondition("Cargo Volume");
                int userChoice;

                m_Ui.PrintSignToUser("Contain Hazer Material IMPORTANT");
                do
                {
                    userChoice = (int)m_Ui.getFloatWithoutAnyCondition("Hazer Material (1 if Your Truck Contains Hazer Material And 0 if Not)");

                    if (userChoice != 0 && userChoice != 1)
                    {
                        m_Ui.PrintInvalidErrorWithSpecificError("Enter An Int Number 1 Or 0");
                    }
                }
                while (userChoice != 0 && userChoice != 1);
                v_ContainHazerMaterial = userChoice == 1;
                i_NewVehicle.FillRestDetails(v_ContainHazerMaterial, cargoVolume);
            }
        }

        private void insertCurrrentAirPressureOfWheels(Vehicle i_NewVehicle)
        {
            bool isValid = true;
            float airPressureToAdd;

            do
            {
                airPressureToAdd = m_Ui.getFloatWithoutAnyCondition("Current Wheel Air Pressure");
                try
                {
                    foreach (Wheel currentWheel in i_NewVehicle.CollectionOfWheels)
                    {
                        currentWheel.CurrAirPressure = airPressureToAdd;
                    }

                    isValid = true;
                }
                catch (ValueOutOfRangeException)
                {
                    m_Ui.PrintNatural(string.Format(
                        @"Air perssure isn't in correct range,
now the pressure is {0} and at most for this vehcile is {1}",
                        i_NewVehicle.CollectionOfWheels[0].CurrAirPressure,
                        i_NewVehicle.CollectionOfWheels[0].MaxAirPressure));
                    isValid = false;
                }
            }
            while (!isValid);
        }

        private void insertAmountOfEnergyToAdd(Vehicle i_NewVehicle)
        {
            float AmountOfEnergyToEnter;
            bool isValidInput;

            do
            {
                try
                {
                    AmountOfEnergyToEnter = m_Ui.getFloatWithoutAnyCondition("Current Energy Source Quantity");
                    i_NewVehicle.EnergySource.QuantityOfEnergyLeft = AmountOfEnergyToEnter;
                    i_NewVehicle.UpdateEnergyPercent();
                    isValidInput = true;
                }
                catch (ValueOutOfRangeException rangeException)
                {
                    m_Ui.PrintNatural(string.Format(@"
please enter the amount to add again"));
                    m_Ui.PrintNatural(rangeException.Message);
                    isValidInput = false;
                }
            }
            while (isValidInput == false);
        }

        private void displayDriverLicenceNumberWithFilterByStatusOfFix()
        {
            VehicleRegistrationForm.eStatusOfFix statusChoice = new VehicleRegistrationForm.eStatusOfFix();
            UI.eDisplayOption displayChoice = new UI.eDisplayOption();
            bool displayAll = false;

            displayChoice =
                (UI.eDisplayOption) m_Ui.PrintAllEnumValuesGetUserChoice(displayChoice, "Display Option Choosing");

            if (displayChoice == UI.eDisplayOption.AllVehicles)
            {
                displayAll = true;
            }
            else
            {
                statusChoice =
                    (VehicleRegistrationForm.eStatusOfFix) m_Ui.PrintAllEnumValuesGetUserChoice(statusChoice, "Status Of Fix Choosing");
            }

            m_Ui.PrintLicensePlatesWithStatusFilterIfNeeded(statusChoice, r_Garage.DictionaryOfAllPatient, displayAll);
        }

        private void changeStatusOfFix()
        {
            string licenseNumber;
            VehicleRegistrationForm.eStatusOfFix statusToChangeToChoice = new VehicleRegistrationForm.eStatusOfFix();
            bool v_VehicleFound;

            m_Ui.PrintSignToUser("Change Status Of Fix By License Number");

            do
            {
                v_VehicleFound = m_Ui.GetVehicleLicenseNumberCheckForExisiting(Garage, out licenseNumber);
                if (v_VehicleFound == false)
                {
                    Console.WriteLine("Vehicle Wasn't Found Try Again");
                }
            }
            while (v_VehicleFound == false);

            statusToChangeToChoice =
                (VehicleRegistrationForm.eStatusOfFix) m_Ui.PrintAllEnumValuesGetUserChoice(statusToChangeToChoice, "Status Of Fix Choosing");

            try
            {
                r_Garage.DictionaryOfAllPatient[licenseNumber].CheckEqualStatus(statusToChangeToChoice);
            }
            catch (ArgumentException ae)
            {
                m_Ui.PrintNatural(ae.Message);
            }

            r_Garage.DictionaryOfAllPatient[licenseNumber].Status = statusToChangeToChoice;
            m_Ui.PrintNatural("Status Changed");
        }

        private void blowWheelsToMax()
        {
            string licenseNumber;
            bool v_VehicleFound;

            m_Ui.PrintSignToUser("Blowing Wheels");

            do
            {
                v_VehicleFound = m_Ui.GetVehicleLicenseNumberCheckForExisiting(Garage, out licenseNumber);
                if (v_VehicleFound == false)
                {
                    Console.WriteLine("Vehicle Wasn't Found Try Again");
                }
            }
            while (v_VehicleFound == false);

            r_Garage.BlowToMaximunWheelAirPrresure(licenseNumber);
            m_Ui.PrintNatural("All Wheels were Blown To Max");
        }

        private void chargeVehicle()
        {
            bool v_ChargedVehicle;
            ChargingVehicleDetails chargingForm;

            m_Ui.PrintSignToUser("charging vehicle");

            do
            {
                v_ChargedVehicle = true;

                try
                {
                    chargingForm = m_Ui.FillChargingVehicleForm(Garage);
                    r_Garage.ChargeEnergySource(chargingForm);
                }
                catch (ValueOutOfRangeException rangeException)
                {
                    m_Ui.PrintNatural(rangeException.Message);
                    m_Ui.PrintNatural(
                        "Overflows/Underflow the Contents of your Energy tank so tank was filled till max(in case of Overflows)/min (in case ofUnderflow) content reached");
                }
                catch (ArgumentException ae)
                {
                    m_Ui.PrintNatural(ae.Message);
                    m_Ui.PrintNatural("Fill Charging Form Again");
                    v_ChargedVehicle = false;
                }
            }
            while (v_ChargedVehicle == false);

            m_Ui.PrintNatural("Vehicle Charged!!");
        }

        private void displayFullVehicleDataByLicenseNumber()
        {
            string licenseNumber;
            bool v_VehicleFound;

            m_Ui.PrintSignToUser("Display Full Client Data");

            do
            {
                v_VehicleFound = m_Ui.GetVehicleLicenseNumberCheckForExisiting(Garage, out licenseNumber);
                if (v_VehicleFound == false)
                {
                    Console.WriteLine("Vehicle Wasn't Found Try Again");
                }
            }
            while (v_VehicleFound == false);

            m_Ui.PrintNatural(r_Garage.DictionaryOfAllPatient[licenseNumber].ToString());
        }
    }
}