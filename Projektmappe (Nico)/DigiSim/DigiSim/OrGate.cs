using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigiSim
{
    [Serializable]
    class OrGate:GateObject
    {
      public OrGate(double xPosition,double yPosition):base(xPosition,yPosition)
      {
        //set the inputs an outpus counter
        inputs = 2;
        outputs = 1;
          //set height and witdt
        height = 100;
        width = 60;
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
      public bool refresh()
      {
        bool drawing = false;
        //look whether the input and outputcounts have changed
        if(inputs + outputs != allPins.Length)
        {
          drawing = true;
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
        return drawing;

      }
      public void draw(ref Graphics g)
      {
        //draw the rectangle
          Point p = new Point();
          p.X = Convert.ToInt32(xPosition);
          p.Y = Convert.ToInt32(yPosition);
          Size s = new Size();
          //check if height ok
          if (allPins.Length > 6)
          {
              height = 100 + ((allPins.Length - 6) * 20);
          }
          else
          {
              height = 100;
          }
          s.Height = Convert.ToInt32(height);
          s.Width = Convert.ToInt32(width);
          g.DrawRectangle(Pens.Black, new Rectangle(p, s));
          //draw the font
          string or = ">=1";
          p.X = Convert.ToInt32(xPosition + (width / 2) - 20);
          p.Y = Convert.ToInt32(yPosition + (height / 2) - 10);
          g.DrawString(or, new Font(SystemFonts.DefaultFont, FontStyle.Regular), Brushes.Black, p);
          //draw the ouput
          p.X = Convert.ToInt32(xPosition + width);
          p.Y = Convert.ToInt32(yPosition + (height / 2) - 5);
          allPins[0].draw(Convert.ToDouble(p.X), Convert.ToDouble(p.Y), ref g);
          //draw the inputs
          p.X = Convert.ToInt32(xPosition - 10);
          p.Y = Convert.ToInt32(yPosition);
          for (int i = 1; i < allPins.Length; i++)
          {
              allPins[i].draw(Convert.ToDouble(p.X), Convert.ToDouble(p.Y), ref g);
              p.Y = p.Y + 20;
          }


      }
    }
}
