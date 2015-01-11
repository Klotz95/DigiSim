using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiSim
{
  class UndoStorage
  {
    //Attribute
      AndGate[] Ands;
      Connection[] Connection;
    GND[] GNDS;
    VCC[] VCCS;
    LED[] LEDS;
    Not[] Nots;
    OrGate[] Ors;
    Cswitch[] switches;
    int count = 0;
    //Konstruktor
    public void setCurrentState(AndGate[] and, Connection[] cn, GND[] gn, VCC[] VC, LED[] LE, Not[] No, OrGate[] Or, Cswitch[] cswitch)
    {
        
    }
 
  }
}
