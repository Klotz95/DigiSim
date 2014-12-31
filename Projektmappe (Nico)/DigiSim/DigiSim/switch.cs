using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiSim
{
    class Cswitch:GateObject
    {
        //Attribute
        bool state;
        //Konstruktor
        public Cswitch(double xPosition, double yPosition):base(xPosition,yPosition)
        {
          //set the correct input/outputs
          outputs = 1;
          inputs = 0;
          //Create the output Pin
          Pin first = new Pin(false);
          allPins = new Pin[1];
          allPins[0] = first;
          //turn the switch off
          state = false;

        }
        public void ChangeState()
        {
            state = !state;
        }
        public void refresh()
        {
          //set the outputpin to the state of the button
            allPins[0].setState(state);
        }
        public void draw()
        {

        }

    }
}
