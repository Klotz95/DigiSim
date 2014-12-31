using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiSim
{
    class Connection
    {
      //Attribute
      Pin Inputpin;
      Pin Outputpin;

      //Konstruktor, welchem die Pins übergeben werden (pass by ref)
      public Connection(ref Pin input, ref Pin output)
      {
        Inputpin = input;
        Outputpin = output;
      }
      public void statedelivery()
      {
          //set the state of the inputpin
          if (Outputpin.getState())
          {
              //Input = 1
              Inputpin.setState(true);
          }
          else
          {
              //Input = 0
              Inputpin.setState(false);
          }
      }


    }
}
