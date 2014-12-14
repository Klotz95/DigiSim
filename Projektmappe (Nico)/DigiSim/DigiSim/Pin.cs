using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiSim
{
    class Pin
    {
        //Attribute
        bool setting;
        bool state;
        bool occupied;
        double xPosition;
        double yPosition;
        double lenght;

        //Konstruktor welcher abfragt, ob es sich um einen Input oder Output handelt (true = Input)(false = Output)
        public Pin(bool setting)
        {
          this.setting = setting;
          occupied = false;
        }
        public bool getSetting()
        {
          return setting;
        }
        public bool getState()
        {
          return state;
        }
        public void setState(bool state)
        {
          this.state = state;
        }
        public bool getOccupied()
        {
          return occupied;
        }
        public void setOccupied(bool state)
        {
          occupied = state;
        }
        public  void  draw()
        {

        }

    }
}
