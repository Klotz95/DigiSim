using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiSim
{
  class VCC:GateObject
  {
    //Konstruktor
    public VCC(double xPosition,double yPosition):base(xPosition,yPosition)
    {
      //Set the types
      outputs = 1;
      inputs = 0;
      //Create the outputPin
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
