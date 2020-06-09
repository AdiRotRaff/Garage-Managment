using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Battery : EnergySource
    {
        public override void ChargeEnergySource(ChargingVehicleDetails i_ChargingDetails)
        {
            checkEnergySourceType(i_ChargingDetails.TypeOfEnergySource);
            checkForDeviationInTank(i_ChargingDetails.QuantityOfEnergyToAdd);

            this.QuantityOfEnergyLeft += i_ChargingDetails.QuantityOfEnergyToAdd;
        }

        public override void checkForDeviationInTank(float i_QuantityOfEnergyToAdd)
        {
            if (i_QuantityOfEnergyToAdd + QuantityOfEnergyLeft > MaxOfEnergyCanContain ||
                i_QuantityOfEnergyToAdd + QuantityOfEnergyLeft < 0)
            {
                throw new ValueOutOfRangeException(0, MaxOfEnergyCanContain);
            }
        }

        public override void checkEnergySourceType(eTypeOfEnergySource i_TypeOfEnergySource)
        {
            if (i_TypeOfEnergySource != eTypeOfEnergySource.Battery)
            {
                throw new ArgumentException(string.Format(@"be careful looks like you are trying to charge your battery with fuel"));
            }
        }

        public override string ToString()
        {
            return string.Format("{2}Vehicle Battery Left: {0}{2}vehicle Capacity Of Battery: {1}{2}", QuantityOfEnergyLeft, MaxOfEnergyCanContain, Environment.NewLine);
        }
    }
}
