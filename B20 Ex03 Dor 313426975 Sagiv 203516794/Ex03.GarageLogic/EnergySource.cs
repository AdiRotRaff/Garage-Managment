namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        public enum eTypeOfEnergySource
        {
            Battery = 0,
            Fuel
        }

        private float m_QuantityOfEnergyLeft;
        private float m_MaxOfEnergyCanContain;

        public float QuantityOfEnergyLeft
        {
            get { return m_QuantityOfEnergyLeft; }
            set
            {
                // catch exception
                checkForDeviationInTank(value);
                m_QuantityOfEnergyLeft = value;
            }
        }

        public float MaxOfEnergyCanContain
        {
            get { return m_MaxOfEnergyCanContain; }
            set { m_MaxOfEnergyCanContain = value; }
        }

        public abstract void checkForDeviationInTank(float i_QuantityOfEnergyToAdd);

        public abstract void checkEnergySourceType(eTypeOfEnergySource i_TypeOfEnergySource);

        public abstract void ChargeEnergySource(ChargingVehicleDetails i_ChargingDetails);

        public abstract override string ToString();
    }
}
