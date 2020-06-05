using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        private float MaxValue
        {
            get { return m_MaxValue;}
            set { m_MaxValue = value;}
        }

        private float MinValue
        {
            get { return m_MinValue; }
            set { m_MinValue = value; }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : base( String.Format("ERROR: The Value should be in range from {0} to {1}", i_MinValue, i_MaxValue))
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }

    }
}
