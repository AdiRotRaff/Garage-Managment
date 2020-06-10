namespace Ex03.GarageLogic
{
    public enum eMaxAirPressure
    {
        Motorcycle = 30,
        Car = 32,
        Truck = 28,
    }

    // check if struct
    public class Wheel
    {
        private readonly string  r_ManufactorName;
        private float            m_MaxAirPressure;
        private float            m_CurrAirPressure ;

        public Wheel(string i_ManufactorName, float i_MaxAirPressure)
        {
            this.r_ManufactorName = i_ManufactorName;
            this.m_MaxAirPressure = i_MaxAirPressure; 
            this.m_CurrAirPressure = 0;
        }

        public void BlowTheWheel(float i_VolumeOfAir)
        {
            if (m_CurrAirPressure + i_VolumeOfAir > m_MaxAirPressure || m_CurrAirPressure + i_VolumeOfAir < 0)
            {
                // in catch block make m_CurrAirPressure = m_MaxAirPressure
                throw new ValueOutOfRangeException(0, m_MaxAirPressure);
            }

            CurrAirPressure += i_VolumeOfAir;
        }

        public string ManufactorName
        {
            get { return r_ManufactorName; }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }

        public float CurrAirPressure
        {
            get { return m_CurrAirPressure; }
            set {
                if (value > MaxAirPressure || value < 0)
                {
                    throw  new ValueOutOfRangeException(0, MaxAirPressure);
                }

                m_CurrAirPressure = value;
            }
        }
        public override string ToString()
        {
            string result;

            result = string.Format(
                @"Air pressure: {0}
Manufacturer: {1}",this.CurrAirPressure,this.ManufactorName);

            return result;
        }
    }

}
