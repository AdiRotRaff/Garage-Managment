using System.Collections.Generic;
using Ex03.GarageLogic;

namespace B20_Ex03_Dor_313426975_Sagiv_203516794
{
    public class SystemManager
    {
        private readonly GarageManagment r_Garage = new GarageManagment();
        private UI m_Ui = new UI();

        private GarageManagment Garage
        {
            get { return r_Garage; }
        }
        private UI Ui
        {
            get { return m_Ui; }
            set { m_Ui = value; }
        }

        public void OpenGarage()
        {
            UI.eUserChoice choice;
            bool v_closeGarage;

            do
            {


            } while (v_closeGarage == true);
        }
    }
}
