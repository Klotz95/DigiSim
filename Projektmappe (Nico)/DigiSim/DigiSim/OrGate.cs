using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiSim
{
    class OrGate:GateObject
    {
      public OrGate(double xPosition,double yPosition):base(xPosition,yPosition)
      {
        //set the inputs an outpus counter
        inputs = 2;
        outputs = 1;
        //create the pins
        Pin firstOutput = new Pin(false);
        Pin firstInput = new Pin(true);
        Pin secondInput = new Pin(true);
        //create the array and fill it
        allPins = new Pin[3];
        allPins[0] = firstOutput;
        allPins[1] = firstInput;
        allPins[2] = secondInput;

      }
      public void refresh()
      {
        //look whether the input and outputcounts have changed
        if(inputs + outputs != allPins.Length)
        {
          Pin[] saved = allPins;
          //look if more or less
          if(allPins.Length < inputs + outputs)
          {
            allPins = new Pin[inputs + outputs];
            for(int i = 0;i<saved.Length;i++)
            {
              allPins[i] = saved[i];
            }
            //create new one
            for(int i = saved.Length;i<inputs + outputs;i++)
            {
              Pin newOne = new Pin(true);
              allPins[i] = newOne;
            }

          }
          else
          {
            //transfer the old to the new one, without the unecessary Pin
            allPins = new Pin[inputs + outputs];
            for(int i = 0;i<inputs + outputs;i++)
            {
              allPins[i] = saved[i];
            }
          }
        }
        //now check the correct statement and set the output Pin
        bool outen = false;
        for(int i = 1;i<allPins.Length;i++)
        {
          if(allPins[i].getState())
          {
            outen = true;
          }
        }
        allPins[0].setState(outen);

      }
      public void draw()
      {
        
      }
    }
}
