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
    Connection[] Connections;
    GND[] GNDS;
    LED[] LEDS;
    Not[] Nots;
    OrGate[] Ors;
    Cswitch[] switches;
    VCC[] VCCS;
    //Konstruktor
    public UndoStorage(AndGate[] and, Connection[] cn, GND[] gn, VCC[] VC, LED[] LE, Not[] No, OrGate[] Or, Cswitch[] cswitch)
    {
      Ands = and;
      Connections = cn;
      GNDS = gn;
      LEDS = LE;
      Nots = No;
      Ors =Or;
      switches = cswitch;
      VCCS = VC;
    }
    public void getCurrentState(ref AndGate[] and, ref Connection[] cn, ref GND[] gn,ref VCC[] VC,ref LED[] LE,ref Not[] No,ref OrGate[] Or, ref Cswitch[] cswitch)
    {
      and = Ands;
      cn = Connections;
      gn = GNDS;
      VC = VCCS;
      LE = LEDS;
      No = Nots;
      Or = Ors;
      cswitch = switches;

    }

  }
}
