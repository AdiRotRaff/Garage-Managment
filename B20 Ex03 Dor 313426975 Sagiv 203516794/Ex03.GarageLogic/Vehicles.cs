using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicles
    {
        private readonly string r_ModelName;
        private readonly string r_LicenceNumber;
        private float m_PrecentageOfRemainingEnergy;
        private Wheel m_CollectionOfWheels;

        public struct Wheel
        {
            private readonly string r_ManufactorName;
            private readonly float r_MaxAirPressure;
            private float m_CurrAirPressure;

            public Wheel(string i_ManufactorName, float i_MaxAirPressure, float i_CurrAirPressure)
            {
                this.r_ManufactorName = i_ManufactorName;
                this.r_MaxAirPressure = i_MaxAirPressure;
                this.m_CurrAirPressure = i_CurrAirPressure;
            }

            public void BlowTheWheel(float i_VolumeOfAir)
            {
                if (m_CurrAirPressure + i_VolumeOfAir > r_MaxAirPressure)
                {
                    m_CurrAirPressure = r_MaxAirPressure;
                }
                else
                {
                    m_CurrAirPressure = m_CurrAirPressure + i_VolumeOfAir;
                }
            }

            public string ManufactorName
            {
                get { return r_ManufactorName; }
            }

            public float MaxAirPressure
            {
                get { return r_MaxAirPressure; }
            }

            public float CurrAirPressure
            {
                get { return m_CurrAirPressure; }
            }
        }
}