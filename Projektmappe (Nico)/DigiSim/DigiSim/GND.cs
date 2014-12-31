using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiSim
{
    class GND:GateObject
    {
      //Konstruktor
      public GND(double xPosition, double yPosition):base(xPosition,yPosition)
      {
        //Set pin and create one
        inputs = 0;
        outputs = 1;
        Pin first = new Pin(false);
        allPins = new Pin[1];
        allPins[0] = first;
      }
      public bool outen()
      {
        return false;
      }
      public void draw()
      {

      }
    }

}
