using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigiSim
{
  class AndGate:GateObject
  {
    //Konstruktor
    public AndGate(double xPosition,double yPosition):base(xPosition,yPosition)
    {
      //set the count of output- and inputpins (standart 2 input Pins)
      outputs = 1;
      inputs = 2;
      //set height width
      height = 100;
      width = 60;
      //create the Pins
      Pin firstOut = new Pin(false);
      Pin firstIn = new Pin(true);
      Pin secondIn = new Pin(true);
      //Add to the array
      allPins = new Pin[3];
      allPins[0] = firstOut;
      allPins[1] = firstIn;
      allPins[2] = secondIn;
    }
    public bool refresh()
    {
      //look for a changing in the counting of inputs
        bool drawing = false;
        if (allPins.Length != outputs + inputs)
        {
            drawing = true;
            //save the current array
            Pin[] saved = allPins;
            //look wheter there are less or more Pins
            if (allPins.Length < inputs + outputs)
            {
                allPins = new Pin[inputs + outputs];
                int neededPins = (inputs + outputs) - saved.Length;
                //transfer the old array to the new one
                for (int i = 0; i < saved.Length; i++)
                {
                    allPins[i] = saved[i];
                }
                //now create the new InputsPins
                for (int i = saved.Length; i < allPins.Length; i++)
                {
                    Pin newPin = new Pin(true);
                    allPins[i] = newPin;
                }
            }
            else
            {
               //transfer the old pins to the new array wihtout the unnecessary Pin
               allPins = new Pin[inputs+outputs];
               for(int i = 0;i<inputs + outputs;i++)
               {
                 allPins[i] = saved[i];
               }
            }

        }
        //now check if output = 1 or output = 0
        bool outen = true;
        for(int i = 1;i<allPins.Length;i++)
        {
          if(!allPins[i].getState())
          {
            outen = false;
          }
        }
        allPins[0].setState(outen);
        return drawing;

    }
    public void draw(ref Graphics g)
    {
        //draw the rectangle and create the label
        Point p = new Point();
        p.X = Convert.ToInt32(xPosition);
        p.Y = Convert.ToInt32(yPosition);
        Size s = new Size();
        //check if height is ok
        if (allPins.Length > 6)
        {
            height = 100 + ((allPins.Length - 6) * 20);
        }
        else
        {
            height = 100;
        }
        s.Width = Convert.ToInt32(width);
        s.Height = Convert.ToInt32(height);
        g.DrawRectangle(Pens.Black, new Rectangle(p, s));
        //draw the font
        p.X = Convert.ToInt32(xPosition + (width / 2) - 10);
        p.Y = Convert.ToInt32(yPosition + (height / 2) - 10);
        string And = "&";
        g.DrawString(And, new Font(SystemFonts.DefaultFont, FontStyle.Regular), Brushes.Black, p);
        //draw the Pins
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
