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
      public void statedelivery
      {
        //check for state of Outputpin and deliver to Inputpin
        if(Outputpin.getState())
        {
          //set Input to true
          Inputpin.setState(true);
        }
        else
        {
          Inputpin.setState(false);
        }
      }


    }
}
